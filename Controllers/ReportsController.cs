using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GiaoDienSpa.Models;

namespace GiaoDienSpa.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index(string range = "this_month")
        {
            var model = GenerateReportData(range);
            return View(model);
        }

        [HttpGet]
        public IActionResult GetFilteredReport(string range = "this_month")
        {
            var data = GenerateReportData(range);
            return Json(new { success = true, data = data });
        }

        [HttpGet]
        public IActionResult ExportReport(string format = "excel")
        {
            string fileName = $"BaoCao_LunaSpa_{DateTime.Now:yyyyMMdd_HHmm}.{(format == "pdf" ? "pdf" : "xlsx")}";
            return Json(new
            {
                success = true,
                message = $"Đã tạo và sẵn sàng tải tệp báo cáo: {fileName}",
                fileName = fileName,
                downloadUrl = $"#download-{fileName}"
            });
        }

        private ReportViewModel GenerateReportData(string range)
        {
            var model = new ReportViewModel();

            if (range == "today")
            {
                model.SelectedRange = "Hôm nay (" + DateTime.Now.ToString("dd/MM/yyyy") + ")";
                model.Summary = new ReportSummary
                {
                    TotalRevenue = 12450000,
                    RevenueGrowthPercent = 8.5m,
                    TotalAppointments = 14,
                    SuccessfulAppointments = 14,
                    TotalNewCustomers = 4,
                    VipCustomerRatio = 50.0m,
                    AverageTicketValue = 1850000,
                    OperatingCost = 4800000
                };
            }
            else if (range == "this_week")
            {
                model.SelectedRange = "Tuần này (20/10 - 27/10/2026)";
                model.Summary = new ReportSummary
                {
                    TotalRevenue = 46800000,
                    RevenueGrowthPercent = 12.4m,
                    TotalAppointments = 48,
                    SuccessfulAppointments = 46,
                    TotalNewCustomers = 12,
                    VipCustomerRatio = 45.0m,
                    AverageTicketValue = 2050000,
                    OperatingCost = 18200000
                };
            }
            else if (range == "this_quarter")
            {
                model.SelectedRange = "Quý 4/2026";
                model.Summary = new ReportSummary
                {
                    TotalRevenue = 385000000,
                    RevenueGrowthPercent = 21.5m,
                    TotalAppointments = 390,
                    SuccessfulAppointments = 378,
                    TotalNewCustomers = 96,
                    VipCustomerRatio = 48.0m,
                    AverageTicketValue = 2280000,
                    OperatingCost = 152000000
                };
            }
            else
            {
                model.SelectedRange = "Tháng 10/2026";
                model.Summary = new ReportSummary
                {
                    TotalRevenue = 148500000,
                    RevenueGrowthPercent = 14.8m,
                    TotalAppointments = 142,
                    SuccessfulAppointments = 138,
                    TotalNewCustomers = 38,
                    VipCustomerRatio = 42.5m,
                    AverageTicketValue = 2150000,
                    OperatingCost = 59300000
                };
            }

            // Biểu đồ tăng trưởng 6 tháng gần nhất
            model.MonthlyRevenues = new List<MonthlyRevenueItem>
            {
                new MonthlyRevenueItem { MonthName = "Tháng 05", Revenue = 92000000, Target = 90000000 },
                new MonthlyRevenueItem { MonthName = "Tháng 06", Revenue = 108000000, Target = 100000000 },
                new MonthlyRevenueItem { MonthName = "Tháng 07", Revenue = 115000000, Target = 110000000 },
                new MonthlyRevenueItem { MonthName = "Tháng 08", Revenue = 128000000, Target = 120000000 },
                new MonthlyRevenueItem { MonthName = "Tháng 09", Revenue = 135000000, Target = 130000000 },
                new MonthlyRevenueItem { MonthName = "Tháng 10", Revenue = model.Summary.TotalRevenue, Target = 140000000 }
            };

            // Cơ cấu doanh thu theo nhóm dịch vụ
            model.CategoryRevenues = new List<CategoryRevenueItem>
            {
                new CategoryRevenueItem { CategoryName = "Trẻ hóa công nghệ cao (Laser & Hifu)", Revenue = 77220000, Percentage = 52, Icon = "✦", ColorHex = "#a76d8e" },
                new CategoryRevenueItem { CategoryName = "Chăm sóc da & Trị liệu chuyên sâu", Revenue = 35640000, Percentage = 24, Icon = "✿", ColorHex = "#c786a9" },
                new CategoryRevenueItem { CategoryName = "Massage thư giãn & Body thảo dược", Revenue = 20790000, Percentage = 14, Icon = "♧", ColorHex = "#5b9e78" },
                new CategoryRevenueItem { CategoryName = "Dược mỹ phẩm bán lẻ chăm sóc tại nhà", Revenue = 14850000, Percentage = 10, Icon = "🧴", ColorHex = "#d68e3d" }
            };

            // Bảng xếp hạng chuyên viên / bác sĩ xuất sắc
            model.StaffPerformances = new List<StaffPerformanceItem>
            {
                new StaffPerformanceItem { StaffName = "Bác sĩ Lê Hoàng Yến", Position = "Bác sĩ Chuyên khoa Da liễu", CompletedServices = 46, RevenueContribution = 62500000, CustomerRating = 5.0m, CommissionTier = "Hạng Xuất Sắc (20%)" },
                new StaffPerformanceItem { StaffName = "Nguyễn Thu Trang", Position = "Kỹ thuật viên Trưởng", CompletedServices = 41, RevenueContribution = 38200000, CustomerRating = 4.95m, CommissionTier = "Hạng A (15%)" },
                new StaffPerformanceItem { StaffName = "Đặng Thùy Dung", Position = "Kỹ thuật viên Massage & Body", CompletedServices = 34, RevenueContribution = 24800000, CustomerRating = 4.9m, CommissionTier = "Hạng A (15%)" },
                new StaffPerformanceItem { StaffName = "Vũ Khánh Linh", Position = "Kỹ thuật viên Trị mụn & Peel", CompletedServices = 29, RevenueContribution = 18600000, CustomerRating = 4.85m, CommissionTier = "Hạng B (10%)" },
                new StaffPerformanceItem { StaffName = "Lâm Mỹ Duyên", Position = "Kỹ thuật viên Gội đầu & Chăm sóc", CompletedServices = 22, RevenueContribution = 14400000, CustomerRating = 4.8m, CommissionTier = "Hạng B (10%)" }
            };

            // Công suất lấp đầy phòng trị liệu
            model.RoomOccupancies = new List<RoomOccupancyItem>
            {
                new RoomOccupancyItem { RoomName = "Phòng Laser Công nghệ cao (Tầng 2)", TotalHoursBooked = 168, OccupancyRate = 92, PeakHour = "15:00 - 19:30", Status = "Rất cao" },
                new RoomOccupancyItem { RoomName = "Phòng Trị liệu VIP 01 (Tầng 1)", TotalHoursBooked = 152, OccupancyRate = 85, PeakHour = "10:30 - 17:00", Status = "Tối ưu" },
                new RoomOccupancyItem { RoomName = "Phòng Trị mụn Y khoa (Tầng 1)", TotalHoursBooked = 138, OccupancyRate = 78, PeakHour = "14:00 - 18:00", Status = "Ổn định" },
                new RoomOccupancyItem { RoomName = "Phòng Thư giãn Body 02 (Tầng 2)", TotalHoursBooked = 124, OccupancyRate = 72, PeakHour = "16:30 - 20:30", Status = "Tốt" }
            };

            // Khuyến nghị điều hành từ Luna AI
            model.AiInsights = new List<AiExecutiveInsight>
            {
                new AiExecutiveInsight
                {
                    Title = "Đòn bẩy doanh thu: Gói Combo Trẻ Hóa Glow Up",
                    Description = "Dịch vụ Laser Pico và Hifu tiếp tục chiếm hơn 52% tổng doanh thu. Tỷ lệ khách mua kèm Serum B5 tại quầy đạt 78%, giúp biên lợi nhuận ròng tăng thêm 4.2% so với tháng trước.",
                    ImpactType = "Tăng trưởng",
                    ActionRecommendation = "Tiếp tục chạy chiến dịch khuyến mãi tặng quà mặt nạ vàng cho gói thẻ combo 3 buổi."
                },
                new AiExecutiveInsight
                {
                    Title = "Cảnh báo nghẽn công suất Phòng Laser giờ cao điểm",
                    Description = "Khung giờ 16:30 - 19:30 phòng Laser đạt 98% công suất, dẫn đến thời gian chờ của một số khách bị kéo dài thêm 8-12 phút.",
                    ImpactType = "Cảnh báo",
                    ActionRecommendation = "Khuyến khích khách đặt khung giờ sáng (09:00 - 11:30) bằng cách tặng voucher chiết khấu 10% tại khung giờ thấp điểm."
                },
                new AiExecutiveInsight
                {
                    Title = "Cơ hội: Nhóm khách hàng Kim cương & VIP tăng trưởng",
                    Description = "Số lượng hội viên VIP tăng thêm 14 khách trong tháng, với mức chi tiêu bình quân trên 8.500.000 đ/người/tháng.",
                    ImpactType = "Cơ hội",
                    ActionRecommendation = "Tổ chức sự kiện Private Workshop giới thiệu công nghệ Trẻ Hóa Da Mới độc quyền vào đầu tháng 11."
                }
            };

            // Nhật ký giao dịch gần đây
            model.RecentTransactions = new List<RecentTransactionRecord>
            {
                new RecentTransactionRecord { Code = "HD-20261027-01", CustomerName = "Nguyễn Minh Anh", ServiceSummary = "Trẻ hóa Laser Pico Pro + Serum B5", Amount = 4450000, PaymentMethod = "Chuyển khoản QR", Date = DateTime.Now.AddHours(-1), Status = "Hoàn tất" },
                new RecentTransactionRecord { Code = "HD-20261027-02", CustomerName = "Trần Thị Mai Phương", ServiceSummary = "Nâng cơ trẻ hóa Hifu Ultra Collagen", Amount = 3800000, PaymentMethod = "Thẻ POS", Date = DateTime.Now.AddHours(-3), Status = "Hoàn tất" },
                new RecentTransactionRecord { Code = "HD-20261027-03", CustomerName = "Phạm Ngọc Mai", ServiceSummary = "Combo Aqua Detox & Massage Cổ Vai Gáy", Amount = 1100000, PaymentMethod = "Chuyển khoản QR", Date = DateTime.Now.AddHours(-5), Status = "Hoàn tất" },
                new RecentTransactionRecord { Code = "HD-20261027-04", CustomerName = "Hoàng Kim Oanh", ServiceSummary = "Trị mụn y khoa & Chiếu ánh sáng sinh học", Amount = 550000, PaymentMethod = "Tiền mặt", Date = DateTime.Now.AddHours(-7), Status = "Hoàn tất" },
                new RecentTransactionRecord { Code = "HD-20261026-05", CustomerName = "Đỗ Thùy Trang", ServiceSummary = "Trẻ hóa da Laser Pico Pro (Buổi 2)", Amount = 2500000, PaymentMethod = "Chuyển khoản QR", Date = DateTime.Now.AddDays(-1), Status = "Hoàn tất" }
            };

            return model;
        }
    }
}
