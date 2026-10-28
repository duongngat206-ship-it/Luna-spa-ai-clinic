namespace GiaoDienSpa.Models
{
    public class SpaService
    {
        public int ServiceId { get; set; }

        public string ServiceCode { get; set; } = string.Empty;

        public string ServiceName { get; set; } = string.Empty;

        public string Category { get; set; } = "Chăm sóc da"; // Trẻ hóa công nghệ cao, Chăm sóc da chuyên sâu, Massage & Trị liệu, Chăm sóc body

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int DurationMinutes { get; set; } = 60;

        public string Icon { get; set; } = "✿";

        public string RecommendedCosmetics { get; set; } = string.Empty; // Mỹ phẩm khuyên dùng

        public string Status { get; set; } = "Đang cung cấp"; // Đang cung cấp, Tạm dừng

        public string AiSuitability { get; set; } = string.Empty; // Đánh giá độ phù hợp của AI
    }
}