using Prosigliere.Challenge.Domain.Entities;

namespace Prosigliere.Challenge.Domain.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment> CreateCommentAsync(Comment comment, CancellationToken cancellationToken = default);
    }
}
