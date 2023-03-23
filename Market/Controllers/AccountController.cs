using Market.Models;
using Market.Models.Repositories;
using Market.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _loginRepository.GetUser(loginViewModel);
                if (user == null || user.Id == 0)
                    return View();
                else
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim(ApplicationClaimTypes.UserId, user.Id.ToString()));
                    identity.AddClaim(new Claim(ApplicationClaimTypes.IsAdmin, user.IsAdmin.ToString()));
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                    return RedirectToAction("Index", "User");
                }
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
        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            
            return RedirectToAction(nameof(Index));
        } 


    }
}

