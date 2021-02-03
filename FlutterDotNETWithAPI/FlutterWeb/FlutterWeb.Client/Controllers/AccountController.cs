using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;

<<<<<<< HEAD
 [Route("[controller]")]
=======
[Route("[controller]")]
>>>>>>> ebd7818752fb3e751d60376c5f5580457495022d
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
