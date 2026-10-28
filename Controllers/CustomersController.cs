using Microsoft.AspNetCore.Mvc;
using GiaoDienSpa.Models;
using System.Collections.Generic;
using System.Linq;

namespace GiaoDienSpa.Controllers
{
    public class CustomersController : Controller
    {
        private static List<Customer> _customers = new List<Customer>
        {
            new Customer
            {
                CustomerId = 1,
                CustomerCode = "KH001",
                FullName = "Nguyễn Thị Minh Anh",
                Phone = "0987 654 321",
                Email = "minhanh.nguyen@gmail.com",
                Birthday = "1998-04-12",
                Gender = "Nữ",
                MembershipLevel = "Vàng",
                SkinType = "Da hỗn hợp thiên dầu",
                LoyaltyPoints = 288,
                TotalSpent = 14500000,
                Status = "Đang hoạt động",
                Note = "Khách thường xuyên đặt dịch vụ Laser và mua kèm serum dưỡng ẩm phục hồi.",
                AiSkinAnalysis = "AI Phác đồ: Da có xu hướng nhạy cảm nhẹ sau laser. Đề xuất phác đồ cấp ẩm điện di HA & đắp mặt nạ làm dịu lạnh."
            },
            new Customer
            {
                CustomerId = 2,
                CustomerCode = "KH002",
                FullName = "Trần Thu Hà",
                Phone = "0912 345 678",
                Email = "thuha.tran@gmail.com",
                Birthday = "1995-08-20",
                Gender = "Nữ",
                MembershipLevel = "Bạc",
                SkinType = "Da khô mất nước",
                LoyaltyPoints = 150,
                TotalSpent = 8200000,
                Status = "Đang hoạt động",
                Note = "Làm việc văn phòng máy lạnh nhiều, da bong tróc nhẹ vùng cánh mũi.",
                AiSkinAnalysis = "AI Phác đồ: Khuyến nghị gói Cấp ẩm chuyên sâu Aqua Detox 5 buổi kết hợp Kem khóa ẩm B5 tại nhà."
            },
            new Customer
            {
                CustomerId = 3,
                CustomerCode = "KH003",
                FullName = "Lê Hoàng Nam",
                Phone = "0905 123 456",
                Email = "hoangnam.le@gmail.com",
                Birthday = "1992-02-15",
                Gender = "Nam",
                MembershipLevel = "Thường",
                SkinType = "Da dầu khỏe",
                LoyaltyPoints = 70,
                TotalSpent = 3500000,
                Status = "Đang hoạt động",
                Note = "Thường chọn dịch vụ Massage thảo mộc giảm căng thẳng sau giờ làm việc.",
                AiSkinAnalysis = "AI Phác đồ: Khách hàng nam ưa chuộng liệu trình thư giãn cổ vai gáy kết hợp tẩy da chết body bạc hà."
            },
            new Customer
            {
                CustomerId = 4,
                CustomerCode = "KH004",
                FullName = "Phạm Ngọc Mai",
                Phone = "0977 123 456",
                Email = "ngocmai.pham@gmail.com",
                Birthday = "1988-11-03",
                Gender = "Nữ",
                MembershipLevel = "Kim cương",
                SkinType = "Da lão hóa & nám mảng",
                LoyaltyPoints = 540,
                TotalSpent = 32800000,
                Status = "Đang hoạt động",
                Note = "Khách VIP thân thiết của viện thẩm mỹ. Đã thực hiện 4 buổi Nâng cơ Hifu.",
                AiSkinAnalysis = "AI Phác đồ: Đáp ứng tốt với sóng siêu âm hội tụ Hifu. Gợi ý liệu trình duy trì kết hợp Mặt nạ vàng 24K collagen định kỳ 2 tuần/lần."
            },
            new Customer
            {
                CustomerId = 5,
                CustomerCode = "KH005",
                FullName = "Đỗ Thanh Hương",
                Phone = "0966 123 456",
                Email = "thanhhuong.do@gmail.com",
                Birthday = "1997-06-18",
                Gender = "Nữ",
                MembershipLevel = "Bạc",
                SkinType = "Da dầu mụn ẩn",
                LoyaltyPoints = 120,
                TotalSpent = 6200000,
                Status = "Đang hoạt động",
                Note = "Đang trong liệu trình lấy nhân mụn chuẩn y khoa buổi thứ 3.",
                AiSkinAnalysis = "AI Phác đồ: Mụn viêm đã giảm 70%. Đề xuất chuyển sang bước Peel da sinh học Bio-Peel nồng độ thấp để mờ thâm."
            },
            new Customer
            {
                CustomerId = 6,
                CustomerCode = "KH006",
                FullName = "Vũ Đức Long",
                Phone = "0933 123 456",
                Email = "duclong.vu@gmail.com",
                Birthday = "1994-09-22",
                Gender = "Nam",
                MembershipLevel = "Thường",
                SkinType = "Da thường",
                LoyaltyPoints = 40,
                TotalSpent = 2100000,
                Status = "Ngừng hoạt động",
                Note = "Khách tạm dừng liệu trình do đi công tác nước ngoài.",
                AiSkinAnalysis = "AI Gợi ý: Gửi email thăm hỏi và tặng voucher 15% khi khách quay trở lại Việt Nam."
            },
            new Customer
            {
                CustomerId = 7,
                CustomerCode = "KH007",
                FullName = "Hoàng Thu Trang",
                Phone = "0988 123 456",
                Email = "thutrang.hoang@gmail.com",
                Birthday = "1999-12-01",
                Gender = "Nữ",
                MembershipLevel = "Vàng",
                SkinType = "Da nhạy cảm dễ ửng đỏ",
                LoyaltyPoints = 310,
                TotalSpent = 16900000,
                Status = "Đang hoạt động",
                Note = "Chỉ dùng các sản phẩm hữu cơ thuần chay không hương liệu.",
                AiSkinAnalysis = "AI Phác đồ: Ưu tiên dòng mỹ phẩm Luna Botanic thuần organic, tránh các liệu trình peel nồng độ cao."
            },
            new Customer
            {
                CustomerId = 8,
                CustomerCode = "KH008",
                FullName = "Bùi Khánh Linh",
                Phone = "0909 123 456",
                Email = "khanhlinh.bui@gmail.com",
                Birthday = "2001-03-10",
                Gender = "Nữ",
                MembershipLevel = "Thường",
                SkinType = "Da hỗn hợp dầu",
                LoyaltyPoints = 55,
                TotalSpent = 2800000,
                Status = "Đang hoạt động",
                Note = "Khách hàng sinh viên đăng ký gói chăm sóc da mụn cơ bản.",
                AiSkinAnalysis = "AI Phác đồ: Thích hợp gói dịch vụ Chăm sóc da sinh viên với giá ưu đãi và hướng dẫn chu trình skincare tối giản."
            }
        };

