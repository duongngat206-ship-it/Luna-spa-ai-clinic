using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GiaoDienSpa.Models;

namespace GiaoDienSpa.Controllers
{
    public class DoctorController : Controller
    {
        // Danh sách ca điều trị lâm sàng mẫu của Bác sĩ
        private static readonly List<DoctorPatientRecord> _clinicalPatients = new List<DoctorPatientRecord>
        {
            new DoctorPatientRecord
            {
                Id = 1,
                PatientCode = "BN-2026-088",
                PatientName = "Nguyễn Thị Minh Anh",
                Phone = "0987 654 321",
                Age = 28,
                Gender = "Nữ",
                SkinDiagnosis = "Nám mảng đối xứng 2 bên gò má, da khô mất nước vùng chữ U",
                CurrentProtocol = "Phác đồ Laser Pico Pro Dual Wave (Buổi 3/6)",
                AttendingDoctor = "Bác sĩ Lê Hoàng Yến",
                AppointmentTime = "09:30 - Hôm nay",
                Room = "Phòng Laser Công nghệ cao",
                Status = "Đang khám lâm sàng",
                AiRiskAlert = "Lưu ý: Chỉ số nhạy cảm biểu bì 74%. Đề xuất giảm 10% năng lượng xung và kết hợp điện di lạnh B5.",
                LastSessionDate = DateTime.Today.AddDays(-14)
            },
            new DoctorPatientRecord
            {
                Id = 2,
                PatientCode = "BN-2026-092",
                PatientName = "Vũ Bích Ngọc",
                Phone = "0934 999 888",
                Age = 35,
                Gender = "Nữ",
                SkinDiagnosis = "Chùng nhão cơ viền hàm, xuất hiện rãnh cười độ 2",
                CurrentProtocol = "Liệu trình Nâng cơ Hifu Ultra Collagen SMAS (Buổi 1/2)",
                AttendingDoctor = "Bác sĩ Lê Hoàng Yến",
                AppointmentTime = "14:30 - Hôm nay",
                Room = "Phòng Trẻ hóa Hifu VIP",
                Status = "Chờ hội chẩn",
                AiRiskAlert = "Khuyến nghị: Sử dụng đầu tip 4.5mm cho đường viền hàm và đầu tip 3.0mm cho má trước.",
                LastSessionDate = DateTime.Today.AddMonths(-1)
            },
            new DoctorPatientRecord
            {
                Id = 3,
                PatientCode = "BN-2026-079",
                PatientName = "Trần Thu Hà",
                Phone = "0912 345 678",
                Age = 31,
                Gender = "Nữ",
                SkinDiagnosis = "Mụn ẩn bít tắc, thâm đỏ sau mụn PIE vùng trán",
                CurrentProtocol = "Peel BHA 20% & Chiếu ánh sáng sinh học Bio-Light (Buổi 4/5)",
                AttendingDoctor = "Bác sĩ Lê Hoàng Yến",
                AppointmentTime = "16:00 - Hôm nay",
                Room = "Phòng Thẩm mỹ Da liễu 02",
                Status = "Chờ khám",
                AiRiskAlert = "Lưu ý: Kiểm tra dị ứng Aspirin/Salicylate trước khi quét dung dịch Peel.",
                LastSessionDate = DateTime.Today.AddDays(-21)
            }
        };

        // GET: /Doctor/Dashboard
        public IActionResult Dashboard()
        {
            ViewBag.DoctorName = HttpContext.Session.GetString("UserName") ?? "Bác sĩ Lê Hoàng Yến";
            ViewBag.TodayAppointments = _clinicalPatients.Count;
            ViewBag.CompletedCount = 1;
            ViewBag.ActiveProtocolsCount = 28;
            ViewBag.AiRiskCount = 2;

            return View(_clinicalPatients);
        }

        // GET: /Doctor/AiDiagnosis
        public IActionResult AiDiagnosis()
        {
            ViewBag.DoctorName = HttpContext.Session.GetString("UserName") ?? "Bác sĩ Lê Hoàng Yến";
            return View(_clinicalPatients);
        }

        // GET: /Doctor/Treatments
        public IActionResult Treatments()
        {
            ViewBag.DoctorName = HttpContext.Session.GetString("UserName") ?? "Bác sĩ Lê Hoàng Yến";
            return View(_clinicalPatients);
        }

        // GET: /Doctor/Patients
        public IActionResult Patients()
        {
            ViewBag.DoctorName = HttpContext.Session.GetString("UserName") ?? "Bác sĩ Lê Hoàng Yến";
            return View(_clinicalPatients);
        }

        // POST: /Doctor/SavePrescription
        [HttpPost]
        public IActionResult SavePrescription([FromBody] ClinicalPrescriptionRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.PatientCode))
            {
                return BadRequest(new { success = false, message = "Thông tin toa dược mỹ phẩm không hợp lệ." });
            }

            return Ok(new
            {
                success = true,
                message = $"Đã lưu phác đồ và chỉ định dược mỹ phẩm cho bệnh nhân {request.PatientName} thành công!",
                prescriptionCode = $"TOA-{DateTime.Now:yyyyMMdd}-{DateTime.Now:HHmm}"
            });
        }
    }

    public class DoctorPatientRecord
    {
        public int Id { get; set; }
        public string PatientCode { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = "Nữ";
        public string SkinDiagnosis { get; set; } = string.Empty;
        public string CurrentProtocol { get; set; } = string.Empty;
        public string AttendingDoctor { get; set; } = string.Empty;
        public string AppointmentTime { get; set; } = string.Empty;
        public string Room { get; set; } = string.Empty;
        public string Status { get; set; } = "Chờ khám";
        public string AiRiskAlert { get; set; } = string.Empty;
        public DateTime LastSessionDate { get; set; } = DateTime.Today;
    }

    public class ClinicalPrescriptionRequest
    {
        public string PatientCode { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public string ProtocolName { get; set; } = string.Empty;
        public string Medications { get; set; } = string.Empty;
        public string DoctorNotes { get; set; } = string.Empty;
    }
}
