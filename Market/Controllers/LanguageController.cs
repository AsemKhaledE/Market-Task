﻿using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Market.Controllers
{
    public class LanguageController : Controller
    {
        private readonly IStringLocalizer<LanguageController> _localizer;

        public LanguageController(IStringLocalizer<LanguageController> localizer)
        {
            _localizer = localizer;
        }
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
