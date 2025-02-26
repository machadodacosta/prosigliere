using Microsoft.EntityFrameworkCore;
using Prosigliere.Challenge.Domain.Entities;
using Prosigliere.Challenge.Domain.Repositories;

namespace Prosigliere.Challenge.ORM.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly AppDbContext _context;
        public BlogPostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BlogPost> CreateAsync(BlogPost blogPost, CancellationToken cancellationToken = default)
        {
            await _context.BlogPosts.AddAsync(blogPost, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return blogPost;
        }
        public async Task<IEnumerable<BlogPost>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _context.BlogPosts.Include(f=>f.Comments);
        }

        public Task<BlogPost> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _context.BlogPosts.Include(f => f.Comments).FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
