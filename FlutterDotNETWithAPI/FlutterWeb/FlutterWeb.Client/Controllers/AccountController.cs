using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;

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
}
