using System;
using System.Collections.Generic;

namespace GiaoDienSpa.Models
{
    public class AiConsultationSession
    {
        public int SessionId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public int Age { get; set; } = 28;
        public string Gender { get; set; } = "Nữ";
        public string SkinType { get; set; } = "Da hỗn hợp thiên dầu";
        public string PrimaryConcern { get; set; } = "Nám & Tàn nhang";
        public string Lifestyle { get; set; } = "Văn phòng máy lạnh, thức khuya";
        public int SkinHealthScore { get; set; } = 74; // Thang 100
        public string AiDiagnosis { get; set; } = string.Empty;
        public List<string> RecommendedServices { get; set; } = new List<string>();
        public List<string> RecommendedCosmetics { get; set; } = new List<string>();
        public List<string> CareRoutineSteps { get; set; } = new List<string>();
        public string ExpectedImprovement { get; set; } = "Cải thiện 80-85% sau 3-5 buổi";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string AssignedDoctor { get; set; } = "Bác sĩ Lê Hoàng Yến";
    }

    public class AiChatMessage
    {
        public string Sender { get; set; } = "AI"; // "User" or "AI"
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public List<string> SuggestedActions { get; set; } = new List<string>();
    }

    public class SkinAnalysisRequest
    {
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public int Age { get; set; } = 25;
        public string Gender { get; set; } = "Nữ";
        public string SkinType { get; set; } = string.Empty;
        public string PrimaryConcern { get; set; } = string.Empty;
        public string Lifestyle { get; set; } = string.Empty;
        public bool IsSensitive { get; set; } = false;
    }

    public class ChatRequest
    {
        public string Message { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string SkinType { get; set; } = string.Empty;
    }
}
