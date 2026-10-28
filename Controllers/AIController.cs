using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GiaoDienSpa.Models;

namespace GiaoDienSpa.Controllers
{
    public class AIController : Controller
    {
        private static readonly List<AiConsultationSession> _savedSessions = new List<AiConsultationSession>
        {
            new AiConsultationSession
            {
                SessionId = 1,
                CustomerName = "Nguyễn Minh Anh",
                CustomerPhone = "0987 654 321",
                Age = 28,
                Gender = "Nữ",
                SkinType = "Da hỗn hợp thiên dầu",
                PrimaryConcern = "Lỗ chân lông to & Dầu thừa vùng T-zone",
                Lifestyle = "Văn phòng máy lạnh 8h/ngày, thức khuya",
                SkinHealthScore = 78,
                AiDiagnosis = "Hàng rào bảo vệ da tương đối ổn định nhưng thiếu ẩm tầng sâu dẫn đến tăng tiết bã nhờn bù trừ. Vùng cánh mũi xuất hiện sợi bã nhờn và lỗ chân lông giãn nở nhẹ. Chưa có dấu hiệu lão hóa cấu trúc.",
                RecommendedServices = new List<string> { "Chăm sóc da chuyên sâu Aqua Detox (60p)", "Điện di Tinh chất Tế bào gốc Tái sinh", "Chiếu ánh sáng sinh học Bio-Light" },
                RecommendedCosmetics = new List<string> { "Serum B5 HA Intensifier SkinCeuticals", "Gel Rửa Mặt BHA 1% Kiểm Soát Nhờn", "Kem Chống Nắng Phổ Rộng Kiềm Dầu SPF 50+" },
                CareRoutineSteps = new List<string> { "Sáng: Sữa rửa mặt dịu nhẹ -> Serum HA B5 -> Kem chống nắng kiềm dầu", "Tối: Tẩy trang Bioderma -> Sữa rửa mặt -> Toner BHA 2 lần/tuần -> Kem phục hồi mỏng nhẹ" },
                ExpectedImprovement = "Giảm 75% bóng dầu vùng T-zone và se khít lỗ chân lông sau 2 tuần",
                AssignedDoctor = "Bác sĩ Lê Hoàng Yến",
                CreatedDate = DateTime.Now.AddDays(-1)
            },
            new AiConsultationSession
            {
                SessionId = 2,
                CustomerName = "Trần Thị Mai Phương",
                CustomerPhone = "0912 888 999",
                Age = 35,
                Gender = "Nữ",
                SkinType = "Da khô lão hóa",
                PrimaryConcern = "Nám mảng hai bên gò má & Nếp nhăn đuôi mắt",
                Lifestyle = "Thường xuyên đi công tác, tiếp xúc ánh nắng",
                SkinHealthScore = 65,
                AiDiagnosis = "Mật độ melanin tăng sinh bất thường ở lớp đáy thượng bì do tia UV. Độ đàn hồi sợi collagen suy giảm 28% so với lứa tuổi. Xuất hiện nếp nhăn tĩnh li ti vùng rãnh cười và đuôi mắt.",
                RecommendedServices = new List<string> { "Trẻ hóa da Laser Pico Pro (75p)", "Nâng cơ trẻ hóa Hifu Ultra Collagen (90p)", "Cấy vi điểm Collagen tươi nguyên bào" },
                RecommendedCosmetics = new List<string> { "Serum Vitamin C 15% Chống Oxy Hóa", "Kem Dưỡng Retinol 0.5% Tái Tạo Da", "Kem Chống Nắng Vật Lý Phục Hồi Nám" },
                CareRoutineSteps = new List<string> { "Sáng: Rửa mặt -> Serum Vit C -> Dưỡng ẩm Peptides -> Kem chống nắng che chắn", "Tối: Làm sạch sâu -> Serum HA -> Retinol 0.5% cách ngày -> Kem khóa ẩm ban đêm" },
                ExpectedImprovement = "Mờ 80% vết nám và săn chắc vùng cơ má sau liệu trình 4 buổi",
                AssignedDoctor = "Bác sĩ Lê Hoàng Yến",
                CreatedDate = DateTime.Now.AddDays(-3)
            }
        };

