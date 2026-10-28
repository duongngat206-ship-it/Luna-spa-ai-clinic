using Microsoft.AspNetCore.Mvc;
using GiaoDienSpa.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiaoDienSpa.Controllers
{
    public class InventoryController : Controller
    {
        private static List<InventoryItem> _inventory = new List<InventoryItem>
        {
            new InventoryItem
            {
                ProductId = 1,
                Sku = "SKU-SERUM-01",
                ProductName = "Serum Cấp Ẩm Phục Hồi B5 HA Intensifier",
                Brand = "SkinCeuticals",
                Category = "Serum đặc trị",
                Quantity = 6,
                MinQuantity = 10,
                Unit = "Chai 50ml",
                CostPrice = 1850000,
                UnitPrice = 2450000,
                ExpiryDate = DateTime.Today.AddMonths(18),
                Supplier = "SkinCeuticals VN Official",
                Status = "Sắp hết hàng",
                MonthlyUsageRate = 42,
                AiPrediction = "Cảnh báo AI: Tốc độ tiêu thụ 11 chai/tuần. Tồn kho chỉ đủ dùng trong 4 ngày tới. Cần đặt thêm 25 chai ngay."
            },
            new InventoryItem
            {
                ProductId = 2,
                Sku = "SKU-MASK-02",
                ProductName = "Mặt Nạ Vàng 24K Collagen Sinh Học",
                Brand = "Luna Spa Botanic",
                Category = "Mặt nạ sinh học",
                Quantity = 3,
                MinQuantity = 8,
                Unit = "Hộp 10 miếng",
                CostPrice = 650000,
                UnitPrice = 980000,
                ExpiryDate = DateTime.Today.AddMonths(14),
                Supplier = "Công ty Dược Mỹ phẩm Hàn Việt",
                Status = "Sắp hết hàng",
                MonthlyUsageRate = 28,
                AiPrediction = "Cảnh báo AI: Dịch vụ trẻ hóa da Gold Luxury cuối tuần tăng cao. Tồn kho dưới mức an toàn."
            },
            new InventoryItem
            {
                ProductId = 3,
                Sku = "SKU-CLEAN-03",
                ProductName = "Sữa Rửa Mặt Tạo Bọt Dịu Nhẹ Toleriane",
                Brand = "La Roche-Posay",
                Category = "Chăm sóc da",
                Quantity = 28,
                MinQuantity = 12,
                Unit = "Chai 400ml",
                CostPrice = 380000,
                UnitPrice = 520000,
                ExpiryDate = DateTime.Today.AddMonths(22),
                Supplier = "L'Oréal Việt Nam",
                Status = "Còn hàng",
                MonthlyUsageRate = 35,
                AiPrediction = "AI Đánh giá: Mức tồn kho ổn định, đủ đáp ứng cho 30 ngày liệu trình tiếp theo."
            },
            new InventoryItem
            {
                ProductId = 4,
                Sku = "SKU-OIL-04",
                ProductName = "Tinh Dầu Thảo Dược Massage Thư Giãn Lavender",
                Brand = "Provence Organic",
                Category = "Tinh dầu thảo mộc",
                Quantity = 18,
                MinQuantity = 8,
                Unit = "Chai 500ml",
                CostPrice = 750000,
                UnitPrice = 1100000,
                ExpiryDate = DateTime.Today.AddMonths(9),
                Supplier = "Tinh Dầu Thiên Nhiên Pháp",
                Status = "Còn hàng",
                MonthlyUsageRate = 14,
                AiPrediction = "AI Đánh giá: Mức tiêu thụ ổn định cho các gói Massage Body Thảo Dược."
            },
            new InventoryItem
            {
                ProductId = 5,
                Sku = "SKU-CREAM-05",
                ProductName = "Kem Chống Nắng Phục Hồi Dịu Da SPF50+ PA++++",
                Brand = "Cell Fusion C",
                Category = "Kem dưỡng",
                Quantity = 34,
                MinQuantity = 15,
                Unit = "Tuýp 50ml",
                CostPrice = 420000,
                UnitPrice = 680000,
                ExpiryDate = DateTime.Today.AddMonths(16),
                Supplier = "Phân phối Dược phẩm Á Châu",
                Status = "Còn hàng",
                MonthlyUsageRate = 50,
                AiPrediction = "AI Gợi ý: Sản phẩm bán kèm tốt nhất sau các buổi Laser & Trị mụn. Đề xuất giữ tồn tối thiểu 30 tuýp."
            },
            new InventoryItem
            {
                ProductId = 6,
                Sku = "SKU-PEEL-06",
                ProductName = "Dung Dịch Peel Da Sinh Học Tái Tạo Bio-Peel",
                Brand = "Dermaceutic",
                Category = "Serum đặc trị",
                Quantity = 4,
                MinQuantity = 6,
                Unit = "Lọ 30ml",
                CostPrice = 1200000,
                UnitPrice = 1750000,
                ExpiryDate = DateTime.Today.AddDays(25),
                Supplier = "Dược Mỹ Phẩm Châu Âu",
                Status = "Cận date",
                AiPrediction = "Cảnh báo AI: Sản phẩm còn 25 ngày hết hạn! Đề xuất ưu tiên sử dụng cho 6 ca điều trị sẹo rỗ trong tuần này."
            },
            new InventoryItem
            {
                ProductId = 7,
                Sku = "SKU-DETOX-07",
                ProductName = "Bùn Khoáng Núi Lửa Thải Độc Sâu Toàn Thân",
                Brand = "Dead Sea Spa Magik",
                Category = "Chăm sóc da",
                Quantity = 0,
                MinQuantity = 5,
                Unit = "Xô 3kg",
                CostPrice = 1450000,
                UnitPrice = 2100000,
                ExpiryDate = DateTime.Today.AddMonths(12),
                Supplier = "Công ty Nhập khẩu Israel",
                Status = "Hết hàng",
                MonthlyUsageRate = 10,
                AiPrediction = "Cảnh báo khẩn AI: Hết hàng trong kho! 3 khách hẹn tắm bùn khoáng vào thứ Bảy cần sản phẩm ngay."
            }
        };

        public IActionResult Index()
        {
            ViewBag.TotalItems = _inventory.Count;
            ViewBag.LowStockItems = _inventory.Count(x => x.Quantity <= x.MinQuantity && x.Quantity > 0);
            ViewBag.OutOfStockItems = _inventory.Count(x => x.Quantity == 0);
            ViewBag.ExpiringSoonItems = _inventory.Count(x => (x.ExpiryDate - DateTime.Today).TotalDays <= 30 && x.Quantity > 0);
            ViewBag.TotalInventoryValue = _inventory.Sum(x => x.Quantity * x.CostPrice);

            return View(_inventory);
        }

        [HttpPost]
        public IActionResult Create([FromBody] InventoryItem item)
        {
            if (item == null || string.IsNullOrWhiteSpace(item.ProductName))
            {
                return BadRequest(new { success = false, message = "Thông tin sản phẩm không hợp lệ." });
            }

            item.ProductId = _inventory.Any() ? _inventory.Max(x => x.ProductId) + 1 : 1;
            if (string.IsNullOrEmpty(item.Sku))
            {
                item.Sku = $"SKU-{DateTime.Now:yyyyMMdd}-{item.ProductId:D03}";
            }

            // Tính toán trạng thái
            if (item.Quantity == 0) item.Status = "Hết hàng";
            else if ((item.ExpiryDate - DateTime.Today).TotalDays <= 30) item.Status = "Cận date";
            else if (item.Quantity <= item.MinQuantity) item.Status = "Sắp hết hàng";
            else item.Status = "Còn hàng";

            item.AiPrediction = $"AI Đánh giá: Sản phẩm mới thêm vào kho. Dự báo ban đầu định mức tồn an toàn: {item.MinQuantity} {item.Unit}.";

            _inventory.Insert(0, item);
            return Ok(new { success = true, item });
        }

        [HttpPost]
        public IActionResult Update([FromBody] InventoryItem item)
        {
            var existing = _inventory.FirstOrDefault(x => x.ProductId == item.ProductId);
            if (existing == null)
            {
                return NotFound(new { success = false, message = "Không tìm thấy sản phẩm." });
            }

            existing.ProductName = item.ProductName;
            existing.Brand = item.Brand;
            existing.Category = item.Category;
            existing.Quantity = item.Quantity;
            existing.MinQuantity = item.MinQuantity;
            existing.Unit = item.Unit;
            existing.CostPrice = item.CostPrice;
            existing.UnitPrice = item.UnitPrice;
            existing.ExpiryDate = item.ExpiryDate;
            existing.Supplier = item.Supplier;

            if (existing.Quantity == 0) existing.Status = "Hết hàng";
            else if ((existing.ExpiryDate - DateTime.Today).TotalDays <= 30) existing.Status = "Cận date";
            else if (existing.Quantity <= existing.MinQuantity) existing.Status = "Sắp hết hàng";
            else existing.Status = "Còn hàng";

            return Ok(new { success = true, item = existing });
        }

        [HttpPost]
        public IActionResult QuickRestock(int id, int addQuantity)
        {
            var existing = _inventory.FirstOrDefault(x => x.ProductId == id);
            if (existing == null)
            {
                return NotFound(new { success = false, message = "Không tìm thấy sản phẩm." });
            }

            existing.Quantity += addQuantity;
            if (existing.Quantity > existing.MinQuantity)
            {
                existing.Status = "Còn hàng";
            }
            existing.AiPrediction = $"AI Cập nhật: Đã bổ sung {addQuantity} {existing.Unit}. Mức tồn kho hiện tại an toàn cho 25 ngày tới.";

            return Ok(new { success = true, item = existing });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = _inventory.FirstOrDefault(x => x.ProductId == id);
            if (item != null)
            {
                _inventory.Remove(item);
                return Ok(new { success = true });
            }
            return NotFound(new { success = false, message = "Không tìm thấy sản phẩm." });
        }

        [HttpGet]
        public IActionResult AiRestockPlan()
        {
            var urgentItems = _inventory
                .Where(x => x.Quantity <= x.MinQuantity || (x.ExpiryDate - DateTime.Today).TotalDays <= 30)
                .Select(x => new
                {
                    sku = x.Sku,
                    name = x.ProductName,
                    currentQty = x.Quantity,
                    minQty = x.MinQuantity,
                    unit = x.Unit,
                    suggestedOrder = Math.Max(x.MinQuantity * 2 - x.Quantity, 10),
                    estimatedCost = Math.Max(x.MinQuantity * 2 - x.Quantity, 10) * x.CostPrice,
                    reason = x.Quantity == 0 ? "Hết hàng khẩn cấp" : (x.Quantity <= x.MinQuantity ? "Tồn kho dưới ngưỡng an toàn" : "Cận date cần luân chuyển")
                })
                .ToList();

            var result = new
            {
                analysisDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                urgentCount = urgentItems.Count,
                totalEstimatedBudget = urgentItems.Sum(x => x.estimatedCost),
                items = urgentItems,
                aiAdvice = "Hệ thống AI khuyến nghị nên gom đơn đặt hàng từ nhà cung cấp SkinCeuticals và Dược Mỹ Phẩm Châu Âu để nhận chiết khấu thêm 5% cho đơn trên 20 triệu đồng."
            };

            return Json(result);
        }
    }
}