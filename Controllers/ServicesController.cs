using Microsoft.AspNetCore.Mvc;
using GiaoDienSpa.Models;
using System.Collections.Generic;
using System.Linq;

namespace GiaoDienSpa.Controllers
{
    public class ServicesController : Controller
    {
        private static List<SpaService> _services = new List<SpaService>
        {
            new SpaService
            {
                ServiceId = 1,
                ServiceCode = "DV001",
                ServiceName = "Trẻ hóa da Laser Pico Pro",
                Category = "Trẻ hóa công nghệ cao",
                Description = "Sử dụng xung laser Pico giây siêu ngắn phân hủy sắc tố nám, tàn nhang và kích thích tăng sinh collagen sâu.",
                Price = 2500000,
                DurationMinutes = 75,
                Icon = "✦",
                RecommendedCosmetics = "Kem chống nắng Cell Fusion C & Serum B5",
                Status = "Đang cung cấp",
                AiSuitability = "Độ phù hợp 98% cho da nám, tàn nhang, đốm nâu hoặc da xỉn màu."
            },
            new SpaService
            {
                ServiceId = 2,
                ServiceCode = "DV002",
                ServiceName = "Nâng cơ trẻ hóa Hifu Ultra Collagen",
                Category = "Trẻ hóa công nghệ cao",
                Description = "Sóng siêu âm hội tụ vi điểm tác động sâu lớp cân cơ SMAS giúp thon gọn viền hàm và xóa mờ nếp nhăn chảy xệ.",
                Price = 3800000,
                DurationMinutes = 90,
                Icon = "✧",
                RecommendedCosmetics = "Mặt nạ vàng 24K collagen sinh học",
                Status = "Đang cung cấp",
                AiSuitability = "Độ phù hợp 95% cho khách hàng từ 28 tuổi trở lên có dấu hiệu chảy xệ rãnh cười."
            },
            new SpaService
            {
                ServiceId = 3,
                ServiceCode = "DV003",
                ServiceName = "Chăm sóc da chuyên sâu Aqua Detox",
                Category = "Chăm sóc da chuyên sâu",
                Description = "Hút sạch bã nhờn tế bào chết bằng đầu xoáy nước hydro, đẩy tinh chất cấp ẩm sâu và làm sáng da tức thì.",
                Price = 850000,
                DurationMinutes = 60,
                Icon = "✿",
                RecommendedCosmetics = "Serum Cấp Ẩm Phục Hồi B5 HA Intensifier",
                Status = "Đang cung cấp",
                AiSuitability = "Phù hợp mọi loại da, đặc biệt là da làm việc văn phòng thiếu ẩm và sạm màu."
            },
            new SpaService
            {
                ServiceId = 4,
                ServiceCode = "DV004",
                ServiceName = "Trị mụn y khoa & Chiếu ánh sáng sinh học",
                Category = "Chăm sóc da chuyên sâu",
                Description = "Quy trình vô trùng y khoa lấy sạch nhân mụn, sát khuẩn tia điện tím và chiếu ánh sáng Bio-Light diệt khuẩn P.acnes.",
                Price = 650000,
                DurationMinutes = 75,
                Icon = "❀",
                RecommendedCosmetics = "Sữa rửa mặt tạo bọt Effaclar & Gel chấm mụn",
                Status = "Đang cung cấp",
                AiSuitability = "Độ phù hợp 100% cho da dầu nhờn nhiều, mụn ẩn, mụn đầu đen và mụn viêm nhẹ."
            },
            new SpaService
            {
                ServiceId = 5,
                ServiceCode = "DV005",
                ServiceName = "Massage Thảo Dược Cổ Vai Gáy (60p)",
                Category = "Massage & Trị liệu",
                Description = "Kỹ thuật bấm huyệt chuyên sâu giải tỏa co thắt cơ kết hợp chườm túi thảo dược thuốc bắc ấm nóng.",
                Price = 550000,
                DurationMinutes = 60,
                Icon = "♧",
                RecommendedCosmetics = "Tinh dầu Lavender hữu cơ Provence",
                Status = "Đang cung cấp",
                AiSuitability = "Liệu trình bán chạy nhất cho dân văn phòng bị đau mỏi đốt sống cổ và mất ngủ."
            },
            new SpaService
            {
                ServiceId = 6,
                ServiceCode = "DV006",
                ServiceName = "Massage Thư Giãn Toàn Thân Đá Nóng (90p)",
                Category = "Massage & Trị liệu",
                Description = "Massage toàn thân bằng tinh dầu tự nhiên kết hợp năng lượng từ đá bazan núi lửa giữ nhiệt giúp lưu thông khí huyết.",
                Price = 850000,
                DurationMinutes = 90,
                Icon = "◇",
                RecommendedCosmetics = "Tinh dầu sả chanh & gừng ấm",
                Status = "Đang cung cấp",
                AiSuitability = "Giúp tái tạo năng lượng, giảm đau nhức xương khớp và mang lại giấc ngủ sâu."
            },
            new SpaService
            {
                ServiceId = 7,
                ServiceCode = "DV007",
                ServiceName = "Peel da sinh học mờ thâm Bio-Peel",
                Category = "Chăm sóc da chuyên sâu",
                Description = "Tẩy tế bào sừng hóa bằng phức hợp acid trái cây AHA/BHA dịu nhẹ, kích thích thay da sinh học mới mượt mà.",
                Price = 950000,
                DurationMinutes = 60,
                Icon = "♡",
                RecommendedCosmetics = "Kem dưỡng phục hồi B5 phục hồi da",
                Status = "Đang cung cấp",
                AiSuitability = "Tối ưu cho da thâm mụn, lỗ chân lông to và bề mặt sần sùi."
            },
            new SpaService
            {
                ServiceId = 8,
                ServiceCode = "DV008",
                ServiceName = "Ủ dưỡng trắng da toàn thân kén tằm",
                Category = "Chăm sóc body",
                Description = "Tẩy tế bào chết bằng thảo mộc rừng và ủ tinh chất protein tơ tằm kết hợp sữa non giàu vitamin dưỡng ẩm sáng mịn.",
                Price = 1100000,
                DurationMinutes = 90,
                Icon = "❃",
                RecommendedCosmetics = "Sữa dưỡng thể phục hồi Luna White",
                Status = "Đang cung cấp",
                AiSuitability = "Phù hợp cho khách hàng muốn phục hồi da cháy nắng và dưỡng ẩm mượt mà toàn diện."
            },
            new SpaService
            {
                ServiceId = 9,
                ServiceCode = "DV009",
                ServiceName = "Triệt lông Diode Laser vĩnh viễn",
                Category = "Trẻ hóa công nghệ cao",
                Description = "Công nghệ triệt lông lạnh bán dẫn bước sóng 808nm êm ái, triệt tiêu mầm nhú nang lông và làm sáng mịn se khít nang lông.",
                Price = 600000,
                DurationMinutes = 45,
                Icon = "☼",
                RecommendedCosmetics = "Gel nha đam dịu da làm mát",
                Status = "Đang cung cấp",
                AiSuitability = "An toàn trên mọi phân vùng da, không gây châm chích nóng rát."
            },
            new SpaService
            {
                ServiceId = 10,
                ServiceCode = "DV010",
                ServiceName = "Gội đầu dưỡng sinh Thảo dược Trung Hoa",
                Category = "Massage & Trị liệu",
                Description = "Gội đầu bằng nước nấu thảo mộc tươi (bồ kết, sả, hà thủ ô) kết hợp mát xa bấm huyệt đầu mặt cổ vai gáy.",
                Price = 350000,
                DurationMinutes = 45,
                Icon = "☘",
                RecommendedCosmetics = "Dầu dưỡng tóc argan thiên nhiên",
                Status = "Đang cung cấp",
                AiSuitability = "Giải tỏa căng thẳng đầu óc, ngừa rụng tóc và lưu thông tuần hoàn máu não."
            },
            new SpaService
            {
                ServiceId = 11,
                ServiceCode = "DV011",
                ServiceName = "Điện di Tế bào gốc Trẻ hóa phục hồi",
                Category = "Trẻ hóa công nghệ cao",
                Description = "Sử dụng dòng điện sinh học mở rộng kênh tế bào da, đẩy sâu ampoule tế bào gốc thực vật nuôi dưỡng tái sinh biểu bì.",
                Price = 1250000,
                DurationMinutes = 60,
                Icon = "❁",
                RecommendedCosmetics = "Mặt nạ phục hồi tế bào gốc sinh học",
                Status = "Đang cung cấp",
                AiSuitability = "Khuyên dùng sau các liệu trình Laser hoặc lăn kim để rút ngắn thời gian lành da."
            },
            new SpaService
            {
                ServiceId = 12,
                ServiceCode = "DV012",
                ServiceName = "Chăm sóc vùng da mắt trẻ hóa giảm bọng",
                Category = "Chăm sóc da chuyên sâu",
                Description = "Massage chuyên biệt bằng sóng siêu âm đầu nhỏ kết hợp serum peptide xóa mờ nếp nhăn và quầng thâm bọng mắt.",
                Price = 450000,
                DurationMinutes = 40,
                Icon = "👁",
                RecommendedCosmetics = "Kem dưỡng mắt nâng cơ Peptide",
                Status = "Đang cung cấp",
                AiSuitability = "Rất thích hợp bán kèm khi khách hàng đặt liệu trình chăm sóc da mặt."
            }
        };

