using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Flutter.Client.Models;

namespace Flutter.Client.Controllers
{
    [Route("[controller]")]

    public class FeedController : Controller
    {
        

        [HttpGet]
        public IActionResult Feed()
        {
            return View("Feed");
        }

      
    }
}