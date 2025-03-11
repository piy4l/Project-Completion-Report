namespace PCRMS.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string? Name { get; set; }
        public string? Designation { get; set; } 
        public byte[]? Signature { get; set; }
        public byte[]? Seal { get; set; }
        public string PasswordHash { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; } // "Admin", "PD", "ED", "Sec"
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
