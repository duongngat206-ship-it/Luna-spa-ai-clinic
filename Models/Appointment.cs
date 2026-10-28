using System;

namespace GiaoDienSpa.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public string AppointmentCode { get; set; } = string.Empty;

        public string CustomerName { get; set; } = string.Empty;

        public string CustomerPhone { get; set; } = string.Empty;

        public string ServiceName { get; set; } = string.Empty;

        public string StaffName { get; set; } = string.Empty; // Bác sĩ / Kỹ thuật viên

        public string RoomName { get; set; } = "Phòng Trị liệu 01"; // Phòng VIP 1, Phòng Laser, Phòng Massage...

        public DateTime AppointmentDate { get; set; } = DateTime.Today;

        public string AppointmentTime { get; set; } = "09:00"; // 09:00, 10:30, 14:00...

        public int DurationMinutes { get; set; } = 60;

        public string Status { get; set; } = "Chờ xác nhận"; // Đã xác nhận, Chờ xác nhận, Đang phục vụ, Đã hoàn thành, Đã hủy

        public string Note { get; set; } = string.Empty;

        public string AiReminderStatus { get; set; } = "Đã gửi nhắc lịch Zalo"; // Trạng thái AI tự động nhắc lịch

        public string? ApprovedBy { get; set; } = "Quản trị viên"; // Người duyệt lịch hẹn

        public DateTime? ApprovedAt { get; set; } // Thời gian duyệt

        public string? AdminApprovalNote { get; set; } // Ghi chú duyệt của Admin
    }
}