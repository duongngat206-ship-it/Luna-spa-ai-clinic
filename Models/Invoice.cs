using System;
using System.Collections.Generic;

namespace GiaoDienSpa.Models
{
    public class InvoiceItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string ItemType { get; set; } = "Dịch vụ"; // "Dịch vụ" hoặc "Mỹ phẩm"
        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; } = 0;
        public decimal Subtotal => (Quantity * UnitPrice) - Discount;
    }

    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string InvoiceCode { get; set; } = string.Empty; // HD-20261027-001
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string StaffName { get; set; } = string.Empty; // Kỹ thuật viên / Thu ngân
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; } = 0;
        public decimal TaxAmount { get; set; } = 0;
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = "Chuyển khoản QR"; // Tiền mặt, Chuyển khoản QR, Thẻ POS, Ví điện tử
        public string Status { get; set; } = "Đã thanh toán"; // Đã thanh toán, Chờ thanh toán, Đã hủy
        public string Note { get; set; } = string.Empty;
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
        public string AiUpsellRecommendation { get; set; } = string.Empty; // Gợi ý AI cho khách này
    }
}