        public IActionResult Index()
        {
            ViewBag.TotalConsultations = 184;
            ViewBag.ConversionRate = 86.5; // Tỷ lệ đặt lịch sau tư vấn
            ViewBag.SatisfactionRate = 98.2;
            ViewBag.ActiveSessions = _savedSessions;

            var defaultSession = _savedSessions.First();
            return View(defaultSession);
        }

        [HttpPost]
        public IActionResult AnalyzeSkin([FromBody] SkinAnalysisRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { success = false, message = "Dữ liệu yêu cầu không hợp lệ." });
            }

            // Tính điểm sức khỏe làn da dựa trên độ tuổi, vấn đề và tính nhạy cảm
            int baseScore = 85;
            if (request.Age > 35) baseScore -= 8;
            if (request.Age > 45) baseScore -= 10;
            if (request.IsSensitive) baseScore -= 12;

            string diagnosis;
            var services = new List<string>();
            var cosmetics = new List<string>();
            var routine = new List<string>();
            string expectedImprovement;

            string concern = request.PrimaryConcern ?? "Lão hóa";
            string skinType = request.SkinType ?? "Da hỗn hợp";

            if (concern.Contains("Mụn") || skinType.Contains("mụn"))
            {
                baseScore -= 15;
                diagnosis = $"Phân tích biểu bì phát hiện bít tắc tại phễu nang lông, tăng tiết bã nhờn kèm vi khuẩn C.acnes hoạt động. Lớp sừng dày và viêm đỏ nhẹ dưới bề mặt.";
                services.Add("Trị mụn y khoa & Chiếu ánh sáng sinh học (75p)");
                services.Add("Peel da vi sinh kiểm soát dầu nhờn Acnes Clear");
                services.Add("Điện di Tinh chất Kháng viêm Tràm Trà & B5");

                cosmetics.Add("Serum B5 HA Intensifier SkinCeuticals (1.950.000 đ)");
                cosmetics.Add("Gel Rửa Mặt La Roche-Posay Effaclar (480.000 đ)");
                cosmetics.Add("Dung Dịch Chấm Mụn Kẽm Sinh Học (350.000 đ)");

                routine.Add("Sáng: Làm sạch nhẹ nhàng -> Serum B5 phục hồi -> Kem chống nắng oil-free");
                routine.Add("Tối: Tẩy trang nước Micellar -> Sữa rửa mặt -> Chấm mụn viêm -> Gel dưỡng ẩm phục hồi");
                expectedImprovement = "Triệt tiêu 90% mụn viêm sau 2-3 buổi; kiểm soát bã nhờn bền vững";
            }
            else if (concern.Contains("Nám") || concern.Contains("Tàn nhang"))
            {
                baseScore -= 14;
                diagnosis = $"Mật độ sắc tố Melanin tích tụ cục bộ tại vùng gò má do ảnh hưởng quang hóa và nội tiết. Hàng rào ceramide mỏng, dễ kích ứng khi tiếp xúc nhiệt độ cao.";
                services.Add("Trẻ hóa da Laser Pico Pro (75p)");
                services.Add("Điện di Tế bào gốc Tái sinh Phục hồi Màng đáy");
                services.Add("Cấy vi điểm Trắng sáng Glutathione & Vitamin C");

                cosmetics.Add("Serum Mờ Nám Chuyên Sâu C-Glow 15% (1.850.000 đ)");
                cosmetics.Add("Kem Dưỡng Ức Chế Melanin Tranexamic 3% (1.450.000 đ)");
                cosmetics.Add("Kem Chống Nắng Phổ Rộng Chống Ánh Sáng Xanh (950.000 đ)");

                routine.Add("Sáng: Rửa mặt êm dịu -> Serum C-Glow -> Dưỡng mỏng -> Thoa lại chống nắng sau 4 tiếng");
                routine.Add("Tối: Tẩy trang dầu nhũ hóa -> Rửa mặt -> Serum Tranexamic -> Kem khóa ẩm giàu Peptides");
                expectedImprovement = "Làm mờ 75-85% chân nám sâu; sáng đều màu da sau 4 buổi Laser Pico";
            }
            else if (concern.Contains("Lão hóa") || concern.Contains("Chùng nhão") || request.Age >= 35)
            {
                baseScore -= 12;
                diagnosis = $"Độ dày lớp trung bì suy giảm, mạng lưới collagen và elastin có hiện tượng phân mảnh. Đường viền hàm có dấu hiệu chùng nhão nhẹ và xuất hiện rãnh cười sâu.";
                services.Add("Nâng cơ trẻ hóa Hifu Ultra Collagen (90p)");
                services.Add("Trẻ hóa da Laser Pico Pro kích thích Collagen");
                services.Add("Cấy vi điểm Collagen Tươi & HA Đậm Đặc");

                cosmetics.Add("Kem Nâng Cơ Săn Chắc Da Peptide Firming (2.200.000 đ)");
                cosmetics.Add("Serum Phục Hồi Chống Nhăn Retinol 0.5% (1.650.000 đ)");
                cosmetics.Add("Mặt Nạ Vàng 24K Thủy Phân Tái Sinh (980.000 đ/hộp)");

                routine.Add("Sáng: Rửa mặt dịu -> Serum Cấp nước Đa tầng -> Kem nâng cơ Peptides -> Chống nắng SPF 50+");
                routine.Add("Tối: Làm sạch sâu -> Serum HA -> Retinol (3 lần/tuần) -> Kem dưỡng ẩm tái tạo tế bào");
                expectedImprovement = "Nâng cơ gọn viền hàm 3-5mm, làm đầy rãnh cười và tăng 35% độ săn chắc";
            }
            else
            {
                diagnosis = $"Làn da ở trạng thái cân bằng tương đối tốt. Cần tập trung thanh lọc độc tố bụi mịn, tăng cường giữ ẩm tầng biểu bì và chống oxy hóa dự phòng sớm.";
                services.Add("Chăm sóc da chuyên sâu Aqua Detox (60p)");
                services.Add("Massage Thư Giãn Cổ Vai Gáy Thảo Dược (60p)");
                services.Add("Đắp Mặt Nạ Dưỡng Trắng Tinh Chất Hoa Hồng");

                cosmetics.Add("Serum B5 HA Intensifier SkinCeuticals (1.950.000 đ)");
                cosmetics.Add("Xịt Khoáng Cấp Ẩm Khoáng Núi Lửa (390.000 đ)");
                cosmetics.Add("Kem Chống Nắng Dịu Da SPF 50+ (750.000 đ)");

                routine.Add("Sáng: Rửa mặt dịu nhẹ -> Serum B5 -> Kem chống nắng");
                routine.Add("Tối: Tẩy trang -> Rửa mặt -> Mặt nạ cấp ẩm 2 lần/tuần -> Kem dưỡng mỏng");
                expectedImprovement = "Da căng mọng ngậm nước, rạng rỡ và sáng khỏe ngay sau buổi đầu tiên";
            }

