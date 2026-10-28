using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GiaoDienSpa.Models;

namespace GiaoDienSpa.Controllers
{
    public class StaffController : Controller
    {
        // Mock dữ liệu sơ đồ buồng phòng & giường điều trị
        private static readonly List<StaffRoomBed> _rooms = new List<StaffRoomBed>
        {
            new StaffRoomBed { RoomId = 1, RoomName = "Phòng Laser Công nghệ cao", BedCode = "G-01", AssignedStaff = "BS. CKI Lê Hoàng Yến", CustomerName = "Nguyễn Thị Minh Anh", ServiceName = "Laser Pico Pro Trị Tàn Nhang", Status = "Đang phục vụ", StartTime = "09:30", DurationMinutes = 60, ElapsedMinutes = 40, Notes = "Xung Pico 3.2J - Đang đắp mặt nạ tế bào gốc làm dịu" },
            new StaffRoomBed { RoomId = 2, RoomName = "Phòng Trị liệu VIP 01", BedCode = "G-02", AssignedStaff = "Nguyễn Thu Trang (KTV Trưởng)", CustomerName = "Trần Thu Hà", ServiceName = "Aqua Detox Cấp Ẩm Đa Tầng", Status = "Đang phục vụ", StartTime = "11:00", DurationMinutes = 45, ElapsedMinutes = 25, Notes = "Khách da khô nhạy cảm, sử dụng đầu hút sủi oxy tươi dịu nhẹ" },
            new StaffRoomBed { RoomId = 3, RoomName = "Phòng Thư giãn Body 02", BedCode = "G-03", AssignedStaff = "Đặng Thùy Dung (KTV)", CustomerName = "Lê Hoàng Nam", ServiceName = "Massage Thảo Dược Cổ Vai Gáy", Status = "Chờ khách vào", StartTime = "14:00", DurationMinutes = 75, ElapsedMinutes = 0, Notes = "Khách yêu cầu tinh dầu sả chanh và khăn ủ ấm nhiệt độ 45°C" },
            new StaffRoomBed { RoomId = 4, RoomName = "Phòng Trẻ hóa Hifu VIP", BedCode = "G-04", AssignedStaff = "Nguyễn Thu Trang (KTV)", CustomerName = "Vũ Bích Ngọc", ServiceName = "Nâng cơ Hifu Collagen", Status = "Đang vô trùng", StartTime = "15:30", DurationMinutes = 90, ElapsedMinutes = 0, Notes = "Đang chiếu đèn cực tím UV khử khuẩn buồng sau ca trước" },
            new StaffRoomBed { RoomId = 5, RoomName = "Phòng Chăm sóc Da Cơ Bản 01", BedCode = "G-05", AssignedStaff = "Vũ Khánh Linh (KTV)", CustomerName = "Chưa có khách", ServiceName = "Sẵn sàng đón khách mới", Status = "Sẵn sàng", StartTime = "--:--", DurationMinutes = 45, ElapsedMinutes = 0, Notes = "Giường đã thay drap mới vô trùng, máy xông tinh dầu đã sẵn sàng" },
            new StaffRoomBed { RoomId = 6, RoomName = "Phòng Chăm sóc Da Cơ Bản 02", BedCode = "G-06", AssignedStaff = "Lê Phương Thảo (KTV)", CustomerName = "Chưa có khách", ServiceName = "Sẵn sàng đón khách mới", Status = "Sẵn sàng", StartTime = "--:--", DurationMinutes = 45, ElapsedMinutes = 0, Notes = "Đầy đủ vật tư tiêu hao, khay dụng cụ làm sạch chuẩn y tế" }
        };

