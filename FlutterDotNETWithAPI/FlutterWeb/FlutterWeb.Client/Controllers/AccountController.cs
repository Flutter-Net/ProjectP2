using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;

namespace FlutterWeb.Client.Controllers
{


    [Route("[controller]")]
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OktaDefaults.MvcAuthenticationScheme);
            }

            return RedirectToAction("index", "Home");
        }
        [HttpPost]
        public SignOutResult PostSignOut()
        {
            return new SignOutResult(
                new[]
                {
                OktaDefaults.MvcAuthenticationScheme,
                CookieAuthenticationDefaults.AuthenticationScheme,
             },
                new AuthenticationProperties { RedirectUri = "/" });
        }
    }
}