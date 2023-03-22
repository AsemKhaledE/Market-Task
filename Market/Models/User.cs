using System.ComponentModel.DataAnnotations;

namespace Market.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Boolean IsAdmin { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsVerified { get; set; }
        public Guid? Token { get; set; }
        public DateTime? ExpireDate { get; set; }

    }
}
