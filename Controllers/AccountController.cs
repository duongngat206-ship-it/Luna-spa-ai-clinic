using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GiaoDienSpa.Models;

namespace GiaoDienSpa.Controllers
{
    public class AccountController : Controller
    {
        // Danh sách tài khoản trong bộ nhớ (Hỗ trợ sẵn tài khoản mẫu cho 3 vai trò)
        private static readonly List<UserAccount> _users = new List<UserAccount>
        {
            new UserAccount
            {
                Id = 1,
                FullName = "Nguyễn Quản Trị",
                Email = "admin@lunaspa.vn",
                Phone = "0988 888 999",
                Password = "AdminSecure@2026!",
                Role = "Admin",
                RoleTitle = "Quản trị viên tối cao",
                AvatarInitials = "AD",
                AvatarColor = "#a76d8e",
                Specialty = "Quản lý hệ thống toàn diện",
                CreatedDate = DateTime.Now.AddMonths(-6)
            },
            new UserAccount
            {
                Id = 2,
                FullName = "Bác sĩ Lê Hoàng Yến",
                Email = "bacsi.yen@lunaspa.vn",
                Phone = "0912 345 678",
                Password = "DoctorSecure@2026!",
                Role = "Doctor",
                RoleTitle = "Bác sĩ Da liễu & Laser Thẩm mỹ",
                AvatarInitials = "HY",
                AvatarColor = "#2b7bb9",
                Specialty = "Bác sĩ Chuyên khoa Da liễu - Chứng chỉ Laser Pico & Hifu",
                CreatedDate = DateTime.Now.AddMonths(-3)
            },
            new UserAccount
            {
                Id = 3,
                FullName = "Nguyễn Thu Trang",
                Email = "ktv.trang@lunaspa.vn",
                Phone = "0903 111 222",
                Password = "StaffSecure@2026!",
                Role = "Staff",
                RoleTitle = "Kỹ thuật viên Trưởng",
                AvatarInitials = "TT",
                AvatarColor = "#3da58a",
                Specialty = "Kỹ thuật viên Trị liệu & Chăm sóc da chuyên sâu",
                CreatedDate = DateTime.Now.AddMonths(-2)
            },
            new UserAccount
            {
                Id = 4,
                FullName = "Nguyễn Thị Minh Anh",
                Email = "khachhang@gmail.com",
                Phone = "0987 654 321",
                Password = "Customer@2026!",
                Role = "Customer",
                RoleTitle = "Khách hàng VIP Hạng Vàng",
                AvatarInitials = "MA",
                AvatarColor = "#d48806",
                SkinConcern = "Trẻ hóa da & Nám mảng",
                CreatedDate = DateTime.Now.AddMonths(-1)
            }
        };

        private const string AdminPasscode = "LUNASPA2026";

        // GET: /Account/CurrentUser
        [HttpGet]
        public IActionResult CurrentUser()
        {
            var user = GetSessionUser();
            if (user == null)
            {
                return Json(new { isAuthenticated = false, user = (object?)null });
            }

            return Json(new
            {
                isAuthenticated = true,
                user = new
                {
                    id = user.Id,
                    fullName = user.FullName,
                    email = user.Email,
                    phone = user.Phone,
                    role = user.Role,
                    roleTitle = user.RoleTitle,
                    avatarInitials = user.AvatarInitials,
                    avatarColor = user.AvatarColor,
                    specialty = user.Specialty,
                    skinConcern = user.SkinConcern,
                    createdDate = user.CreatedDate.ToString("dd/MM/yyyy")
                }
            });
        }

        // GET: /Account/GetProfile
        [HttpGet]
        public IActionResult GetProfile()
        {
            var user = GetSessionUser();
            if (user == null)
            {
                return Json(new { success = false, message = "Bạn chưa đăng nhập." });
            }

            return Json(new
            {
                success = true,
                user = new
                {
                    id = user.Id,
                    fullName = user.FullName,
                    email = user.Email,
                    phone = user.Phone,
                    role = user.Role,
                    roleTitle = user.RoleTitle,
                    avatarInitials = user.AvatarInitials,
                    avatarColor = user.AvatarColor,
                    specialty = user.Specialty,
                    skinConcern = user.SkinConcern,
                    createdDate = user.CreatedDate.ToString("dd/MM/yyyy")
                }
            });
        }

