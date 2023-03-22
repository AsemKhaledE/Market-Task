using Market.Data;
using Market.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Market.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        MarketDbContext _context;

        public UserRepository(MarketDbContext context)
        {
            _context = context;
        }

        public void Add(UserViewModel userViewModel)
        {
            _context.Users?.Add(userViewModel.ToEntity());
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users!.FirstOrDefault(u => u.Id == id);
            _context.Users?.Remove(user!);
            _context.SaveChanges();
        }

        public  UserViewModel GetOne(int id)
        {
            var user = _context.Users!.Where(a => a.Id == id).Select(x => new UserViewModel(x)).FirstOrDefault();
            return user!;
        }

        public IList<UserViewModel> List()
        {
            var users = _context.Users!.ToList();
            var list = users.Select(u => new UserViewModel(u)).ToList();
            return list;
        }

        public void Update(int id, UserViewModel userViewModel)
        {
            if (id != null)
            {
                _context.Update(userViewModel.ToEntity());
                _context.SaveChanges();
            }

        }

        public List<UserViewModel> Search(string term)
        {
            var users = _context.Users!.Where(b => b.Email!.Contains(term)
                       || b.FullName!.Contains(term)
                       || b.UserName!.Contains(term)).ToList();

            return users.Select(x => new UserViewModel(x)).ToList();

        }



    }
}
