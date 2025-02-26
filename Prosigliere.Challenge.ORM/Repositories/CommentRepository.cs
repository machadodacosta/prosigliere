using Prosigliere.Challenge.Domain.Entities;
using Prosigliere.Challenge.Domain.Repositories;

namespace Prosigliere.Challenge.ORM.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Comment> CreateCommentAsync(Comment comment, CancellationToken cancellationToken = default)
        {
            await _context.Comments.AddAsync(comment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return comment;
        }
    }
}
