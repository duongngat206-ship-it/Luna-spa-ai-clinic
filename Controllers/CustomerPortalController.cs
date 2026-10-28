using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace GiaoDienSpa.Controllers
{
    public class CustomerPortalController : Controller
    {
        // Mock dữ liệu liệu trình cá nhân của khách hàng VIP
        private static readonly List<CustomerAppointmentItem> _myAppointments = new List<CustomerAppointmentItem>
        {
            new CustomerAppointmentItem 
            { 
                Id = 1, 
                DateTimeStr = "30/10/2026 - 14:00", 
                ServiceName = "Laser Pico Trị Tàn Nhang (Buổi 4/5)", 
                DoctorName = "BS. CKI Lê Hoàng Yến", 
                RoomName = "Phòng Laser Công Nghệ Cao (P.Laser 01)", 
                Status = "Đã xác nhận", 
                Note = "Bác sĩ dặn kiêng nắng gắt, đắp mặt nạ lạnh trước khi đến 1 tiếng." 
            },
            new CustomerAppointmentItem 
            { 
                Id = 2, 
                DateTimeStr = "15/10/2026 - 09:30", 
                ServiceName = "Laser Pico Trị Tàn Nhang (Buổi 3/5)", 
                DoctorName = "BS. CKI Lê Hoàng Yến", 
                RoomName = "Phòng Laser 01", 
                Status = "Đã hoàn thành", 
                Note = "Bắn mức xung 3.2J làm mờ vết nám tầng nông gò má. Phản ứng da dịu tốt." 
            },
            new CustomerAppointmentItem 
            { 
                Id = 3, 
                DateTimeStr = "28/09/2026 - 15:00", 
                ServiceName = "Aqua Detox & Quét Da AI Chuyên Sâu", 
                DoctorName = "BS. CKI Lê Hoàng Yến", 
                RoomName = "Phòng VIP 01", 
                Status = "Đã hoàn thành", 
                Note = "Khởi tạo phác đồ da liễu cá nhân hóa kết hợp Laser Pico." 
            }
        };

        // Danh sách voucher của khách hàng
        private static readonly List<CustomerVoucherItem> _myVouchers = new List<CustomerVoucherItem>
        {
            new CustomerVoucherItem
            {
                Code = "LUNA-VIP-BDAY20",
                Title = "Ưu đãi Sinh nhật Tháng 10 - Giảm 20%",
                DiscountDesc = "Giảm 20% tổng hóa đơn Trẻ hóa Hifu & Laser Pico",
                ExpiryDate = "31/11/2026",
                IsUsed = false,
                Tag = "SINH NHẬT"
            },
            new CustomerVoucherItem
            {
                Code = "LUNA-FREE-AQUA",
                Title = "Đặc Quyền Diamond: Tặng 1 Buổi Aqua Detox",
                DiscountDesc = "Tặng 01 buổi thanh lọc da đa tầng trị giá 650.000đ",
                ExpiryDate = "Vô thời hạn",
                IsUsed = false,
                Tag = "ĐẶC QUYỀN VIP"
            },
            new CustomerVoucherItem
            {
                Code = "LUNA-SERUM-100K",
                Title = "Voucher Dược Mỹ Phẩm 100K",
                DiscountDesc = "Giảm 100.000đ khi mua Serum HA B5 phục hồi tại quầy",
                ExpiryDate = "15/12/2026",
                IsUsed = true,
                Tag = "MỸ PHẨM"
            }
        };

        // Skincare Habit Tracker hàng ngày (Routine hôm nay)
        private static readonly List<SkincareHabitStep> _todayHabits = new List<SkincareHabitStep>
        {
            new SkincareHabitStep { Id = 1, Period = "Sáng (AM)", StepName = "Sữa Rửa Mặt Amino Acid Dịu Nhẹ", IsCompleted = true, TimeDone = "07:15" },
            new SkincareHabitStep { Id = 2, Period = "Sáng (AM)", StepName = "Serum Hyaluronic Acid B5 Đa Tầng", IsCompleted = true, TimeDone = "07:20" },
            new SkincareHabitStep { Id = 3, Period = "Sáng (AM)", StepName = "Kem Chống Nắng Khoáng SPF50+ PA++++", IsCompleted = true, TimeDone = "07:25" },
            new SkincareHabitStep { Id = 4, Period = "Tối (PM)", StepName = "Nước Tẩy Trang Sinh Học Micellar", IsCompleted = false, TimeDone = "--:--" },
            new SkincareHabitStep { Id = 5, Period = "Tối (PM)", StepName = "Mặt Nạ Tế Bào Gốc Sinh Học (20 phút)", IsCompleted = false, TimeDone = "--:--" },
            new SkincareHabitStep { Id = 6, Period = "Tối (PM)", StepName = "Kem Dưỡng Tái Tạo Ceramide & Niacinamide", IsCompleted = false, TimeDone = "--:--" }
        };

        // GET: /CustomerPortal/Index (Cổng hội viên VIP)
        public IActionResult Index()
        {
            ViewBag.CustomerName = HttpContext.Session.GetString("UserName") ?? "Nguyễn Thị Minh Anh";
            ViewBag.UserEmail = HttpContext.Session.GetString("UserEmail") ?? "khachhang@gmail.com";
            ViewBag.MemberRank = "VIP Kim Cương (Diamond)";
            ViewBag.RewardPoints = 2850;
            ViewBag.ActiveCourse = "Trị Nám Tầng Sâu Laser Pico Star";
            ViewBag.CourseProgress = 60; // 3/5 sessions
            ViewBag.AvailableVouchersCount = _myVouchers.Count(v => !v.IsUsed);

            return View(_myAppointments);
        }

        // GET: /CustomerPortal/Appointments (Lịch hẹn của tôi & Đặt lịch online)
        public IActionResult Appointments()
        {
            ViewBag.CustomerName = HttpContext.Session.GetString("UserName") ?? "Nguyễn Thị Minh Anh";
            return View(_myAppointments);
        }

        // GET: /CustomerPortal/History (Nhật ký cải thiện da AI)
        public IActionResult History()
        {
            ViewBag.CustomerName = HttpContext.Session.GetString("UserName") ?? "Nguyễn Thị Minh Anh";
            return View();
        }

        // GET: /CustomerPortal/MyPrescriptions (Toa mỹ phẩm tại nhà & Habit Tracker)
        public IActionResult MyPrescriptions()
        {
            ViewBag.CustomerName = HttpContext.Session.GetString("UserName") ?? "Nguyễn Thị Minh Anh";
            ViewBag.Habits = _todayHabits;
            return View();
        }

        // GET: /CustomerPortal/Vouchers (Ví Voucher & Đổi điểm)
        public IActionResult Vouchers()
        {
            ViewBag.CustomerName = HttpContext.Session.GetString("UserName") ?? "Nguyễn Thị Minh Anh";
            ViewBag.RewardPoints = 2850;
            return View(_myVouchers);
        }

        // POST: /CustomerPortal/BookOnline
        [HttpPost]
        public IActionResult BookOnline([FromBody] CustomerBookRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.ServiceName))
            {
                return BadRequest(new { success = false, message = "Vui lòng chọn dịch vụ và thời gian đặt hẹn." });
            }

            var newItem = new CustomerAppointmentItem
            {
                Id = _myAppointments.Count + 1,
                DateTimeStr = $"{request.BookingDate} - {request.BookingTime}",
                ServiceName = request.ServiceName,
                DoctorName = string.IsNullOrWhiteSpace(request.DoctorName) ? "BS. CKI Lê Hoàng Yến" : request.DoctorName,
                RoomName = "Phòng Trị Liệu VIP",
                Status = "Đã xác nhận",
                Note = string.IsNullOrWhiteSpace(request.Note) ? "Đặt lịch trực tuyến qua Cổng Hội Viên VIP" : request.Note
            };

            _myAppointments.Insert(0, newItem);

            return Ok(new
            {
                success = true,
                message = $"Chúc mừng Quý khách! Đã đặt lịch thành công dịch vụ '{request.ServiceName}' vào ngày {request.BookingDate} lúc {request.BookingTime}. Mã vé khám đã được gửi đến số điện thoại của bạn.",
                item = newItem
            });
        }

        // POST: /CustomerPortal/CancelAppointment
        [HttpPost]
        public IActionResult CancelAppointment([FromBody] CancelAppRequest request)
        {
            var app = _myAppointments.FirstOrDefault(a => a.Id == request.AppointmentId);
            if (app == null) return NotFound(new { success = false, message = "Không tìm thấy lịch hẹn." });

            app.Status = "Đã hủy theo yêu cầu";
            app.Note += " (Khách đã báo hủy trước 2 tiếng)";

            return Ok(new { success = true, message = "Đã hủy lịch hẹn thành công. Quý khách có thể đặt lại bất cứ lúc nào." });
        }

        // POST: /CustomerPortal/ToggleHabit
        [HttpPost]
        public IActionResult ToggleHabit([FromBody] HabitToggleRequest request)
        {
            var habit = _todayHabits.FirstOrDefault(h => h.Id == request.HabitId);
            if (habit != null)
            {
                habit.IsCompleted = !habit.IsCompleted;
                habit.TimeDone = habit.IsCompleted ? DateTime.Now.ToString("HH:mm") : "--:--";
            }
            return Ok(new { success = true, habit = habit });
        }

        // POST: /CustomerPortal/RedeemPoints
        [HttpPost]
        public IActionResult RedeemPoints([FromBody] RedeemRequest request)
        {
            var code = "LUNA-REDEEM-" + DateTime.Now.ToString("mmss");
            var newVoucher = new CustomerVoucherItem
            {
                Code = code,
                Title = request.RewardTitle ?? "Voucher Giảm 15% Dịch Vụ Spa",
                DiscountDesc = "Áp dụng cho mọi liệu trình chăm sóc da",
                ExpiryDate = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy"),
                IsUsed = false,
                Tag = "ĐỔI ĐIỂM"
            };
            _myVouchers.Insert(0, newVoucher);

            return Ok(new
            {
                success = true,
                message = $"Đã đổi thành công 500 điểm lấy voucher '{newVoucher.Title}'! Mã voucher: {code}",
                voucher = newVoucher
            });
        }

        // POST: /CustomerPortal/SubmitReview
        [HttpPost]
        public IActionResult SubmitReview([FromBody] ReviewRequest request)
        {
            return Ok(new
            {
                success = true,
                message = "Cảm ơn Quý khách đã gửi đánh giá! Luna Clinic đã cộng thêm +50 điểm thưởng Luna Point vào tài khoản của bạn."
            });
        }
    }

    public class CustomerAppointmentItem
    {
        public int Id { get; set; }
        public string DateTimeStr { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string RoomName { get; set; } = string.Empty;
        public string Status { get; set; } = "Đã xác nhận"; // "Đã xác nhận", "Đã hoàn thành", "Đã hủy theo yêu cầu"
        public string Note { get; set; } = string.Empty;
    }

    public class CustomerVoucherItem
    {
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string DiscountDesc { get; set; } = string.Empty;
        public string ExpiryDate { get; set; } = string.Empty;
        public bool IsUsed { get; set; } = false;
        public string Tag { get; set; } = "ƯU ĐÃI";
    }

    public class SkincareHabitStep
    {
        public int Id { get; set; }
        public string Period { get; set; } = "Sáng (AM)";
        public string StepName { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public string TimeDone { get; set; } = "--:--";
    }

    public class CustomerBookRequest
    {
        public string ServiceName { get; set; } = string.Empty;
        public string BookingDate { get; set; } = string.Empty;
        public string BookingTime { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }

    public class CancelAppRequest
    {
        public int AppointmentId { get; set; }
    }

    public class HabitToggleRequest
    {
        public int HabitId { get; set; }
    }

    public class RedeemRequest
    {
        public string RewardTitle { get; set; } = string.Empty;
        public int PointsNeeded { get; set; } = 500;
    }

    public class ReviewRequest
    {
        public int Rating { get; set; } = 5;
        public string Comment { get; set; } = string.Empty;
    }
}
