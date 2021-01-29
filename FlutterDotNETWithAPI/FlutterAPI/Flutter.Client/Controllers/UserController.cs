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
    private readonly FlutterRepository _ctx;

        public UserController(FlutterRepository context)
        {
            _ctx = context;
        }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var users = _ctx.GetAllUsers();

      return await Task.FromResult(Ok(users));

    }
  [HttpGet("/User/{id}")]
  public async Task<IActionResult> User(string id)
  {
      var user = _ctx.GetUser(id);

      return await Task.FromResult(Ok(user));
  }
  }
}

