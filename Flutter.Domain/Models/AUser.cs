using System;
using Flutter.Domain.Abstracts;

namespace Flutter.Domain.Models
{
    public class AUser : AEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public AUser()
        {
            DateCreated = DateTime.Now;
        }
    }
}