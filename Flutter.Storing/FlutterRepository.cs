using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
        public void AddUser(string name, string password){
            var user = new AUser(name,password);
            _ctx.Users.Add(user);
        }
        public void AddPost(long inputUserId, string inputContent, long CommentOf, IEnumerable<long> Tags){
            var post = new Post(inputUserId,inputContent,CommentOf,Tags);
            _ctx.Users.Add(post);
        }
        public void AddTag(string name){
            var tag = new Tag(name);
            _ctx.Tags.Add(tag);
        }
        // public IEnumerable<Store> GetStores()
        // {
        //     return _ctx.Stores;
        // }
        // public IEnumerable<User> GetUsers()
        // {
        //     return _ctx.Users;
        // }
        // public User GetUser(long id)
        // {
        //     return _ctx.Users.Include(user => user.Orders).ThenInclude(order => order.Pizzas).ThenInclude(pizza => pizza.Crust).
        //     Include(user => user.Orders).ThenInclude(order => order.Pizzas).ThenInclude(pizza => pizza.Size).
        //     Include(user => user.Orders).ThenInclude(Order => Order.Pizzas).ThenInclude(pizza => pizza.Toppings).
        //     FirstOrDefault(user => user.EntityId == id);
        // }
        // public Post GetPost(string id)
        // {
        //     return _ctx.Stores.Include(store => store.Orders).ThenInclude(order => order.Pizzas).ThenInclude(pizza => pizza.Crust).
        //     Include(store => store.Orders).ThenInclude(order => order.Pizzas).ThenInclude(pizza => pizza.Size).
        //     Include(store => store.Orders).ThenInclude(Order => Order.Pizzas).ThenInclude(pizza => pizza.Toppings).
        //     FirstOrDefault(Store => Store.EntityId == long.Parse(id));
        // }
        // public void Update()
        // {
        //     _ctx.SaveChanges();
        // }
    }
}