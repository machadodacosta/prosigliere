using Microsoft.EntityFrameworkCore;
using Prosigliere.Challenge.Domain.Entities;

namespace Prosigliere.Challenge.ORM
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context)
        {
                
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