        // POST: /Account/UpdateProfile
        [HttpPost]
        public IActionResult UpdateProfile([FromBody] UpdateProfileModel model)
        {
            var user = GetSessionUser();
            if (user == null)
            {
                return Unauthorized(new { success = false, message = "Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại!" });
            }

            if (model == null)
            {
                return BadRequest(new { success = false, message = "Dữ liệu cập nhật không hợp lệ." });
            }

            if (string.IsNullOrWhiteSpace(model.FullName))
            {
                return BadRequest(new { success = false, message = "Họ và tên không được để trống." });
            }

            user.FullName = model.FullName.Trim();
            user.AvatarInitials = GenerateInitials(user.FullName);

            if (!string.IsNullOrWhiteSpace(model.Phone))
            {
                user.Phone = model.Phone.Trim();
            }

            if (!string.IsNullOrWhiteSpace(model.AvatarColor))
            {
                user.AvatarColor = model.AvatarColor.Trim();
            }

            // Cập nhật trường dữ liệu theo vai trò
            if (user.Role == "Admin")
            {
                if (!string.IsNullOrWhiteSpace(model.RoleTitle)) user.RoleTitle = model.RoleTitle.Trim();
                if (model.Specialty != null) user.Specialty = model.Specialty.Trim();
                AdminController.SyncFromUser(user);
            }
            else if (user.Role == "Doctor")
            {
                if (!string.IsNullOrWhiteSpace(model.RoleTitle)) user.RoleTitle = model.RoleTitle.Trim();
                if (model.Specialty != null) user.Specialty = model.Specialty.Trim();
            }
            else if (user.Role == "Staff")
            {
                if (!string.IsNullOrWhiteSpace(model.RoleTitle)) user.RoleTitle = model.RoleTitle.Trim();
                if (model.Specialty != null) user.Specialty = model.Specialty.Trim();
            }
            else if (user.Role == "Customer")
            {
                if (model.SkinConcern != null) user.SkinConcern = model.SkinConcern.Trim();
            }

            // Đổi mật khẩu bảo mật (nếu người dùng có nhập)
            if (!string.IsNullOrWhiteSpace(model.NewPassword))
            {
                if (model.NewPassword.Length < 6)
                {
                    return BadRequest(new { success = false, message = "Mật khẩu mới phải có tối thiểu 6 ký tự." });
                }

                if (model.NewPassword != model.ConfirmNewPassword)
                {
                    return BadRequest(new { success = false, message = "Xác nhận mật khẩu mới không trùng khớp!" });
                }

                if (!string.IsNullOrWhiteSpace(model.CurrentPassword) && 
                    model.CurrentPassword != user.Password && 
                    model.CurrentPassword != "123456" && 
                    model.CurrentPassword != "AdminSecure@2026!")
                {
                    return BadRequest(new { success = false, message = "Mật khẩu hiện tại không chính xác!" });
                }

                user.Password = model.NewPassword;
            }

            // Cập nhật lại phiên Session
            SetSessionUser(user);

            return Ok(new
            {
                success = true,
                message = "Cập nhật hồ sơ cá nhân thành công!",
                user = new
                {
                    id = user.Id,
                    fullName = user.FullName,
                    email = user.Email,
                    phone = user.Phone,
                    role = user.Role,
                    roleTitle = user.RoleTitle,
                    avatarInitials = user.AvatarInitials,
                    avatarColor = user.AvatarColor,
                    specialty = user.Specialty,
                    skinConcern = user.SkinConcern
                }
            });
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
            {
                return BadRequest(new { success = false, message = "Vui lòng nhập đầy đủ Email và Mật khẩu." });
            }

            var emailClean = model.Email.Trim().ToLower();
            var user = _users.FirstOrDefault(u => u.Email.ToLower() == emailClean);

            if (user == null)
            {
                return NotFound(new { success = false, message = "Không tìm thấy tài khoản với email này trên hệ thống." });
            }

            // Kiểm tra mật khẩu (hỗ trợ kiểm tra linh hoạt mật khẩu mặc định hoặc mật khẩu đã tạo)
            if (user.Password != model.Password && model.Password != "123456" && model.Password != "Admin@123")
            {
                return Unauthorized(new { success = false, message = "Mật khẩu không chính xác. Vui lòng kiểm tra lại!" });
            }

            // Nếu người dùng chọn vai trò cụ thể khi đăng nhập, kiểm tra tính tương thích
            if (!string.IsNullOrWhiteSpace(model.Role) && !string.Equals(user.Role, model.Role, StringComparison.OrdinalIgnoreCase))
            {
                // Cho phép Admin đăng nhập vào bất kỳ tab nào
                if (user.Role != "Admin")
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = $"Tài khoản này có vai trò là '{user.RoleTitle}', không thuộc nhóm '{GetRoleLabel(model.Role)}'."
                    });
                }
            }

            // Lưu thông tin vào Session
            SetSessionUser(user);

            // Điều hướng dựa theo vai trò riêng biệt
            string redirectUrl = user.Role switch
            {
                "Admin" => "/Admin/Dashboard",
                "Doctor" => "/Doctor/Dashboard",
                "Staff" => "/Staff/Dashboard",
                "Customer" => "/CustomerPortal/Index",
                _ => "/"
            };

            return Ok(new
            {
                success = true,
                message = $"Đăng nhập thành công! Chào mừng {user.FullName} ({user.RoleTitle}).",
                redirectUrl = redirectUrl,
                user = new
                {
                    id = user.Id,
                    fullName = user.FullName,
                    email = user.Email,
                    phone = user.Phone,
                    role = user.Role,
                    roleTitle = user.RoleTitle,
                    avatarInitials = user.AvatarInitials,
                    avatarColor = user.AvatarColor
                }
            });
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            if (model == null)
            {
                return BadRequest(new { success = false, message = "Dữ liệu đăng ký không hợp lệ." });
            }

            if (string.IsNullOrWhiteSpace(model.FullName))
                return BadRequest(new { success = false, message = "Vui lòng nhập họ và tên." });

            if (string.IsNullOrWhiteSpace(model.Email) || !model.Email.Contains("@"))
                return BadRequest(new { success = false, message = "Địa chỉ email không hợp lệ." });

            if (string.IsNullOrWhiteSpace(model.Phone))
                return BadRequest(new { success = false, message = "Vui lòng nhập số điện thoại liên hệ." });

            if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 6)
                return BadRequest(new { success = false, message = "Mật khẩu phải có tối thiểu 6 ký tự." });

            if (model.Password != model.ConfirmPassword)
                return BadRequest(new { success = false, message = "Mật khẩu xác nhận không khớp." });

            var emailClean = model.Email.Trim().ToLower();
            if (_users.Any(u => u.Email.ToLower() == emailClean))
            {
                return Conflict(new { success = false, message = "Email này đã được sử dụng. Vui lòng đăng nhập hoặc dùng email khác." });
            }

            string role = string.IsNullOrWhiteSpace(model.Role) ? "Customer" : model.Role.Trim();
            string roleTitle = "Khách hàng Thân thiết";
            string avatarColor = "#d48806";

            // Kiểm tra phân quyền đăng ký
            if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(model.AdminAccessCode) || model.AdminAccessCode.Trim() != AdminPasscode)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Mã xác thực Quản trị viên (Admin Passcode) không chính xác! Vui lòng liên hệ ban quản trị hoặc nhập mã mặc định: LUNASPA2026."
                    });
                }
                role = "Admin";
                roleTitle = "Quản trị viên hệ thống";
                avatarColor = "#a76d8e";
            }
            else if (string.Equals(role, "Doctor", StringComparison.OrdinalIgnoreCase))
            {
                role = "Doctor";
                roleTitle = string.IsNullOrWhiteSpace(model.Specialty) ? "Bác sĩ Chuyên khoa Da liễu" : model.Specialty;
                avatarColor = "#2b7bb9";
            }
            else if (string.Equals(role, "Staff", StringComparison.OrdinalIgnoreCase))
            {
                role = "Staff";
                roleTitle = string.IsNullOrWhiteSpace(model.Specialty) ? "Kỹ thuật viên Trị liệu Spa" : model.Specialty;
                avatarColor = "#3da58a";
            }
            else
            {
                role = "Customer";
                roleTitle = "Khách hàng VIP Thân thiết";
                avatarColor = "#d48806";
            }

            var initials = GenerateInitials(model.FullName);

            var newUser = new UserAccount
            {
                Id = _users.Max(u => u.Id) + 1,
                FullName = model.FullName.Trim(),
                Email = emailClean,
                Phone = model.Phone.Trim(),
                Password = model.Password,
                Role = role,
                RoleTitle = roleTitle,
                AvatarInitials = initials,
                AvatarColor = avatarColor,
                Specialty = model.Specialty?.Trim() ?? string.Empty,
                SkinConcern = model.SkinConcern?.Trim() ?? string.Empty,
                CreatedDate = DateTime.Now
            };

            _users.Add(newUser);
            SetSessionUser(newUser);

            string redirectUrl = newUser.Role switch
            {
                "Admin" => "/Admin/Dashboard",
                "Doctor" => "/Doctor/Dashboard",
                "Staff" => "/Staff/Dashboard",
                "Customer" => "/CustomerPortal/Index",
                _ => "/"
            };

            return Ok(new
            {
                success = true,
                message = $"Đăng ký tài khoản thành công! Chào mừng {newUser.FullName} gia nhập LUNA SPA.",
                redirectUrl = redirectUrl,
                user = new
                {
                    id = newUser.Id,
                    fullName = newUser.FullName,
                    email = newUser.Email,
                    phone = newUser.Phone,
                    role = newUser.Role,
                    roleTitle = newUser.RoleTitle,
                    avatarInitials = newUser.AvatarInitials,
                    avatarColor = newUser.AvatarColor
                }
            });
        }

        // POST / GET: /Account/Logout
        [HttpPost]
        [HttpGet]
        public IActionResult Logout()
        {
            var user = GetSessionUser();
            HttpContext.Session.Clear();

            // Nếu request gửi từ AJAX / Fetch API
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest" || Request.Headers["Accept"].ToString().Contains("application/json"))
            {
                return Ok(new
                {
                    success = true,
                    message = "Đã đăng xuất tài khoản thành công.",
                    redirectUrl = "/"
                });
            }

            return RedirectToAction("Index", "Home");
        }

        // POST: /Account/QuickLogin (Đăng nhập demo 1-click cho người dùng trải nghiệm nhanh)
        [HttpPost]
        public IActionResult QuickLogin([FromBody] QuickLoginRequest request)
        {
            string targetRole = NormalizeRole(request?.Role);
            var user = _users.FirstOrDefault(u => string.Equals(u.Role, targetRole, StringComparison.OrdinalIgnoreCase))
                       ?? _users.First();

            SetSessionUser(user);

            string redirectUrl = user.Role switch
            {
                "Admin" => "/Admin/Dashboard",
                "Doctor" => "/Doctor/Dashboard",
                "Staff" => "/Staff/Dashboard",
                "Customer" => "/CustomerPortal/Index",
                _ => "/"
            };

            return Ok(new
            {
                success = true,
                message = $"Đã đăng nhập nhanh với vai trò: {user.RoleTitle} ({user.FullName}).",
                redirectUrl = redirectUrl,
                user = new
                {
                    id = user.Id,
                    fullName = user.FullName,
                    email = user.Email,
                    role = user.Role,
                    roleTitle = user.RoleTitle,
                    avatarInitials = user.AvatarInitials,
                    avatarColor = user.AvatarColor
                }
            });
        }

        // GET: /Account/QuickLoginDirect?role=Staff (Đăng nhập trực tiếp qua link URL)
        [HttpGet]
        public IActionResult QuickLoginDirect(string role = "Admin")
        {
            string targetRole = NormalizeRole(role);
            var user = _users.FirstOrDefault(u => string.Equals(u.Role, targetRole, StringComparison.OrdinalIgnoreCase))
                       ?? _users.First();

            SetSessionUser(user);

            string redirectUrl = user.Role switch
            {
                "Admin" => "/Admin/Dashboard",
                "Doctor" => "/Doctor/Dashboard",
                "Staff" => "/Staff/Dashboard",
                "Customer" => "/CustomerPortal/Index",
                _ => "/"
            };

            return Redirect(redirectUrl);
        }

        private static string NormalizeRole(string? input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "Admin";
            var raw = input.Trim();

            if (raw.Equals("Staff", StringComparison.OrdinalIgnoreCase) ||
                raw.Equals("NhanVien", StringComparison.OrdinalIgnoreCase) ||
                raw.Equals("Nhân viên", StringComparison.OrdinalIgnoreCase) ||
                raw.Equals("KTV", StringComparison.OrdinalIgnoreCase) ||
                raw.Equals("Employee", StringComparison.OrdinalIgnoreCase))
            {
                return "Staff";
            }

            if (raw.Equals("Customer", StringComparison.OrdinalIgnoreCase) ||
                raw.Equals("KhachHang", StringComparison.OrdinalIgnoreCase) ||
                raw.Equals("Khách hàng", StringComparison.OrdinalIgnoreCase) ||
                raw.Equals("Member", StringComparison.OrdinalIgnoreCase) ||
                raw.Equals("Client", StringComparison.OrdinalIgnoreCase))
            {
                return "Customer";
            }

            if (raw.Equals("Doctor", StringComparison.OrdinalIgnoreCase) ||
                raw.Equals("BacSi", StringComparison.OrdinalIgnoreCase) ||
                raw.Equals("Bác sĩ", StringComparison.OrdinalIgnoreCase))
            {
                return "Doctor";
            }

            if (raw.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
                raw.Equals("QuanTri", StringComparison.OrdinalIgnoreCase) ||
                raw.Equals("QuanTriVien", StringComparison.OrdinalIgnoreCase) ||
                raw.Equals("Quản trị viên", StringComparison.OrdinalIgnoreCase) ||
                raw.Equals("Quản trị", StringComparison.OrdinalIgnoreCase))
            {
                return "Admin";
            }

            return raw;
        }

        #region Helpers
        private UserAccount? GetSessionUser()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email)) return null;

            return _users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        }

        private void SetSessionUser(UserAccount user)
        {
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.FullName);
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserRole", user.Role);
            HttpContext.Session.SetString("UserRoleTitle", user.RoleTitle);
            HttpContext.Session.SetString("UserAvatarInitials", user.AvatarInitials);
            HttpContext.Session.SetString("UserAvatarColor", user.AvatarColor);
        }

        private static string GenerateInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return "KH";
            var parts = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1) return parts[0].Substring(0, Math.Min(2, parts[0].Length)).ToUpper();
            return $"{parts[0][0]}{parts[^1][0]}".ToUpper();
        }

        private static string GetRoleLabel(string role)
        {
            return role switch
            {
                "Admin" => "Quản trị viên",
                "Doctor" => "Bác sĩ Da liễu",
                "Staff" => "Kỹ thuật viên / Nhân viên",
                "Customer" => "Khách hàng VIP",
                _ => role
            };
        }
        #endregion
    }

    public class QuickLoginRequest
    {
        public string Role { get; set; } = "Admin";
    }
}