        public IActionResult Index()
        {
            ViewBag.TotalCustomers = _customers.Count;
            ViewBag.ActiveCustomers = _customers.Count(c => c.Status == "Đang hoạt động");
            ViewBag.VipCustomers = _customers.Count(c => c.MembershipLevel == "Vàng" || c.MembershipLevel == "Kim cương");
            ViewBag.NewCustomersThisMonth = 3;

            return View(_customers);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Customer newCustomer)
        {
            if (newCustomer == null || string.IsNullOrWhiteSpace(newCustomer.FullName))
            {
                return BadRequest(new { success = false, message = "Thông tin khách hàng không hợp lệ." });
            }

            newCustomer.CustomerId = _customers.Any() ? _customers.Max(c => c.CustomerId) + 1 : 1;
            newCustomer.CustomerCode = $"KH{newCustomer.CustomerId:D03}";
            if (string.IsNullOrEmpty(newCustomer.Status)) newCustomer.Status = "Đang hoạt động";
            if (string.IsNullOrEmpty(newCustomer.MembershipLevel)) newCustomer.MembershipLevel = "Thường";
            if (string.IsNullOrEmpty(newCustomer.SkinType)) newCustomer.SkinType = "Da hỗn hợp";

            newCustomer.AiSkinAnalysis = $"AI Chẩn đoán ban đầu: Khách hàng mới với tình trạng {newCustomer.SkinType}. Đề xuất bác sĩ da liễu soi da miễn phí trong buổi trị liệu đầu tiên.";

            _customers.Insert(0, newCustomer);
            return Ok(new { success = true, customer = newCustomer });
        }

        [HttpPost]
        public IActionResult Update([FromBody] Customer customer)
        {
            var existing = _customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            if (existing == null)
            {
                return NotFound(new { success = false, message = "Không tìm thấy khách hàng." });
            }

            existing.FullName = customer.FullName;
            existing.Phone = customer.Phone;
            existing.Email = customer.Email;
            existing.Birthday = customer.Birthday;
            existing.Gender = customer.Gender;
            existing.MembershipLevel = customer.MembershipLevel;
            existing.SkinType = customer.SkinType;
            existing.Status = customer.Status;
            existing.Note = customer.Note;

            return Ok(new { success = true, customer = existing });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer != null)
            {
                _customers.Remove(customer);
                return Ok(new { success = true });
            }
            return NotFound(new { success = false, message = "Không tìm thấy khách hàng." });
        }

        [HttpGet]
        public IActionResult AiSkinConsultation(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound(new { success = false, message = "Không tìm thấy khách hàng." });
            }

            var consultation = new
            {
                customerName = customer.FullName,
                skinType = customer.SkinType,
                tier = customer.MembershipLevel,
                aiDiagnosis = customer.AiSkinAnalysis,
                suggestedServices = customer.SkinType.Contains("mụn")
                    ? new[] { "Lấy nhân mụn y khoa", "Chiếu ánh sáng sinh học Bio-Light", "Peel da mờ thâm" }
                    : (customer.SkinType.Contains("lão hóa") || customer.SkinType.Contains("nám")
                        ? new[] { "Trẻ hóa da Laser Pico", "Nâng cơ Hifu Ultra", "Điện di Tế bào gốc" }
                        : new[] { "Chăm sóc da Aqua Detox", "Massage Thảo dược", "Cấp ẩm HA chuyên sâu" }),
                suggestedCosmetics = customer.SkinType.Contains("mụn")
                    ? "Sữa rửa mặt tạo bọt Effaclar + Kem dưỡng phục hồi B5"
                    : "Serum B5 HA Intensifier + Mặt nạ vàng 24K collagen"
            };

            return Json(consultation);
        }
    }
}