using Market.Data;
using Market.ViewModel;

namespace Market.Models.Repositories
{
    public class LoginRepository : ILoginRepository
    {

        MarketDbContext _context;
        public LoginRepository(MarketDbContext context)
        {
            _context = context;
        }
        public UserViewModel GetUser(LoginViewModel loginViewModel)
        {
            try
            {
                var user = _context.Users?.Where(u => u.UserName == loginViewModel.UserName
            & u.Password == loginViewModel.Password).FirstOrDefault();
                if (user!=null)
                {
                    return new UserViewModel(user);
                }
                return new UserViewModel();
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
