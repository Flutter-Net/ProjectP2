using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Flutter.Client.Models;
using Flutter.Storing;
using Flutter.Domain.Models;



namespace Flutter.Client.Controllers
{
    [Route("[controller]")]
    public class TagController : Controller
    {
        private readonly FlutterRepository _ctx;
        public TagController(FlutterRepository context)
        {
            _ctx = context;
        }

        [HttpGet("/Tags/{id}")]
        public IActionResult Tags(long id)
        {

            
            var list = _ctx.GetPostsTags(id);
            List<string> tagOutput = new List<string>();
            foreach(Tag tag in list){
                    tagOutput.Add(tag.TagName);
            }
         
            var post = _ctx.GetPost(id);
            var content = post.Content;

            var tags = new { tag=tagOutput,contents=content};

            return Json(tags);
        }
    }

}