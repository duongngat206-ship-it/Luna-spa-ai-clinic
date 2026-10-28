using System;

namespace GiaoDienSpa.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string CustomerCode { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Birthday { get; set; } = string.Empty; // YYYY-MM-DD

        public string Gender { get; set; } = "Nữ";

        public string MembershipLevel { get; set; } = "Thường"; // Thường, Bạc, Vàng, Kim cương

        public string SkinType { get; set; } = "Da hỗn hợp"; // Da dầu mụn, Da khô lão hóa, Da nhạy cảm, Da hỗn hợp

        public int LoyaltyPoints { get; set; } = 0;

        public decimal TotalSpent { get; set; } = 0;

        public string Status { get; set; } = "Đang hoạt động"; // Đang hoạt động, Ngừng hoạt động

        public string Note { get; set; } = string.Empty;

        public string AiSkinAnalysis { get; set; } = string.Empty; // AI chẩn đoán phác đồ gợi ý
    }
}