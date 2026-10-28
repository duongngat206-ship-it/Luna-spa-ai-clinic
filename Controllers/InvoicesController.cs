using Microsoft.AspNetCore.Mvc;
using GiaoDienSpa.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiaoDienSpa.Controllers
{
    public class InvoicesController : Controller
    {
        private static List<Invoice> _invoices = new List<Invoice>
        {
            new Invoice
            {
                InvoiceId = 1,
                InvoiceCode = "HD-20261027-001",
                CustomerName = "Nguyễn Thị Minh Anh",
                CustomerPhone = "0987 654 321",
                StaffName = "Bác sĩ Lê Hoàng Yến",
                CreatedDate = DateTime.Today.AddHours(9).AddMinutes(30),
                SubTotal = 3200000,
                DiscountAmount = 320000,
                TaxAmount = 0,
                TotalAmount = 2880000,
                PaymentMethod = "Chuyển khoản QR",
                Status = "Đã thanh toán",
                Note = "Khách VIP hạng Vàng - Áp dụng ưu đãi giảm 10% sinh nhật.",
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem { ItemId = 1, ItemName = "Liệu trình Trẻ hóa da Laser Pico Pro", ItemType = "Dịch vụ", Quantity = 1, UnitPrice = 2500000, Discount = 250000 },
                    new InvoiceItem { ItemId = 2, ItemName = "Kem Chống Nắng Phục Hồi Dịu Da SPF50+", ItemType = "Mỹ phẩm", Quantity = 1, UnitPrice = 680000, Discount = 70000 },
                    new InvoiceItem { ItemId = 3, ItemName = "Mặt nạ lạnh làm dịu da tức thì", ItemType = "Dịch vụ", Quantity = 1, UnitPrice = 20000, Discount = 0 }
                },
                AiUpsellRecommendation = "AI Insight: Khách đã hoàn thành buổi Laser thứ 2. Đề xuất gói dưỡng phục hồi tế bào gốc 5 buổi để tối đa hiệu quả làm sáng da."
            },
            new Invoice
            {
                InvoiceId = 2,
                InvoiceCode = "HD-20261027-002",
                CustomerName = "Trần Thu Hà",
                CustomerPhone = "0912 345 678",
                StaffName = "Nguyễn Thu Trang (KTV Trưởng)",
                CreatedDate = DateTime.Today.AddHours(11).AddMinutes(15),
                SubTotal = 1500000,
                DiscountAmount = 0,
                TaxAmount = 0,
                TotalAmount = 1500000,
                PaymentMethod = "Thẻ POS",
                Status = "Đã thanh toán",
                Note = "Thanh toán bằng thẻ Visa Techcombank.",
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem { ItemId = 1, ItemName = "Chăm sóc da chuyên sâu Aqua Detox", ItemType = "Dịch vụ", Quantity = 1, UnitPrice = 850000, Discount = 0 },
                    new InvoiceItem { ItemId = 2, ItemName = "Serum Cấp Ẩm Phục Hồi B5 HA Intensifier", ItemType = "Mỹ phẩm", Quantity = 1, UnitPrice = 650000, Discount = 0 }
                },
                AiUpsellRecommendation = "AI Insight: Da khách đang có dấu hiệu khô bề mặt do làm việc phòng máy lạnh. Đề xuất nâng cấp liệu trình điện di Vitamin C lần tới."
            },
            new Invoice
            {
                InvoiceId = 3,
                InvoiceCode = "HD-20261027-003",
                CustomerName = "Lê Hoàng Nam",
                CustomerPhone = "0905 123 456",
                StaffName = "Đặng Thùy Dung (KTV)",
                CreatedDate = DateTime.Today.AddHours(14).AddMinutes(0),
                SubTotal = 750000,
                DiscountAmount = 50000,
                TaxAmount = 0,
                TotalAmount = 700000,
                PaymentMethod = "Tiền mặt",
                Status = "Đã thanh toán",
                Note = "Khách thanh toán tiền mặt tại quầy lễ tân.",
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem { ItemId = 1, ItemName = "Massage Thảo Dược Cổ Vai Gáy Thư Giãn (60p)", ItemType = "Dịch vụ", Quantity = 1, UnitPrice = 750000, Discount = 50000 }
                },
                AiUpsellRecommendation = "AI Insight: Khách thường xuyên ngồi nhiều, hay bị đau lưng mỏi cổ. Đề xuất thẻ liệu trình 10 buổi Massage Trị Liệu Đá Nóng giảm 20%."
            },
            new Invoice
            {
                InvoiceId = 4,
                InvoiceCode = "HD-20261027-004",
                CustomerName = "Phạm Ngọc Mai",
                CustomerPhone = "0977 123 456",
                StaffName = "Bác sĩ Lê Hoàng Yến",
                CreatedDate = DateTime.Today.AddHours(15).AddMinutes(45),
                SubTotal = 4900000,
                DiscountAmount = 490000,
                TaxAmount = 0,
                TotalAmount = 4410000,
                PaymentMethod = "Chưa thanh toán",
                Status = "Chờ thanh toán",
                Note = "Khách đang trong phòng trị liệu tầng 2, chuẩn bị thanh toán khi kết thúc.",
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem { ItemId = 1, ItemName = "Nâng cơ trẻ hóa Hifu Ultra Collagen", ItemType = "Dịch vụ", Quantity = 1, UnitPrice = 3800000, Discount = 380000 },
                    new InvoiceItem { ItemId = 2, ItemName = "Mặt Nạ Vàng 24K Collagen Sinh Học", ItemType = "Mỹ phẩm", Quantity = 1, UnitPrice = 980000, Discount = 98000 },
                    new InvoiceItem { ItemId = 3, ItemName = "Tinh chất cấp ẩm dưỡng sâu ban đêm", ItemType = "Mỹ phẩm", Quantity = 1, UnitPrice = 120000, Discount = 12000 }
                },
                AiUpsellRecommendation = "AI Insight: Khách VIP Kim Cương. Tặng kèm voucher chăm sóc da tay hoa hồng và tư vấn kem dưỡng mắt cao cấp."
            },
            new Invoice
            {
                InvoiceId = 5,
                InvoiceCode = "HD-20261027-005",
                CustomerName = "Đỗ Thanh Hương",
                CustomerPhone = "0966 123 456",
                StaffName = "Vũ Khánh Linh (KTV)",
                CreatedDate = DateTime.Today.AddHours(16).AddMinutes(20),
                SubTotal = 550000,
                DiscountAmount = 0,
                TaxAmount = 0,
                TotalAmount = 550000,
                PaymentMethod = "Ví điện tử MoMo",
                Status = "Đã thanh toán",
                Note = "Thanh toán quét mã MoMo thành công.",
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem { ItemId = 1, ItemName = "Gội đầu dưỡng sinh Thảo dược Trung Hoa (45p)", ItemType = "Dịch vụ", Quantity = 1, UnitPrice = 350000, Discount = 0 },
                    new InvoiceItem { ItemId = 2, ItemName = "Tẩy da chết da đầu bạc hà mát lạnh", ItemType = "Dịch vụ", Quantity = 1, UnitPrice = 200000, Discount = 0 }
                },
                AiUpsellRecommendation = "AI Insight: Khách yêu thích hương thảo mộc tự nhiên. Gợi ý dầu dưỡng tóc argan hoặc nến thơm phòng ngủ."
            }
        };

        public IActionResult Index()
        {
            ViewBag.TotalRevenue = _invoices.Where(x => x.Status == "Đã thanh toán").Sum(x => x.TotalAmount);
            ViewBag.TotalInvoices = _invoices.Count;
            ViewBag.PaidInvoices = _invoices.Count(x => x.Status == "Đã thanh toán");
            ViewBag.PendingInvoices = _invoices.Count(x => x.Status == "Chờ thanh toán");

            return View(_invoices);
        }

        [HttpGet]
        public IActionResult GetDetail(int id)
        {
            var invoice = _invoices.FirstOrDefault(x => x.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound(new { success = false, message = "Không tìm thấy hóa đơn." });
            }

            return Json(new { success = true, invoice });
        }

        [HttpPost]
        public IActionResult Create([FromBody] Invoice newInvoice)
        {
            if (newInvoice == null || string.IsNullOrWhiteSpace(newInvoice.CustomerName))
            {
                return BadRequest(new { success = false, message = "Thông tin hóa đơn không hợp lệ." });
            }

            newInvoice.InvoiceId = _invoices.Any() ? _invoices.Max(x => x.InvoiceId) + 1 : 1;
            newInvoice.InvoiceCode = $"HD-{DateTime.Now:yyyyMMdd}-{newInvoice.InvoiceId:D03}";
            newInvoice.CreatedDate = DateTime.Now;

            // Tính toán tổng tiền
            if (newInvoice.Items != null && newInvoice.Items.Any())
            {
                newInvoice.SubTotal = newInvoice.Items.Sum(x => x.Quantity * x.UnitPrice);
                newInvoice.DiscountAmount = newInvoice.Items.Sum(x => x.Discount);
            }
            newInvoice.TotalAmount = Math.Max(0, newInvoice.SubTotal - newInvoice.DiscountAmount + newInvoice.TaxAmount);

            if (string.IsNullOrEmpty(newInvoice.Status)) newInvoice.Status = "Đã thanh toán";
            if (string.IsNullOrEmpty(newInvoice.PaymentMethod)) newInvoice.PaymentMethod = "Chuyển khoản QR";

            newInvoice.AiUpsellRecommendation = $"AI Phân tích: Hóa đơn trị giá {newInvoice.TotalAmount:N0} đ. Đã tích lũy {(int)(newInvoice.TotalAmount / 10000)} điểm thành viên cho khách hàng.";

            _invoices.Insert(0, newInvoice);
            return Ok(new { success = true, invoice = newInvoice });
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, string status)
        {
            var invoice = _invoices.FirstOrDefault(x => x.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound(new { success = false, message = "Không tìm thấy hóa đơn." });
            }

            invoice.Status = status;
            return Ok(new { success = true, invoice });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var invoice = _invoices.FirstOrDefault(x => x.InvoiceId == id);
            if (invoice != null)
            {
                _invoices.Remove(invoice);
                return Ok(new { success = true });
            }
            return NotFound(new { success = false, message = "Không tìm thấy hóa đơn." });
        }

        [HttpGet]
        public IActionResult AiUpsellInsights()
        {
            var insights = new
            {
                analysisTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                topPairing = "Khách đặt liệu trình 'Trẻ hóa da Laser' mua kèm 'Serum B5 HA' đạt tỷ lệ 78%.",
                averageTicketSize = _invoices.Any() ? (long)_invoices.Average(x => x.TotalAmount) : 0,
                suggestedAction = "Tạo Combo 'Laser Tái Tạo + Bộ Dưỡng Phục Hồi Tại Nhà' ưu đãi giảm 15% để nâng giá trị đơn hàng trung bình lên trên 3.5 triệu đồng.",
                pendingAlert = _invoices.Count(x => x.Status == "Chờ thanh toán") > 0
                    ? $"Có {_invoices.Count(x => x.Status == "Chờ thanh toán")} hóa đơn chưa hoàn tất thanh toán. Hãy nhắc nhân viên thu ngân kiểm tra trước giờ đóng ca."
                    : "Tất cả hóa đơn trong ca đều đã được thanh toán an toàn."
            };

            return Json(insights);
        }
    }
}