using System.Collections.Generic;
using System.Linq;
using Flutter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Flutter.Domain.Abstracts;
using Flutter.Domain.Models;

namespace Flutter.Storing
{
    public class FlutterRepository
    {
        private FlutterContext _ctx;
        private int MyProperty { get; set; }

        public FlutterRepository(FlutterContext context)
        {
            _ctx = context;
        }
        // public void Add<T>(T item) where T :AEntity
        // {

        //     _ctx.Set<T>.Add(item);
        // }
        public void AddUser(AUser user)
        {
            _ctx.Users.Add(user);
        }
    }
}
