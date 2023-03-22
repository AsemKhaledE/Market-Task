using Market.Data;
using Microsoft.EntityFrameworkCore;
namespace Market.Models.Repositories
{
    public class SignUpRepository : ISignUpRepository
    {

        MarketDbContext _context;
        public SignUpRepository(MarketDbContext context)
        {
            _context = context;
        }

        public void SignUp(User user)
        {
            var users = _context.Users;
            if (users == null || users.Count()==0)
            {
                user.IsAdmin = true;
            }
            _context.Users?.Add(user);
            _context.SaveChanges();
        }
    }
}
