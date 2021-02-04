using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using FlutterWeb.Client.Models;
using Okta.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace FlutterWeb.Client.Controllers
{

    [Route("[controller]")]
    public class HomeController : Controller
    {




        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }
        


        [HttpGet("/ComingSoon")]
        public IActionResult ComingSoon()
        {
            return View("ComingSoon");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
