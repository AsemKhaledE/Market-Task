using Market.Models;
using Market.Models.Repositories;
using Market.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            var users = _userRepository.List();
            return View(users);
        }
        [HttpPost]
        public IActionResult AddUserOfList(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Add(userViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
        }

        public ActionResult EditUser(int id)
        {
            var user = _userRepository.GetOne(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(int id, UserViewModel user)
        {

            _userRepository.Update(id, user);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            string isAdmin = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaimTypes.IsAdmin)!.Value;
            if (Convert.ToBoolean(isAdmin))
            {
                _userRepository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Search(string term)
        {
            var result = _userRepository.Search(term);
            return View("Index", result);
        }

    }
}
