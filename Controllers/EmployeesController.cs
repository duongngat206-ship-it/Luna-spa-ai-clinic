using Microsoft.AspNetCore.Mvc;
using GiaoDienSpa.Models;
using System.Collections.Generic;
using System.Linq;

namespace GiaoDienSpa.Controllers
{
    public class EmployeesController : Controller
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                EmployeeId = 1,
                EmployeeCode = "NV001",
                FullName = "Nguyễn Thu Trang",
                Position = "Kỹ thuật viên Trưởng",
                Specialization = "Trẻ hóa da & Nâng cơ Hifu",
                Phone = "0912 345 678",
                Email = "trang.nguyen@lunaspa.vn",
                ExperienceYears = 6,
                Rating = 4.95,
                CompletedSessions = 428,
                Shift = "Ca sáng (08:30 - 16:30)",
                Status = "Đang làm việc",
                AiScoreNote = "Khách hàng chấm điểm 5/5 về kỹ thuật massage nâng cơ. Đề xuất ưu tiên xếp khách VIP liệu trình Hifu."
            },
            new Employee
            {
                EmployeeId = 2,
                EmployeeCode = "NV002",
                FullName = "Trần Minh Ngọc",
                Position = "Chuyên viên Lễ tân & Tư vấn",
                Specialization = "Tư vấn phác đồ chăm sóc & Mỹ phẩm",
                Phone = "0987 654 321",
                Email = "ngoc.tran@lunaspa.vn",
                ExperienceYears = 4,
                Rating = 4.9,
                CompletedSessions = 512,
                Shift = "Ca chiều (13:30 - 21:00)",
                Status = "Đang làm việc",
                AiScoreNote = "Tỷ lệ chốt đơn tư vấn mỹ phẩm sau liệu trình đạt 88%. AI gợi ý giao phụ trách quầy tư vấn giờ cao điểm."
            },
            new Employee
            {
                EmployeeId = 3,
                EmployeeCode = "NV003",
                FullName = "Bác sĩ Lê Hoàng Yến",
                Position = "Bác sĩ Da liễu",
                Specialization = "Laser Pico, Trị nám & Trị mụn y khoa",
                Phone = "0909 123 456",
                Email = "yen.le@lunaspa.vn",
                ExperienceYears = 8,
                Rating = 5.0,
                CompletedSessions = 680,
                Shift = "Toàn thời gian (09:00 - 18:00)",
                Status = "Đang trong ca",
                AiScoreNote = "Chuyên gia hàng đầu về phác đồ tái tạo da chuyên sâu. Độ hài lòng của khách đạt 99.4%."
            },
            new Employee
            {
                EmployeeId = 4,
                EmployeeCode = "NV004",
                FullName = "Đặng Thùy Dung",
                Position = "Kỹ thuật viên Spa",
                Specialization = "Massage Thảo mộc & Thư giãn Body",
                Phone = "0934 567 890",
                Email = "dung.dang@lunaspa.vn",
                ExperienceYears = 3,
                Rating = 4.85,
                CompletedSessions = 310,
                Shift = "Ca sáng (08:30 - 16:30)",
                Status = "Đang trong ca",
                AiScoreNote = "Thế mạnh liệu trình thư giãn và bấm huyệt cổ vai gáy cho khách văn phòng."
            },
            new Employee
            {
                EmployeeId = 5,
                EmployeeCode = "NV005",
                FullName = "Vũ Khánh Linh",
                Position = "Kỹ thuật viên Chăm sóc da",
                Specialization = "Cấp ẩm chuyên sâu & Peel da hữu cơ",
                Phone = "0945 678 123",
                Email = "linh.vu@lunaspa.vn",
                ExperienceYears = 2,
                Rating = 4.8,
                CompletedSessions = 195,
                Shift = "Ca chiều (13:30 - 21:00)",
                Status = "Đang làm việc",
                AiScoreNote = "Thực hiện tốt các quy trình peel da dịu nhẹ, khách tái khám đánh giá hồi phục nhanh."
            },
            new Employee
            {
                EmployeeId = 6,
                EmployeeCode = "NV006",
                FullName = "Phạm Gia Hưng",
                Position = "Quản lý Vận hành",
                Specialization = "Điều phối phòng trị liệu & Nhân sự",
                Phone = "0978 901 234",
                Email = "hung.pham@lunaspa.vn",
                ExperienceYears = 7,
                Rating = 4.9,
                CompletedSessions = 0,
                Shift = "Toàn thời gian (08:30 - 17:30)",
                Status = "Đang làm việc",
                AiScoreNote = "Quản lý định mức tiêu hao nguyên vật liệu và điều phối ca trực hiệu quả."
            },
            new Employee
            {
                EmployeeId = 7,
                EmployeeCode = "NV007",
                FullName = "Lâm Mỹ Duyên",
                Position = "Kỹ thuật viên Spa",
                Specialization = "Triệt lông Diode Laser & Tắm trắng",
                Phone = "0961 234 890",
                Email = "duyen.lam@lunaspa.vn",
                ExperienceYears = 2,
                Rating = 4.75,
                CompletedSessions = 160,
                Shift = "Ca chiều (13:30 - 21:00)",
                Status = "Tạm nghỉ",
                AiScoreNote = "Đang trong lịch nghỉ phép định kỳ, dự kiến trở lại ca trực vào thứ Hai."
            }
        };

        public IActionResult Index()
        {
            ViewBag.TotalEmployees = _employees.Count;
            ViewBag.WorkingEmployees = _employees.Count(e => e.Status == "Đang làm việc" || e.Status == "Đang trong ca");
            ViewBag.TopRated = _employees.Count(e => e.Rating >= 4.9);
            ViewBag.OnLeave = _employees.Count(e => e.Status == "Tạm nghỉ");

            return View(_employees);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Employee newEmp)
        {
            if (newEmp == null || string.IsNullOrWhiteSpace(newEmp.FullName))
            {
                return BadRequest(new { success = false, message = "Thông tin không hợp lệ." });
            }

            newEmp.EmployeeId = _employees.Any() ? _employees.Max(e => e.EmployeeId) + 1 : 1;
            newEmp.EmployeeCode = $"NV{newEmp.EmployeeId:D03}";
            if (string.IsNullOrEmpty(newEmp.Status)) newEmp.Status = "Đang làm việc";
            if (newEmp.Rating <= 0) newEmp.Rating = 5.0;

            // AI tự động sinh nhận định kỹ năng ban đầu
            newEmp.AiScoreNote = $"AI đánh giá: Nhân sự mới vị trí {newEmp.Position}, chuyên môn {newEmp.Specialization}. Đề xuất kèm cặp 1 tuần với kỹ thuật viên trưởng.";

            _employees.Insert(0, newEmp);

            return Ok(new { success = true, employee = newEmp });
        }

        [HttpPost]
        public IActionResult Update([FromBody] Employee emp)
        {
            var existing = _employees.FirstOrDefault(e => e.EmployeeId == emp.EmployeeId);
            if (existing == null)
            {
                return NotFound(new { success = false, message = "Không tìm thấy nhân viên." });
            }

            existing.FullName = emp.FullName;
            existing.Position = emp.Position;
            existing.Specialization = emp.Specialization;
            existing.Phone = emp.Phone;
            existing.Email = emp.Email;
            existing.ExperienceYears = emp.ExperienceYears;
            existing.Shift = emp.Shift;
            existing.Status = emp.Status;

            return Ok(new { success = true, employee = existing });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var emp = _employees.FirstOrDefault(e => e.EmployeeId == id);
            if (emp != null)
            {
                _employees.Remove(emp);
                return Ok(new { success = true });
            }
            return NotFound(new { success = false, message = "Không tìm thấy nhân viên." });
        }

        [HttpGet]
        public IActionResult AiShiftAnalysis()
        {
            var inDuty = _employees.Where(e => e.Status != "Tạm nghỉ").ToList();
            var recommendation = new
            {
                morningShiftCount = inDuty.Count(e => e.Shift.Contains("sáng")),
                afternoonShiftCount = inDuty.Count(e => e.Shift.Contains("chiều")),
                fulltimeCount = inDuty.Count(e => e.Shift.Contains("Toàn thời gian")),
                alert = "Dự báo khung giờ 17:00 - 20:00 có 14 lịch hẹn trị liệu da mụn & laser. AI đề xuất chuyển 1 KTV ca sáng sang hỗ trợ ca chiều.",
                suggestedStaff = "Nguyễn Thu Trang (NV001) hoặc Đặng Thùy Dung (NV004)"
            };

            return Json(recommendation);
        }
    }
}