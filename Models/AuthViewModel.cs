using System;

namespace GiaoDienSpa.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "Customer"; // "Admin", "Doctor", "Staff", "Customer"
        public string RoleTitle { get; set; } = "Khách hàng Thân thiết";
        public string AvatarInitials { get; set; } = "KH";
        public string AvatarColor { get; set; } = "#a76d8e";
        public string Specialty { get; set; } = string.Empty; // Cho Bác sĩ, Nhân viên, Admin
        public string SkinConcern { get; set; } = string.Empty; // Cho Khách hàng
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }

    public class LoginModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "Customer"; // "Admin", "Doctor", "Staff", "Customer"
        public bool RememberMe { get; set; } = true;
    }

    public class RegisterModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Role { get; set; } = "Customer"; // "Admin", "Doctor", "Staff", "Customer"
        public string Specialty { get; set; } = string.Empty; // Dành cho Bác sĩ & Nhân viên
        public string AdminAccessCode { get; set; } = string.Empty; // Mã bảo mật quản trị (mặc định: LUNASPA2026)
        public string SkinConcern { get; set; } = string.Empty; // Dành cho khách hàng
    }

    public class UpdateProfileModel
    {
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? RoleTitle { get; set; }
        public string? Specialty { get; set; } // Dành cho Nhân viên / Bác sĩ / Admin
        public string? SkinConcern { get; set; } // Dành cho Khách hàng
        public string? AvatarColor { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmNewPassword { get; set; }
    }
}