        // Danh sách ca hẹn trong ngày của nhân viên
        private static readonly List<StaffAppointmentTask> _tasks = new List<StaffAppointmentTask>
        {
            new StaffAppointmentTask { Id = 101, TimeSlot = "09:00 - 10:15", CustomerName = "Nguyễn Thị Minh Anh", Phone = "0912.334.556", ServiceName = "Laser Pico Pro Trị Tàn Nhang (Buổi 3/5)", RoomBed = "P.Laser 01 (G-01)", Status = "Đang thực hiện", ProgressPercent = 65, ProtocolSteps = "1. Làm sạch sâu -> 2. Ủ tê 20p -> 3. Laser Pico 3.2J -> 4. Đắp mặt nạ làm dịu" },
            new StaffAppointmentTask { Id = 102, TimeSlot = "11:00 - 12:00", CustomerName = "Trần Thu Hà", Phone = "0988.221.119", ServiceName = "Aqua Detox Cấp Ẩm Chuyên Sâu", RoomBed = "P.VIP 01 (G-02)", Status = "Đang thực hiện", ProgressPercent = 50, ProtocolSteps = "1. Tẩy trang dịu nhẹ -> 2. Xông hơi hút dầu -> 3. Điện di HA -> 4. Khóa ẩm" },
            new StaffAppointmentTask { Id = 103, TimeSlot = "14:00 - 15:30", CustomerName = "Vũ Bích Ngọc", Phone = "0977.882.334", ServiceName = "Nâng Cơ Trẻ Hóa Hifu Collagen", RoomBed = "P.Hifu VIP (G-04)", Status = "Sắp diễn ra", ProgressPercent = 0, ProtocolSteps = "1. Vệ sinh da -> 2. Bôi gel dẫn sóng -> 3. Đi đầu tip 3.0mm & 4.5mm -> 4. Nâng cơ" },
            new StaffAppointmentTask { Id = 104, TimeSlot = "16:30 - 17:30", CustomerName = "Lê Phương Thảo", Phone = "0903.445.667", ServiceName = "Cấp Ẩm HA Đa Tầng & Massage", RoomBed = "P.Chăm Sóc 01 (G-05)", Status = "Chưa đến", ProgressPercent = 0, ProtocolSteps = "1. Làm sạch da -> 2. Tẩy tế bào chết enzyme -> 3. Massage mặt -> 4. Điện di B5" }
        };

        // Danh sách vật tư tiêu hao buồng phòng
        private static readonly List<StaffSupplyItem> _supplies = new List<StaffSupplyItem>
        {
            new StaffSupplyItem { Id = 1, Name = "Gel siêu âm lạnh dẫn sóng Hifu (Can 5L)", StockQty = 3, Unit = "Can", Status = "Đầy đủ", RoomAssigned = "Phòng Hifu VIP" },
            new StaffSupplyItem { Id = 2, Name = "Mặt nạ tế bào gốc sinh học Biocellulose", StockQty = 12, Unit = "Miếng", Status = "Đầy đủ", RoomAssigned = "Tất cả phòng" },
            new StaffSupplyItem { Id = 3, Name = "Serum Hyaluronic Acid B5 phục hồi 100ml", StockQty = 2, Unit = "Chai", Status = "Sắp hết", RoomAssigned = "Phòng Laser 01" },
            new StaffSupplyItem { Id = 4, Name = "Khăn ủ ấm tiệt trùng dùng 1 lần", StockQty = 85, Unit = "Chiếc", Status = "Đầy đủ", RoomAssigned = "Kho trung tâm" },
            new StaffSupplyItem { Id = 5, Name = "Cồn y tế đỏ sát khuẩn & Bông gạc tiệt trùng", StockQty = 4, Unit = "Bộ", Status = "Đầy đủ", RoomAssigned = "Phòng Khám Bác Sĩ" }
        };

        // GET: /Staff/Dashboard
        public IActionResult Dashboard()
        {
            ViewBag.StaffName = HttpContext.Session.GetString("UserName") ?? "Nguyễn Thu Trang";
            ViewBag.StaffRole = HttpContext.Session.GetString("UserRoleTitle") ?? "Kỹ thuật viên Trưởng";
            ViewBag.ActiveBeds = _rooms.Count(r => r.Status == "Đang phục vụ");
            ViewBag.ReadyBeds = _rooms.Count(r => r.Status == "Sẵn sàng");
            ViewBag.CleaningBeds = _rooms.Count(r => r.Status == "Đang vô trùng" || r.Status == "Chờ khách vào");
            ViewBag.TodayGuests = 16;
            ViewBag.CompletedGuests = 8;
            ViewBag.ShiftCommission = "850.000 đ";

            return View(_rooms);
        }

