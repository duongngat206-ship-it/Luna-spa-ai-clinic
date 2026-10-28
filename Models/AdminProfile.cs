using System;

namespace GiaoDienSpa.Models
{
    public class AdminProfile
    {
        public string FullName { get; set; } = "Quản trị viên";
        public string RoleTitle { get; set; } = "Administrator";
        public string Email { get; set; } = "admin@lunaspa.vn";
        public string Phone { get; set; } = "0988 888 999";
        public string AvatarInitials { get; set; } = "AD";
        public string AvatarColor { get; set; } = "#a76d8e";
        public string Bio { get; set; } = "Tận tâm chăm sóc sức khỏe & sắc đẹp cho khách hàng theo chuẩn quốc tế 5 sao.";
        public string RoleBadge { get; set; } = "Quản trị viên tối cao (Full Access)";
        public string? NewPassword { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
