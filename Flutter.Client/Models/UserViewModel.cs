using System;
using System.Collections.Generic;
using Flutter.Domain.Models;

namespace Flutter.Client.Models
{

    public class UserViewModel
    {
        public string UserName {get;set;}

        public string Password {get;set;}

        public DateTime DateCreated {get;}

        public string AboutMe {get;set;}

        public List<Post> Posts {get;set;}

        public List<long> PostIds {get;set;}

        public List<string> Users {get;set;}

    }

}