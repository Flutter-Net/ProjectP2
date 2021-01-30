using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Flutter.Domain.Models;
using Flutter.Storing;

namespace Flutter.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly FlutterContext _ctx;

        public UserController(FlutterContext context)
        {
            _ctx = context;
        }


        [HttpGet("/users")]
        public async Task<IActionResult> Get()
        {
            var users = _ctx.Users.ToList();

            return await Task.FromResult(Ok(users));

        }
        
    }
}

