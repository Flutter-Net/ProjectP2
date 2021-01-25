using Flutter.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Flutter.Storing
{
    public class FlutterContext : DbContext
    {
        public DbSet<AUser> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags {get;set;}
        public FlutterContext(DbContextOptions<FlutterContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //build entities here
            builder.Entity<AUser>().HasKey(u => u.EntityId);
            builder.Entity<Post>().HasKey(p => p.EntityId);
            builder.Entity<Tag>().HasKey(t => t.EntityId);
        }
    }
}