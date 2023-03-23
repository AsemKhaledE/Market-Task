using Market.ViewModel;

namespace Market.Models.Repositories
{
    public interface ILoginRepository
    {
        UserViewModel GetUser(LoginViewModel loginViewModel);

    }
}