        // GET: /Staff/CheckIn
        public IActionResult CheckIn(int? roomId)
        {
            ViewBag.StaffName = HttpContext.Session.GetString("UserName") ?? "Nguyễn Thu Trang";
            ViewBag.PreselectedRoomId = roomId ?? 0;
            return View(_rooms);
        }

        // GET: /Staff/Appointments
        public IActionResult Appointments()
        {
            ViewBag.StaffName = HttpContext.Session.GetString("UserName") ?? "Nguyễn Thu Trang";
            return View(_tasks);
        }

        // GET: /Staff/POS
        public IActionResult POS()
        {
            ViewBag.StaffName = HttpContext.Session.GetString("UserName") ?? "Nguyễn Thu Trang";
            return View();
        }

        // GET: /Staff/Supplies
        public IActionResult Supplies()
        {
            ViewBag.StaffName = HttpContext.Session.GetString("UserName") ?? "Nguyễn Thu Trang";
            return View(_supplies);
        }

        // POST: /Staff/QuickCheckIn
        [HttpPost]
        public IActionResult QuickCheckIn([FromBody] StaffCheckInRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.CustomerName))
            {
                return BadRequest(new { success = false, message = "Vui lòng nhập tên khách hàng tiếp đón." });
            }

            var bed = _rooms.FirstOrDefault(r => r.RoomId == request.RoomId) ?? _rooms.FirstOrDefault(r => r.Status == "Sẵn sàng") ?? _rooms.First();
            bed.CustomerName = request.CustomerName.Trim();
            bed.ServiceName = string.IsNullOrWhiteSpace(request.ServiceName) ? "Liệu trình chăm sóc da chuẩn" : request.ServiceName;
            bed.Status = "Đang phục vụ";
            bed.StartTime = DateTime.Now.ToString("HH:mm");
            bed.ElapsedMinutes = 0;
            bed.Notes = $"Tiếp đón lúc {DateTime.Now:HH:mm}. Khách hẹn trực tiếp tại quầy.";

