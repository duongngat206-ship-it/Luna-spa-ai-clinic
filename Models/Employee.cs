namespace GiaoDienSpa.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeCode { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty; // Quản lý, Kỹ thuật viên, Bác sĩ da liễu, Lễ tân, Tư vấn viên

        public string Specialization { get; set; } = string.Empty; // Trẻ hóa da, Trị mụn chuyên sâu, Massage Body, Laser & Triệt lông

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int ExperienceYears { get; set; } = 1;

        public double Rating { get; set; } = 5.0; // 4.8, 4.9, 5.0

        public int CompletedSessions { get; set; } = 0; // Số ca trị liệu đã thực hiện

        public string Shift { get; set; } = "Ca sáng (08:30 - 16:30)"; // Ca sáng, Ca chiều, Toàn thời gian

        public string Status { get; set; } = "Đang làm việc"; // Đang làm việc, Đang trong ca, Tạm nghỉ

        public string AiScoreNote { get; set; } = string.Empty; // Đánh giá đề xuất của AI
    }
}