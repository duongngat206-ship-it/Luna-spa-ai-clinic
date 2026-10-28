using Microsoft.AspNetCore.Mvc;
using GiaoDienSpa.Models;
using System;

namespace GiaoDienSpa.Controllers
{
    public class AdminController : Controller
    {
        private static AdminProfile _currentProfile = new AdminProfile
        {
            FullName = "Nguyễn Quản Trị",
            RoleTitle = "Administrator",
            Email = "admin@lunaspa.vn",
            Phone = "0988 888 999",
            AvatarInitials = "AD",
            AvatarColor = "#a76d8e",
            Bio = "Tận tâm chăm sóc sức khỏe & sắc đẹp cho khách hàng theo chuẩn quốc tế 5 sao.",
            RoleBadge = "Quản trị viên tối cao (Full Access)",
            LastUpdated = DateTime.Now
        };

        // GET: /Admin/Dashboard
        public IActionResult Dashboard()
        {
            ViewBag.TotalCustomers = 142;
            ViewBag.TotalAppointments = 18;
            ViewBag.TotalServices = 12;
            ViewBag.MonthlyRevenue = 148500000;
            ViewBag.WeeklyGrowthRate = 18.5;
            ViewBag.RoomOccupancyRate = 92;
            ViewBag.ProfitMargin = 60.1;
            ViewBag.ActiveStaffCount = 14;

            return View();
        }

        [HttpGet]
        public IActionResult GetProfile()
        {
            return Json(new { success = true, profile = _currentProfile });
        }

        [HttpPost]
        public IActionResult UpdateProfile([FromBody] AdminProfile profile)
        {
            if (profile == null)
            {
                return BadRequest(new { success = false, message = "Dữ liệu hồ sơ không hợp lệ." });
            }

            if (!string.IsNullOrWhiteSpace(profile.FullName))
                _currentProfile.FullName = profile.FullName.Trim();

            if (!string.IsNullOrWhiteSpace(profile.RoleTitle))
                _currentProfile.RoleTitle = profile.RoleTitle.Trim();

            if (!string.IsNullOrWhiteSpace(profile.Email))
                _currentProfile.Email = profile.Email.Trim();

            if (!string.IsNullOrWhiteSpace(profile.Phone))
                _currentProfile.Phone = profile.Phone.Trim();

            if (!string.IsNullOrWhiteSpace(profile.AvatarInitials))
                _currentProfile.AvatarInitials = profile.AvatarInitials.Trim().ToUpper();

            if (!string.IsNullOrWhiteSpace(profile.AvatarColor))
                _currentProfile.AvatarColor = profile.AvatarColor.Trim();

            if (!string.IsNullOrWhiteSpace(profile.Bio))
                _currentProfile.Bio = profile.Bio.Trim();

            if (!string.IsNullOrWhiteSpace(profile.RoleBadge))
                _currentProfile.RoleBadge = profile.RoleBadge.Trim();

            _currentProfile.LastUpdated = DateTime.Now;

            return Ok(new
            {
                success = true,
                message = "Cập nhật hồ sơ Quản trị viên thành công!",
                profile = _currentProfile
            });
        }

        public static void SyncFromUser(UserAccount user)
        {
            if (user == null) return;
            _currentProfile.FullName = user.FullName;
            _currentProfile.RoleTitle = user.RoleTitle;
            _currentProfile.Email = user.Email;
            _currentProfile.Phone = user.Phone;
            _currentProfile.AvatarInitials = user.AvatarInitials;
            _currentProfile.AvatarColor = user.AvatarColor;
            if (!string.IsNullOrWhiteSpace(user.Specialty))
            {
                _currentProfile.Bio = user.Specialty;
            }
            _currentProfile.LastUpdated = DateTime.Now;
        }
    }
}