            return Ok(new
            {
                success = true,
                message = $"Đã Check-in thành công khách hàng [{request.CustomerName}] vào {bed.RoomName} ({bed.BedCode})!",
                room = bed
            });
        }

        // POST: /Staff/UpdateBedStatus
        [HttpPost]
        public IActionResult UpdateBedStatus([FromBody] UpdateBedStatusRequest request)
        {
            if (request == null) return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ." });

            var bed = _rooms.FirstOrDefault(r => r.RoomId == request.RoomId);
            if (bed == null) return NotFound(new { success = false, message = "Không tìm thấy phòng/giường." });

            bed.Status = request.NewStatus;
            if (request.NewStatus == "Sẵn sàng")
            {
                bed.CustomerName = "Chưa có khách";
                bed.ServiceName = "Sẵn sàng đón khách mới";
                bed.StartTime = "--:--";
                bed.ElapsedMinutes = 0;
                bed.Notes = "Buồng phòng đã được làm sạch và khử khuẩn hoàn tất.";
            }
            else if (request.NewStatus == "Đang vô trùng")
            {
                bed.Notes = "Đang bật đèn UV khử khuẩn 15 phút.";
            }

            return Ok(new { success = true, message = $"Đã cập nhật trạng thái {bed.BedCode} thành '{bed.Status}'!", room = bed });
        }

        // POST: /Staff/CompleteTask
        [HttpPost]
        public IActionResult CompleteTask([FromBody] CompleteTaskRequest request)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == request.TaskId);
            if (task == null) return NotFound(new { success = false, message = "Không tìm thấy ca hẹn." });

            task.Status = "Đã hoàn thành";
            task.ProgressPercent = 100;

            // Đồng bộ giải phóng giường nếu có
            var bed = _rooms.FirstOrDefault(r => r.CustomerName.Contains(task.CustomerName));
            if (bed != null)
            {
                bed.Status = "Đang vô trùng";
                bed.Notes = $"Vừa hoàn tất ca cho khách {task.CustomerName}. Cần thay drap và sát khuẩn.";
            }

            return Ok(new
            {
                success = true,
                message = $"Đã hoàn tất ca phục vụ cho khách hàng [{task.CustomerName}]! Hệ thống đã ghi nhận hoa hồng dịch vụ.",
                task = task
            });
        }

        // POST: /Staff/ProcessPOSOrder
        [HttpPost]
        public IActionResult ProcessPOSOrder([FromBody] POSOrderRequest request)
        {
            if (request == null || request.Items == null || !request.Items.Any())
            {
                return BadRequest(new { success = false, message = "Giỏ hàng trống!" });
            }

            var orderCode = "LUNA-POS-" + DateTime.Now.ToString("yyMMdd-HHmmss");
            var totalAmount = request.Items.Sum(i => i.Price * i.Qty);
            var discount = request.IsVipMember ? (totalAmount * 0.1) : 0;
            var finalTotal = totalAmount - discount;

            return Ok(new
            {
                success = true,
                orderCode = orderCode,
                customerName = request.CustomerName ?? "Khách lẻ tại quầy",
                subtotal = totalAmount,
                discount = discount,
                finalTotal = finalTotal,
                paymentMethod = request.PaymentMethod ?? "VietQR",
                message = $"Thanh toán thành công đơn hàng #{orderCode}! Đã xuất hóa đơn điện tử."
            });
        }

        // POST: /Staff/RequestSupply
        [HttpPost]
        public IActionResult RequestSupply([FromBody] SupplyRequestModel request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.ItemName))
            {
                return BadRequest(new { success = false, message = "Vui lòng chọn vật tư cần bổ sung." });
            }

            return Ok(new
            {
                success = true,
                message = $"Đã gửi phiếu yêu cầu cấp {request.Quantity} {request.Unit} '{request.ItemName}' đến Kho Trung Tâm!"
            });
        }
    }

    // Các Models bổ trợ cho Staff
    public class StaffRoomBed
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public string BedCode { get; set; } = string.Empty;
        public string AssignedStaff { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public string Status { get; set; } = "Sẵn sàng"; // "Đang phục vụ", "Sẵn sàng", "Chờ khách vào", "Đang vô trùng"
        public string StartTime { get; set; } = "--:--";
        public int DurationMinutes { get; set; } = 60;
        public int ElapsedMinutes { get; set; } = 0;
        public string Notes { get; set; } = string.Empty;
    }

    public class StaffAppointmentTask
    {
        public int Id { get; set; }
        public string TimeSlot { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public string RoomBed { get; set; } = string.Empty;
        public string Status { get; set; } = "Chưa đến"; // "Chưa đến", "Sắp diễn ra", "Đang thực hiện", "Đã hoàn thành"
        public int ProgressPercent { get; set; } = 0;
        public string ProtocolSteps { get; set; } = string.Empty;
    }

    public class StaffSupplyItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StockQty { get; set; }
        public string Unit { get; set; } = "Hộp";
        public string Status { get; set; } = "Đầy đủ"; // "Đầy đủ", "Sắp hết", "Hết hàng"
        public string RoomAssigned { get; set; } = string.Empty;
    }

    public class StaffCheckInRequest
    {
        public int RoomId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
    }

    public class UpdateBedStatusRequest
    {
        public int RoomId { get; set; }
        public string NewStatus { get; set; } = string.Empty;
    }

    public class CompleteTaskRequest
    {
        public int TaskId { get; set; }
    }

    public class POSOrderRequest
    {
        public string CustomerName { get; set; } = string.Empty;
        public bool IsVipMember { get; set; } = false;
        public string PaymentMethod { get; set; } = "VietQR";
        public List<POSOrderItem> Items { get; set; } = new List<POSOrderItem>();
    }

    public class POSOrderItem
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Qty { get; set; }
    }

    public class SupplyRequestModel
    {
        public string ItemName { get; set; } = string.Empty;
        public int Quantity { get; set; } = 1;
        public string Unit { get; set; } = "Lọ";
    }
}