            int finalScore = Math.Clamp(baseScore, 45, 96);

            var session = new AiConsultationSession
            {
                SessionId = _savedSessions.Count + 1,
                CustomerName = string.IsNullOrWhiteSpace(request.CustomerName) ? "Khách hàng mới" : request.CustomerName,
                CustomerPhone = request.CustomerPhone ?? "",
                Age = request.Age,
                Gender = request.Gender ?? "Nữ",
                SkinType = skinType,
                PrimaryConcern = concern,
                Lifestyle = string.IsNullOrWhiteSpace(request.Lifestyle) ? "Môi trường văn phòng bình thường" : request.Lifestyle,
                SkinHealthScore = finalScore,
                AiDiagnosis = diagnosis,
                RecommendedServices = services,
                RecommendedCosmetics = cosmetics,
                CareRoutineSteps = routine,
                ExpectedImprovement = expectedImprovement,
                AssignedDoctor = "Bác sĩ Lê Hoàng Yến",
                CreatedDate = DateTime.Now
            };

            _savedSessions.Insert(0, session);

            return Json(new
            {
                success = true,
                session = session
            });
        }

        [HttpPost]
        public IActionResult SendChat([FromBody] ChatRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Message))
            {
                return Json(new
                {
                    success = false,
                    reply = "Xin chào! Mình là Trợ lý Luna AI. Bạn có thể hỏi mình về dịch vụ, bảng giá, lịch hẹn, hồ sơ khách, nhân sự, kho mỹ phẩm hoặc cách sử dụng phần mềm nhé!"
                });
            }

            string msg = request.Message.Trim().ToLower();
            string reply;
            var suggestedChips = new List<string>();

            // 1. DỊCH VỤ, BẢNG GIÁ & COMBO
            if (msg.Contains("giá") || msg.Contains("chi phí") || msg.Contains("bao nhiêu") || msg.Contains("dịch vụ") || msg.Contains("liệu trình"))
            {
                if (msg.Contains("pico") || msg.Contains("laser"))
                {
                    reply = "✦ **Trẻ hóa da Laser Pico Pro (75 phút):**\n\n" +
                            "• **Giá niêm yết:** 2.500.000 đ / buổi (Mua combo 3 buổi giảm còn 2.100.000 đ/buổi).\n" +
                            "• **Công nghệ:** Bước sóng kép 1064nm & 532nm phá vỡ sắc tố melanin siêu mịn không tổn thương bề mặt.\n" +
                            "• **Bác sĩ phụ trách:** Bác sĩ Lê Hoàng Yến.\n" +
                            "• **Phòng thực hiện:** Phòng Laser Công nghệ cao (Tầng 2).";
                    suggestedChips.AddRange(new[] { "Bắn Laser Pico có đau không?", "Combo Glow Up 2026", "Đặt lịch phòng Laser" });
                }
                else if (msg.Contains("hifu") || msg.Contains("nâng cơ"))
                {
                    reply = "✦ **Nâng cơ trẻ hóa Hifu Ultra Collagen (90 phút):**\n\n" +
                            "• **Giá niêm yết:** 3.800.000 đ / buổi.\n" +
                            "• **Cơ chế:** Sóng siêu âm hội tụ vi điểm tác động sâu 4.5mm lớp cân cơ SMAS, thon gọn viền hàm V-line, xóa rãnh cười và kích thích tăng sinh collagen.\n" +
                            "• **Chuyên viên:** KTV Trưởng Thu Trang & Bác sĩ Yến.";
                    suggestedChips.AddRange(new[] { "Hifu duy trì được bao lâu?", "Combo Hifu + Laser Pico", "Đặt lịch Nâng cơ Hifu" });
                }
                else if (msg.Contains("mụn") || msg.Contains("peel"))
                {
                    reply = "✦ **Trị mụn y khoa & Chiếu ánh sáng Bio-Light (75 phút):**\n\n" +
                            "• **Giá niêm yết:** 550.000 đ / buổi.\n" +
                            "• **Quy trình chuẩn y khoa:** Tẩy trang -> Xông hơi hút bã nhờn -> Lấy nhân mụn vô khuẩn 100% -> Sát khuẩn điện tím -> Chiếu ánh sáng xanh Bio-Light diệt C.acnes -> Đắp mặt nạ làm dịu tràm trà & B5.\n" +
                            "• **Chuyên viên:** KTV Vũ Khánh Linh.";
                    suggestedChips.AddRange(new[] { "Mỹ phẩm phục hồi cho da mụn", "Đặt lịch trị mụn y khoa", "Mụn ẩn có nặn được không?" });
                }
                else if (msg.Contains("aqua") || msg.Contains("detox") || msg.Contains("chăm sóc da"))
                {
                    reply = "✦ **Chăm sóc da chuyên sâu Aqua Detox (60 phút):**\n\n" +
                            "• **Giá niêm yết:** 650.000 đ / buổi.\n" +
                            "• **Công dụng:** Hút sạch bụi mịn, sợi bã nhờn tầng sâu và cấp ẩm đa tầng bằng tinh chất HA nguyên phân tử.";
                    suggestedChips.AddRange(new[] { "Đặt lịch Aqua Detox", "Bảng giá đầy đủ", "Combo Glow Up 2026" });
                }
                else if (msg.Contains("massage") || msg.Contains("body") || msg.Contains("gội"))
                {
                    reply = "✦ **Dịch vụ Thư giãn & Chăm sóc Body:**\n\n" +
                            "• **Massage Thảo Dược Cổ Vai Gáy (60p):** 450.000 đ\n" +
                            "• **Massage Thư Giãn Toàn Thân Đá Nóng (90p):** 650.000 đ\n" +
                            "• **Gội đầu dưỡng sinh Thảo dược Trung Hoa (45p):** 300.000 đ\n" +
                            "• **Phòng thực hiện:** Phòng Thư giãn Body 02 (Tầng 2) & Phòng Gội (Tầng 1).";
                    suggestedChips.AddRange(new[] { "Đặt lịch Massage Cổ Vai Gáy", "Đặt lịch Gội Dưỡng Sinh", "Bảng giá dịch vụ khác" });
                }
                else
                {
                    reply = "✦ **Bảng giá niêm yết các dịch vụ chính tại Luna Spa:**\n\n" +
                            "1. **Trẻ hóa da Laser Pico Pro (75p):** 2.500.000 đ\n" +
                            "2. **Nâng cơ trẻ hóa Hifu Ultra (90p):** 3.800.000 đ\n" +
                            "3. **Chăm sóc da Aqua Detox (60p):** 650.000 đ\n" +
                            "4. **Trị mụn y khoa & Bio-Light (75p):** 550.000 đ\n" +
                            "5. **Massage Thảo Dược Cổ Vai Gáy (60p):** 450.000 đ\n" +
                            "6. **Gói Combo Trẻ Hóa Glow Up 2026:** 3.690.000 đ (Tiết kiệm 22%)\n\n" +
                            "💡 *Ưu đãi:* Khách hàng mới và hội viên VIP được tặng kèm liệu trình điện di B5 khi đặt qua hệ thống!";
                    suggestedChips.AddRange(new[] { "Tư vấn gói Combo Glow Up 2026", "Đặt lịch hẹn ngay", "Ưu đãi thẻ hội viên VIP" });
                }
            }
            // 2. LỊCH HẸN & ĐẶT LỊCH
            else if (msg.Contains("lịch hẹn") || msg.Contains("đặt lịch") || msg.Contains("hẹn") || msg.Contains("giờ mở cửa") || msg.Contains("khung giờ"))
            {
                reply = "✦ **Quy trình & Điều phối Lịch hẹn tại Luna Spa:**\n\n" +
                        "• **Giờ hoạt động:** 08:30 – 21:00 hàng ngày (kể cả Thứ 7 & Chủ Nhật).\n" +
                        "• **Khung giờ cao điểm:** 15:30 – 19:30 (Phòng Laser & VIP thường đạt 92% công suất).\n" +
                        "• **Điều phối tự động:** Hệ thống tự động giãn cách 15 phút giữa các ca để kỹ thuật viên khử khuẩn phòng và chuẩn bị thiết bị.\n" +
                        "• **Thao tác:** Bạn có thể vào menu **'Lịch hẹn'** -> Bấm **'+ Tạo lịch hẹn'** để chọn dịch vụ, KTV và xếp phòng nhanh chóng!";
                suggestedChips.AddRange(new[] { "Chuyển sang trang Lịch hẹn", "Phòng Laser hôm nay còn trống không?", "Bác sĩ Lê Hoàng Yến trực ca nào?" });
            }
            // 3. KHÁCH HÀNG & THẺ VIP
            else if (msg.Contains("khách hàng") || msg.Contains("vip") || msg.Contains("hội viên") || msg.Contains("tích điểm") || msg.Contains("thành viên"))
            {
                reply = "✦ **Chính sách Khách hàng & Hội viên VIP tại Luna Spa:**\n\n" +
                        "Hệ thống phân thành 4 hạng hội viên:\n" +
                        "1. **Hạng Thường:** Tích lũy 1 điểm cho mỗi 100.000 đ chi tiêu.\n" +
                        "2. **Hạng Bạc:** Tổng chi từ 10.000.000 đ -> Giảm 3% trên mọi hóa đơn.\n" +
                        "3. **Hạng Vàng:** Tổng chi từ 30.000.000 đ -> Giảm 5%, ưu tiên xếp phòng VIP.\n" +
                        "4. **Hạng Kim Cương:** Tổng chi từ 60.000.000 đ -> Giảm 10% trọn đời, Bác sĩ Yến trực tiếp điều trị, tặng quà sinh nhật cao cấp.\n\n" +
                        "Bạn có thể tra cứu chi tiết tại menu **'Khách hàng'**.";
                suggestedChips.AddRange(new[] { "Cách nâng hạng thẻ VIP", "Ưu đãi sinh nhật khách hàng", "Tra cứu điểm tích lũy" });
            }
            // 4. NHÂN SỰ & BÁC SĨ
            else if (msg.Contains("nhân viên") || msg.Contains("bác sĩ") || msg.Contains("chuyên viên") || msg.Contains("ktv") || msg.Contains("ca trực"))
            {
                reply = "✦ **Đội ngũ Y bác sĩ & Chuyên viên tại Luna Spa:**\n\n" +
                        "• **Bác sĩ Lê Hoàng Yến:** Bác sĩ Chuyên khoa Da liễu (10 năm kinh nghiệm), phụ trách chính phác đồ Laser Pico & Hifu.\n" +
                        "• **Nguyễn Thu Trang:** Kỹ thuật viên Trưởng (7 năm kinh nghiệm), chuyên sâu trẻ hóa và cấy tinh chất vi điểm.\n" +
                        "• **Đặng Thùy Dung:** KTV Trị liệu Cổ vai gáy & Massage đá nóng.\n" +
                        "• **Vũ Khánh Linh:** KTV Trị mụn chuẩn y khoa & Peel vi sinh.\n" +
                        "• **Lâm Mỹ Duyên:** KTV Gội đầu dưỡng sinh & Chăm sóc thư giãn.\n\n" +
                        "Spa có 3 ca làm việc: Ca sáng (08:30 - 16:30), Ca chiều (13:30 - 21:00) và Toàn thời gian.";
                suggestedChips.AddRange(new[] { "Xem ca trực hôm nay", "Đặt lịch với Bác sĩ Yến", "Hiệu suất nhân viên tháng này" });
            }
            // 5. KHO DƯỢC MỸ PHẨM
            else if (msg.Contains("kho") || msg.Contains("mỹ phẩm") || msg.Contains("sản phẩm") || msg.Contains("serum") || msg.Contains("hạn sử dụng") || msg.Contains("nhập hàng"))
            {
                reply = "✦ **Quản trị Kho Dược Mỹ Phẩm Luna Spa:**\n\n" +
                        "• **Sản phẩm chủ lực:** Serum B5 HA Intensifier SkinCeuticals (1.950.000 đ), Gel rửa mặt La Roche-Posay (480.000 đ), Mặt nạ vàng 24K Collagen (980.000 đ), Kem chống nắng phổ rộng (750.000 đ).\n" +
                        "• **Kiểm soát thông minh:** Hệ thống AI tự động giám sát số lượng tồn kho theo định mức an toàn và đưa ra gợi ý đặt hàng định mức khi sản phẩm sắp hết.\n" +
                        "• **Thao tác nhanh:** Bạn có thể bấm **'Nhập kho nhanh'** ngay trên trang **Kho mỹ phẩm** để cộng dồn số lượng mà không cần lập đơn phức tạp!";
                suggestedChips.AddRange(new[] { "Chuyển sang trang Kho mỹ phẩm", "Đề xuất đơn nhập kho AI", "Các dòng mỹ phẩm phục hồi da" });
            }
            // 6. HÓA ĐƠN & THANH TOÁN
            else if (msg.Contains("hóa đơn") || msg.Contains("thanh toán") || msg.Contains("pos") || msg.Contains("qr") || msg.Contains("biên lai") || msg.Contains("in"))
            {
                reply = "✦ **Quản lý Hóa đơn & Thu ngân Spa:**\n\n" +
                        "• **Phương thức hỗ trợ:** Chuyển khoản VietQR tự động, Thẻ ngân hàng qua POS, Tiền mặt tại quầy và Ví điện tử.\n" +
                        "• **Tính năng biên lai điện tử:** Xem trước và in biên lai nhiệt chuẩn hóa với logo Luna Spa, chiết khấu và lời dặn chăm sóc từ AI.\n" +
                        "• **Gợi ý Upsell AI:** Phân tích hóa đơn để gợi ý combo mỹ phẩm phù hợp với liệu trình khách vừa làm nhằm tối ưu doanh số.";
                suggestedChips.AddRange(new[] { "Tạo hóa đơn thanh toán mới", "Xem mẫu biên lai in nhiệt", "Chuyển sang trang Hóa đơn" });
            }
            // 7. BÁO CÁO & DOANH THU
            else if (msg.Contains("báo cáo") || msg.Contains("doanh thu") || msg.Contains("lợi nhuận") || msg.Contains("thống kê") || msg.Contains("tăng trưởng"))
            {
                reply = "✦ **Báo cáo Tài chính & Vận hành Tháng 10/2026:**\n\n" +
                        "• **Tổng doanh thu thực tế:** 148.500.000 đ (+14.8% so với tháng trước).\n" +
                        "• **Lợi nhuận ròng (EBITDA):** 89.200.000 đ (Biên lợi nhuận: 60.1%).\n" +
                        "• **Số lượt khách phục vụ:** 138/142 ca hoàn thành thành công (97.2%).\n" +
                        "• **Cơ cấu danh mục:** Trẻ hóa công nghệ cao Laser & Hifu chiếm 52% tổng doanh thu.\n" +
                        "• **Xuất báo cáo:** Hỗ trợ kết xuất file Excel (.xlsx), PDF và CSV cho Ban Giám Đốc.";
                suggestedChips.AddRange(new[] { "Chuyển sang trang Báo cáo", "Xuất file Excel báo cáo", "Phòng nào có doanh thu cao nhất?" });
            }
            // 8. CHĂM SÓC SAU LIỆU TRÌNH
            else if (msg.Contains("sau khi") || msg.Contains("chăm sóc") || msg.Contains("kiêng") || msg.Contains("rửa mặt") || msg.Contains("nắng"))
            {
                reply = "✦ **Lời dặn chăm sóc chuẩn y khoa sau khi làm liệu trình Spa:**\n\n" +
                        "1. **24 giờ đầu:** Rửa mặt bằng nước muối sinh lý hoặc nước đun sôi để nguội; tránh xông hơi, massage mặt mạnh hay tắm nước quá nóng.\n" +
                        "2. **Chống nắng tuyệt đối:** Bôi kem chống nắng phổ rộng SPF 50+ trước khi ra ngoài 20 phút và thoa lại sau 3-4 giờ.\n" +
                        "3. **Phục hồi & Cấp ẩm:** Sử dụng Serum B5 HA ngày 2 lần giúp làm dịu và kích thích tăng sinh biểu bì mới.\n" +
                        "4. **Chế độ sinh hoạt:** Uống đủ 2 lít nước, ngủ trước 23:00 và kiêng đồ cay nóng, rượu bia trong 3 ngày đầu.";
                suggestedChips.AddRange(new[] { "Serum B5 nào phục hồi tốt?", "Bắn Laser có kiêng ăn thịt bò không?", "Đặt lịch tái khám định kỳ" });
            }
            // 9. CÁCH SỬ DỤNG PHẦN MỀM SPA
            else if (msg.Contains("hướng dẫn") || msg.Contains("cách dùng") || msg.Contains("phần mềm") || msg.Contains("chức năng") || msg.Contains("tính năng"))
            {
                reply = "✦ **Hướng dẫn sử dụng các phân hệ của Hệ thống Quản lý Spa:**\n\n" +
                        "1. **Tổng quan (Home):** Nắm bắt KPI doanh thu ngày, lịch hẹn theo thời gian thực và nhiệm vụ AI khuyến nghị.\n" +
                        "2. **Khách hàng:** Quản lý hồ sơ, thẻ thành viên, điểm loyalty và mở chẩn đoán phác đồ da AI.\n" +
                        "3. **Dịch vụ:** Bảng giá niêm yết, thời lượng và công cụ tạo combo ưu đãi tự động.\n" +
                        "4. **Lịch hẹn:** Đặt lịch, kiểm soát độ phủ phòng và tránh trùng lịch hẹn.\n" +
                        "5. **Nhân viên:** Phân ca làm việc, theo dõi KTV đang trong ca và xếp lịch thông minh.\n" +
                        "6. **Kho mỹ phẩm:** Tồn kho thời gian thực, nhập kho nhanh và dự toán đơn hàng.\n" +
                        "7. **Hóa đơn:** Thu ngân tính tiền, quét mã VietQR và in biên lai điện tử.\n" +
                        "8. **Tư vấn AI:** Chẩn đoán tình trạng da chuyên sâu và trợ lý chat trực tuyến.\n" +
                        "9. **Báo cáo:** Biểu đồ tăng trưởng, cơ cấu doanh thu và xuất file Excel/PDF.";
                suggestedChips.AddRange(new[] { "Cách tạo hóa đơn mới", "Cách thêm khách hàng mới", "Xem phân tích da AI" });
            }
            // DEFAULT CHAT RESPONSE
            else
            {
                reply = $"Chào bạn! Luna AI đã tiếp nhận câu hỏi: *\"{request.Message}\"*.\n\n" +
                        "Luna AI được nạp toàn bộ tri thức của dự án Quản lý Spa & Chăm sóc sắc đẹp. Bạn có thể hỏi về:\n" +
                        "• **Bảng giá & Phác đồ điều trị** (Laser Pico, Hifu, Trị mụn, Combo 2026...)\n" +
                        "• **Vận hành Spa** (Đặt lịch hẹn, Phân ca nhân viên, Nhập kho mỹ phẩm, Hóa đơn thanh toán)\n" +
                        "• **Báo cáo điều hành** (Doanh thu, Lợi nhuận, Độ phủ phòng trị liệu)\n" +
                        "• **Lời dặn chuyên khoa** (Chăm sóc sau liệu trình, kiêng khem, dưỡng da tại nhà)\n\n" +
                        "Bạn hãy bấm vào các gợi ý bên dưới hoặc đặt câu hỏi chi tiết nhé!";
                suggestedChips.AddRange(new[] { "Bảng giá dịch vụ niêm yết", "Cách đặt lịch hẹn trị liệu", "Tư vấn phác đồ Laser Pico", "Báo cáo doanh thu tháng này" });
            }

            return Json(new
            {
                success = true,
                reply = reply,
                suggestedChips = suggestedChips
            });
        }
    }
}