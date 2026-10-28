using Microsoft.AspNetCore.Mvc;
using GiaoDienSpa.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiaoDienSpa.Controllers
{
    public class AppointmentsController : Controller
    {
        private static List<Appointment> _appointments = new List<Appointment>
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
                DurationMinutes = 75,
                Status = "Đang phục vụ",
                Note = "Khách VIP Vàng. Chuẩn bị đầu máy Pico bước sóng 1064nm.",
                AiReminderStatus = "Khách đã đến & check-in quầy"
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
                DurationMinutes = 60,
                Status = "Đã xác nhận",
                Note = "Khách yêu cầu KTV Trang làm riêng.",
                AiReminderStatus = "Đã gửi tin Zalo & khách xác nhận đúng giờ"
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
                DurationMinutes = 60,
                Status = "Đã xác nhận",
                Note = "Khách đau nhiều vùng cơ thang vai trái.",
                AiReminderStatus = "Đã gửi SMS nhắc lịch 2 tiếng trước hẹn"
            },
            new Appointment
            {
                AppointmentId = 4,
                AppointmentCode = "LH-20261027-04",
                CustomerName = "Phạm Ngọc Mai",
                CustomerPhone = "0977 123 456",
                ServiceName = "Nâng cơ trẻ hóa Hifu Ultra Collagen",
                StaffName = "Bác sĩ Lê Hoàng Yến",
                RoomName = "Phòng Laser Công nghệ cao",
                AppointmentDate = DateTime.Today,
                AppointmentTime = "16:30",
                DurationMinutes = 90,
                Status = "Chờ xác nhận",
                Note = "Khách xin lùi lại 15 phút nếu kẹt xe.",
                AiReminderStatus = "Đang chờ khách phản hồi tin nhắn tự động"
            },
            new Appointment
            {
                AppointmentId = 5,
                AppointmentCode = "LH-20261027-05",
                CustomerName = "Đỗ Thanh Hương",
                CustomerPhone = "0966 123 456",
                ServiceName = "Trị mụn y khoa & Chiếu ánh sáng sinh học",
                StaffName = "Vũ Khánh Linh (KTV)",
                RoomName = "Phòng Trị mụn Y khoa",
                AppointmentDate = DateTime.Today,
                AppointmentTime = "18:00",
                DurationMinutes = 75,
                Status = "Đã xác nhận",
                Note = "Lấy nhân mụn buổi thứ 3.",
                AiReminderStatus = "Đã gọi điện xác nhận thành công"
            },
            new Appointment
            {
                AppointmentId = 6,
                AppointmentCode = "LH-20261027-06",
                CustomerName = "Hoàng Thu Trang",
                CustomerPhone = "0988 123 456",
                ServiceName = "Gội đầu dưỡng sinh Thảo dược Trung Hoa",
                StaffName = "Lâm Mỹ Duyên (KTV)",
                RoomName = "Phòng Gội Dưỡng sinh",
                AppointmentDate = DateTime.Today,
                AppointmentTime = "19:15",
                DurationMinutes = 45,
                Status = "Chờ xác nhận",
                Note = "Khách đặt lịch online qua ứng dụng.",
                AiReminderStatus = "Đã gửi thông báo nhắc lịch tự động"
            },
            new Appointment
            {
                AppointmentId = 7,
                AppointmentCode = "LH-20261026-07",
                CustomerName = "Vũ Đức Long",
                CustomerPhone = "0933 123 456",
                ServiceName = "Massage Thư Giãn Toàn Thân Đá Nóng",
                StaffName = "Đặng Thùy Dung (KTV)",
                RoomName = "Phòng Thư giãn Body 01",
                AppointmentDate = DateTime.Today.AddDays(-1),
                AppointmentTime = "15:00",
                DurationMinutes = 90,
                Status = "Đã hoàn thành",
                Note = "Khách đánh giá 5 sao cho KTV Dung.",
                AiReminderStatus = "Đã gửi phiếu khảo sát hài lòng sau dịch vụ"
            }
        };

        public IActionResult Index()
        {
            ViewBag.TotalAppointments = _appointments.Count;
            ViewBag.PendingAppointments = _appointments.Count(a => a.Status == "Chờ xác nhận");
            ViewBag.ConfirmedAppointments = _appointments.Count(a => a.Status == "Đã xác nhận" || a.Status == "Đang phục vụ");
            ViewBag.CompletedAppointments = _appointments.Count(a => a.Status == "Đã hoàn thành");

            return View(_appointments);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Appointment newApp)
        {
            if (newApp == null || string.IsNullOrWhiteSpace(newApp.CustomerName))
            {
                return BadRequest(new { success = false, message = "Thông tin lịch hẹn không hợp lệ." });
            }

            newApp.AppointmentId = _appointments.Any() ? _appointments.Max(a => a.AppointmentId) + 1 : 1;
            newApp.AppointmentCode = $"LH-{DateTime.Now:yyyyMMdd}-{newApp.AppointmentId:D02}";
            if (string.IsNullOrEmpty(newApp.Status)) newApp.Status = "Chờ xác nhận";
            if (string.IsNullOrEmpty(newApp.RoomName)) newApp.RoomName = "Phòng Trị liệu 01";
            newApp.AiReminderStatus = "Hệ thống AI đã xếp lịch & gửi tin nhắn xác nhận.";

            _appointments.Insert(0, newApp);
            return Ok(new { success = true, appointment = newApp });
        }

        [HttpPost]
        public IActionResult Update([FromBody] Appointment app)
        {
            var existing = _appointments.FirstOrDefault(a => a.AppointmentId == app.AppointmentId);
            if (existing == null)
            {
                return NotFound(new { success = false, message = "Không tìm thấy lịch hẹn." });
            }

            existing.CustomerName = app.CustomerName;
            existing.CustomerPhone = app.CustomerPhone;
            existing.ServiceName = app.ServiceName;
            existing.StaffName = app.StaffName;
            existing.RoomName = app.RoomName;
            existing.AppointmentDate = app.AppointmentDate;
            existing.AppointmentTime = app.AppointmentTime;
            existing.DurationMinutes = app.DurationMinutes;
            existing.Status = app.Status;
            existing.Note = app.Note;

            return Ok(new { success = true, appointment = existing });
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, string status, string? note = null, string? approvedBy = null)
        {
            var app = _appointments.FirstOrDefault(a => a.AppointmentId == id);
            if (app == null)
            {
                return NotFound(new { success = false, message = "Không tìm thấy lịch hẹn." });
            }

            app.Status = status;
            app.ApprovedBy = string.IsNullOrWhiteSpace(approvedBy) ? "Quản trị viên" : approvedBy;
            app.ApprovedAt = DateTime.Now;

            if (!string.IsNullOrWhiteSpace(note))
            {
                app.AdminApprovalNote = note;
            }

            if (status == "Đã xác nhận")
            {
                app.AiReminderStatus = "Admin đã duyệt • Đã xếp phòng & gửi SMS xác nhận";
            }
            else if (status == "Đang phục vụ")
            {
                app.AiReminderStatus = "Khách đang trong phòng trị liệu";
            }
            else if (status == "Đã hoàn thành")
            {
                app.AiReminderStatus = "Hoàn tất liệu trình • Chuyển thu ngân";
            }
            else if (status == "Đã hủy")
            {
                app.AiReminderStatus = "Lịch đã hủy bởi Quản trị viên";
            }

            return Ok(new
            {
                success = true,
                message = $"Đã duyệt và cập nhật trạng thái lịch hẹn thành '{status}'",
                appointment = app
            });
        }

        [HttpPost]
        public IActionResult UpdateStatusJson([FromBody] AppointmentStatusDto dto)
        {
            if (dto == null)
            {
                return BadRequest(new { success = false, message = "Dữ liệu trạng thái không hợp lệ." });
            }
            return UpdateStatus(dto.Id, dto.Status, dto.Note, dto.ApprovedBy);
        }

        [HttpPost]
        public IActionResult BatchApprove([FromBody] BatchApprovalDto dto)
        {
            if (dto == null || dto.Ids == null || dto.Ids.Count == 0)
            {
                return BadRequest(new { success = false, message = "Danh sách lịch hẹn cần duyệt trống." });
            }

            var updatedList = new List<Appointment>();
            foreach (var id in dto.Ids)
            {
                var app = _appointments.FirstOrDefault(a => a.AppointmentId == id);
                if (app != null)
                {
                    app.Status = dto.Status ?? "Đã xác nhận";
                    app.ApprovedBy = "Quản trị viên";
                    app.ApprovedAt = DateTime.Now;
                    if (!string.IsNullOrWhiteSpace(dto.Note))
                    {
                        app.AdminApprovalNote = dto.Note;
                    }
                    app.AiReminderStatus = "Admin đã duyệt hàng loạt • Đã xếp phòng";
                    updatedList.Add(app);
                }
            }

            return Ok(new
            {
                success = true,
                message = $"Đã duyệt thành công {updatedList.Count} lịch hẹn!",
                updatedCount = updatedList.Count
            });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var app = _appointments.FirstOrDefault(a => a.AppointmentId == id);
            if (app != null)
            {
                _appointments.Remove(app);
                return Ok(new { success = true });
            }
            return NotFound(new { success = false, message = "Không tìm thấy lịch hẹn." });
        }

        [HttpGet]
        public IActionResult AiScheduleOptimization()
        {
            var todayAppointments = _appointments.Where(a => a.AppointmentDate.Date == DateTime.Today.Date).ToList();
            var analysis = new
            {
                analysisDate = DateTime.Today.ToString("dd/MM/yyyy"),
                totalToday = todayAppointments.Count,
                roomCapacity = "Phòng Laser Công nghệ cao hoạt động 90% công suất trong khung 15:00 - 18:30.",
                conflictStatus = "Không có xung đột trùng phòng hoặc trùng chuyên viên trị liệu.",
                aiAutoReminders = "6/6 khách hẹn hôm nay đã nhận được tin nhắn nhắc lịch tự động kèm đường link chỉ đường.",
                suggestion = "Đề xuất chuẩn bị phòng Laser trước 16:15 để đón tiếp khách VIP Phạm Ngọc Mai đúng chuẩn lễ nghi 5 sao."
            };

            return Json(analysis);
        }
    }

    public class AppointmentStatusDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Note { get; set; }
        public string? ApprovedBy { get; set; }
    }

    public class BatchApprovalDto
    {
        public System.Collections.Generic.List<int> Ids { get; set; } = new System.Collections.Generic.List<int>();
        public string Status { get; set; } = "Đã xác nhận";
        public string? Note { get; set; }
    }
}