        public IActionResult Index()
        {
            ViewBag.TotalServices = _services.Count;
            ViewBag.HighTechServices = _services.Count(s => s.Category == "Trẻ hóa công nghệ cao");
            ViewBag.BodyMassageServices = _services.Count(s => s.Category == "Massage & Trị liệu");
            ViewBag.SkincareServices = _services.Count(s => s.Category == "Chăm sóc da chuyên sâu");

            return View(_services);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SpaService service)
        {
            if (service == null || string.IsNullOrWhiteSpace(service.ServiceName))
            {
                return BadRequest(new { success = false, message = "Thông tin dịch vụ không hợp lệ." });
            }

            service.ServiceId = _services.Any() ? _services.Max(s => s.ServiceId) + 1 : 1;
            service.ServiceCode = $"DV{service.ServiceId:D03}";
            if (string.IsNullOrEmpty(service.Icon)) service.Icon = "✧";
            if (string.IsNullOrEmpty(service.Status)) service.Status = "Đang cung cấp";
            service.AiSuitability = $"AI Đánh giá: Dịch vụ mới được bổ sung vào danh mục menu Spa. Đang phân tích mức độ đón nhận của khách.";

            _services.Insert(0, service);
            return Ok(new { success = true, service });
        }

        [HttpPost]
        public IActionResult Update([FromBody] SpaService service)
        {
            var existing = _services.FirstOrDefault(s => s.ServiceId == service.ServiceId);
            if (existing == null)
            {
                return NotFound(new { success = false, message = "Không tìm thấy dịch vụ." });
            }

            existing.ServiceName = service.ServiceName;
            existing.Category = service.Category;
            existing.Description = service.Description;
            existing.Price = service.Price;
            existing.DurationMinutes = service.DurationMinutes;
            existing.RecommendedCosmetics = service.RecommendedCosmetics;
            existing.Status = service.Status;

            return Ok(new { success = true, service = existing });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var service = _services.FirstOrDefault(s => s.ServiceId == id);
            if (service != null)
            {
                _services.Remove(service);
                return Ok(new { success = true });
            }
            return NotFound(new { success = false, message = "Không tìm thấy dịch vụ." });
        }

        [HttpGet]
        public IActionResult AiComboRecommendation()
        {
            var combo = new
            {
                title = "Combo Nâng Tầm Nhan Sắc - Glow Up 2026",
                primaryService = "Trẻ hóa da Laser Pico Pro (2.500.000 đ)",
                secondaryService = "Điện di Tế bào gốc Trẻ hóa (1.250.000 đ)",
                giftProduct = "Mặt nạ vàng 24K collagen (980.000 đ)",
                originalTotal = 4730000,
                comboPrice = 3690000,
                discountPercent = 22,
                expectedConversion = "Tăng tỷ lệ khách đồng ý trải nghiệm lên 68% so với đặt dịch vụ đơn lẻ."
            };

            return Json(combo);
        }
    }
}