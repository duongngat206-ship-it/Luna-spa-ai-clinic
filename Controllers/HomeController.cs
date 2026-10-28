using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GiaoDienSpa.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiaoDienSpa.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Appointment> _recentAppointments = new List<Appointment>
        {
            new Appointment
            {
                AppointmentId = 1,
                AppointmentCode = "LH-20261027-01",
                CustomerName = "Nguyễn Thị Minh Anh",
                CustomerPhone = "0987 654 321",
                ServiceName = "Trẻ hóa da Laser Pico Pro",
                StaffName = "Bác sĩ Lê Hoàng Yến",
                RoomName = "Phòng Laser Công nghệ cao",
                AppointmentDate = DateTime.Today,
                AppointmentTime = "09:30",
                Status = "Đang phục vụ",
                AiReminderStatus = "Khách đã đến đúng giờ"
            },
            new Appointment
            {
                AppointmentId = 2,
                AppointmentCode = "LH-20261027-02",
                CustomerName = "Trần Thu Hà",
                CustomerPhone = "0912 345 678",
                ServiceName = "Chăm sóc da chuyên sâu Aqua Detox",
                StaffName = "Nguyễn Thu Trang (KTV Trưởng)",
                RoomName = "Phòng Trị liệu VIP 01",
                AppointmentDate = DateTime.Today,
                AppointmentTime = "11:00",
                Status = "Đã xác nhận",
                AiReminderStatus = "Đã gửi SMS nhắc hẹn"
            },
            new Appointment
            {
                AppointmentId = 3,
                AppointmentCode = "LH-20261027-03",
                CustomerName = "Lê Hoàng Nam",
                CustomerPhone = "0905 123 456",
                ServiceName = "Massage Thảo Dược Cổ Vai Gáy (60p)",
                StaffName = "Đặng Thùy Dung (KTV)",
                RoomName = "Phòng Thư giãn Body 02",
                AppointmentDate = DateTime.Today,
                AppointmentTime = "14:00",
                Status = "Chờ phục vụ",
                AiReminderStatus = "Đã check-in hệ thống"
            },
            new Appointment
            {
                AppointmentId = 4,
                AppointmentCode = "LH-20261027-04",
                CustomerName = "Vũ Bích Ngọc",
                CustomerPhone = "0934 999 888",
                ServiceName = "Nâng cơ trẻ hóa Hifu Ultra Collagen",
                StaffName = "Bác sĩ Lê Hoàng Yến",
                RoomName = "Phòng Trẻ hóa Hifu VIP",
                AppointmentDate = DateTime.Today,
                AppointmentTime = "15:30",
                Status = "Chờ phục vụ",
                AiReminderStatus = "Khách đặt trước 2 ngày"
            }
        };

        // GET: / (Giao diện tổng quan bên ngoài công khai)
        public IActionResult Index()
        {
            ViewBag.IsPublicPage = true;
            ViewBag.CurrentUserName = HttpContext.Session.GetString("UserName");
            ViewBag.CurrentUserRole = HttpContext.Session.GetString("UserRole");
            ViewBag.CurrentUserRoleTitle = HttpContext.Session.GetString("UserRoleTitle");
            ViewBag.CurrentUserAvatar = HttpContext.Session.GetString("UserAvatarInitials");

            return View();
        }

        // GET: /Home/Dashboard (Bảng điều khiển quản trị nội bộ dành cho Admin & Staff)
        public IActionResult Dashboard()
        {
            ViewBag.IsPublicPage = false;
            ViewBag.TotalCustomers = 142;
            ViewBag.TotalAppointments = 18;
            ViewBag.TotalServices = 12;
            ViewBag.MonthlyRevenue = 68500000;
            ViewBag.WeeklyGrowthRate = 18.5;
            ViewBag.RoomOccupancyRate = 88;

            ViewBag.CurrentUserName = HttpContext.Session.GetString("UserName") ?? "Quản trị viên";
            ViewBag.CurrentUserRole = HttpContext.Session.GetString("UserRole") ?? "Admin";
            ViewBag.CurrentUserRoleTitle = HttpContext.Session.GetString("UserRoleTitle") ?? "Quản trị viên cấp cao";
            ViewBag.CurrentUserAvatar = HttpContext.Session.GetString("UserAvatarInitials") ?? "AD";

            return View(_recentAppointments);
        }

        // POST: /Home/BookConsultation (Đặt lịch hẹn hoặc đăng ký khám da AI từ giao diện ngoài)
        [HttpPost]
        public IActionResult BookConsultation([FromBody] QuickConsultationRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.CustomerName) || string.IsNullOrWhiteSpace(request.Phone))
            {
                return BadRequest(new { success = false, message = "Vui lòng nhập Họ tên và Số điện thoại." });
            }

            var newAppt = new Appointment
            {
                AppointmentId = _recentAppointments.Max(a => a.AppointmentId) + 1,
                AppointmentCode = $"LH-{DateTime.Today:yyyyMMdd}-{_recentAppointments.Count + 1:D2}",
                CustomerName = request.CustomerName.Trim(),
                CustomerPhone = request.Phone.Trim(),
                ServiceName = string.IsNullOrWhiteSpace(request.ServiceName) ? "Khám da & Tư vấn phác đồ AI" : request.ServiceName,
                StaffName = "Bác sĩ Lê Hoàng Yến",
                RoomName = "Phòng Tư vấn Da liễu AI",
                AppointmentDate = DateTime.Today.AddDays(1),
                AppointmentTime = request.PreferredTime ?? "10:00",
                Status = "Chờ xác nhận",
                AiReminderStatus = "Khách đăng ký trực tuyến từ Website",
                Note = request.Note ?? "Đăng ký tư vấn trực tuyến"
            };

            _recentAppointments.Insert(0, newAppt);

            return Ok(new
            {
                success = true,
                message = $"Đăng ký thành công! Chuyên viên LUNA SPA sẽ liên hệ tới số {request.Phone} trong vòng 10 phút.",
                appointmentCode = newAppt.AppointmentCode
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }

    public class QuickConsultationRequest
    {
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public string PreferredTime { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }
}