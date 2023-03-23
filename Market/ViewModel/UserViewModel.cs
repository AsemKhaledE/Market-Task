using Market.Models;

namespace Market.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public UserViewModel()
        {

        }

        public UserViewModel(User item)
        {
            Id = item.Id;
            IsAdmin = item.IsAdmin;
            UserName = item.UserName;
            FullName = item.FullName;
            Password = item.Password;
            Email = item.Email;
            Phone = item.Phone;
        }

        public User ToEntity()
        {
            return new User
            {
                Id = Id,
                UserName = UserName,
                Password = Password,
                FullName = FullName,
                Email = Email,
                Phone = Phone,
            };
        }
    }
}
