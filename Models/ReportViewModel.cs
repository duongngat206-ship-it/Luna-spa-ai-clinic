using System;
using System.Collections.Generic;

namespace GiaoDienSpa.Models
{
    public class ReportViewModel
    {
        public ReportSummary Summary { get; set; } = new ReportSummary();
        public List<MonthlyRevenueItem> MonthlyRevenues { get; set; } = new List<MonthlyRevenueItem>();
        public List<CategoryRevenueItem> CategoryRevenues { get; set; } = new List<CategoryRevenueItem>();
        public List<StaffPerformanceItem> StaffPerformances { get; set; } = new List<StaffPerformanceItem>();
        public List<RoomOccupancyItem> RoomOccupancies { get; set; } = new List<RoomOccupancyItem>();
        public List<AiExecutiveInsight> AiInsights { get; set; } = new List<AiExecutiveInsight>();
        public List<RecentTransactionRecord> RecentTransactions { get; set; } = new List<RecentTransactionRecord>();
        public string SelectedRange { get; set; } = "Tháng 10/2026";
    }

    public class ReportSummary
    {
        public decimal TotalRevenue { get; set; } = 148500000;
        public decimal RevenueGrowthPercent { get; set; } = 14.8m;
        public int TotalAppointments { get; set; } = 142;
        public int SuccessfulAppointments { get; set; } = 138;
        public decimal CompletionRate => TotalAppointments > 0 ? Math.Round((decimal)SuccessfulAppointments / TotalAppointments * 100, 1) : 0;
        public int TotalNewCustomers { get; set; } = 38;
        public decimal VipCustomerRatio { get; set; } = 42.5m;
        public decimal AverageTicketValue { get; set; } = 2150000;
        public decimal OperatingCost { get; set; } = 59300000;
        public decimal NetProfit => TotalRevenue - OperatingCost;
        public decimal ProfitMargin => TotalRevenue > 0 ? Math.Round((NetProfit / TotalRevenue) * 100, 1) : 0;
    }

    public class MonthlyRevenueItem
    {
        public string MonthName { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
        public decimal Target { get; set; }
        public int PercentAchieved => Target > 0 ? (int)Math.Min(Math.Round(Revenue / Target * 100), 120) : 0;
    }

    public class CategoryRevenueItem
    {
        public string CategoryName { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
        public decimal Percentage { get; set; }
        public string Icon { get; set; } = "✦";
        public string ColorHex { get; set; } = "#a76d8e";
    }

    public class StaffPerformanceItem
    {
        public string StaffName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int CompletedServices { get; set; }
        public decimal RevenueContribution { get; set; }
        public decimal CustomerRating { get; set; } = 4.9m;
        public string CommissionTier { get; set; } = "Thưởng Hạng A (15%)";
    }

    public class RoomOccupancyItem
    {
        public string RoomName { get; set; } = string.Empty;
        public int TotalHoursBooked { get; set; }
        public int OccupancyRate { get; set; } // %
        public string PeakHour { get; set; } = "15:00 - 18:30";
        public string Status { get; set; } = "Tối ưu";
    }

    public class AiExecutiveInsight
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImpactType { get; set; } = "Tăng trưởng"; // "Tăng trưởng", "Cảnh báo", "Cơ hội"
        public string ActionRecommendation { get; set; } = string.Empty;
    }

    public class RecentTransactionRecord
    {
        public string Code { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string ServiceSummary { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Status { get; set; } = "Hoàn tất";
    }
}
