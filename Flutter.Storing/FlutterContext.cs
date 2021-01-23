using Flutter.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Flutter.Storing
{
    public class FlutterContext : DbContext
    {
        public DbSet<AUser> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public FlutterContext(DbContextOptions<FlutterContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //build entities here
        }
    }
}