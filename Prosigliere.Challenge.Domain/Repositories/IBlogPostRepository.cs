using Prosigliere.Challenge.Domain.Entities;

namespace Prosigliere.Challenge.Domain.Repositories
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateAsync(BlogPost blogPost, CancellationToken cancellationToken = default);

        Task<IEnumerable<BlogPost>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<BlogPost> GetByIdAsync(int id, CancellationToken cancellationToken = default);        
    }
}
