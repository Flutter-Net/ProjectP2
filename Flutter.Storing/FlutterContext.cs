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
            builder.Entity<AUser>().HasKey(user => user.EntityId);
            builder.Entity<AUser>().OwnsMany(user => user.Posts);

            builder.Entity<Post>().HasKey(post => post.EntityId);
            builder.Entity<Post>().HasMany(post => post.TagIds).WithMany(tag => tag.TaggedPosts);

            builder.Entity<Tag>().HasKey(tag => tag.EntityId);
            
        }
    }
}