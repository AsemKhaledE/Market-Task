using Market.Models;
using Market.Models.Repositories;
using Market.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISignUpRepository _signUpRepository;

        private readonly ILoginRepository _loginRepository;

        public AccountController(ISignUpRepository signUpRepository, ILoginRepository loginRepository)
        {
            _signUpRepository = signUpRepository;
            _loginRepository = loginRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                _loginRepository.IsUserFound(loginViewModel);
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View(loginViewModel);
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _signUpRepository.SignUp(user);
                return RedirectToAction(nameof(Index));

            }
            else
            {
                return View(user);
            }
           
        }

    }
}
