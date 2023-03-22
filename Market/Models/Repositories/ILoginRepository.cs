using Market.ViewModel;

namespace Market.Models.Repositories
{
    public interface ILoginRepository
    {
        Boolean IsUserFound(LoginViewModel loginViewModel);

    }
}
