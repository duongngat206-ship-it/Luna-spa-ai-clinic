using System;

namespace GiaoDienSpa.Models
{
    public class InventoryItem
    {
        public int ProductId { get; set; }

        public string Sku { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty; // SkinCeuticals, La Roche-Posay, Sulwhasoo, Luna Botanic...

        public string Category { get; set; } = string.Empty; // Chăm sóc da, Serum đặc trị, Mặt nạ sinh học, Tinh dầu thảo mộc, Kem dưỡng

        public int Quantity { get; set; } // Số lượng tồn thực tế

        public int MinQuantity { get; set; } = 10; // Định mức tồn tối thiểu

        public string Unit { get; set; } = "Chai"; // Chai, Lọ, Hộp, Tuýp, Bộ

        public decimal CostPrice { get; set; } // Giá nhập

        public decimal UnitPrice { get; set; } // Giá bán lẻ / áp dụng liệu trình

        public DateTime ExpiryDate { get; set; } = DateTime.Now.AddMonths(12);

        public string Supplier { get; set; } = string.Empty;

        public string Status { get; set; } = "Còn hàng"; // Còn hàng, Sắp hết hàng, Hết hàng, Cận date

        public int MonthlyUsageRate { get; set; } = 0; // Tốc độ tiêu thụ / tháng

        public string AiPrediction { get; set; } = string.Empty; // AI dự báo (Ví dụ: "Dự kiến hết sau 6 ngày")
    }
}