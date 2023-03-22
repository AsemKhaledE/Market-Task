using Market.ViewModel;

namespace Market.Models.Repositories
{
    public interface IUserRepository
    {
        IList<UserViewModel> List();
        UserViewModel GetOne(int id); 
       void Add(UserViewModel userViewModel);
        void Update(int id, UserViewModel userViewModel);
        void Delete(int id);
        List<UserViewModel> Search(string term);
    }
}
