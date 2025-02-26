using MediatR;

namespace Prosigliere.Challenge.Domain.Posts.GetAllPosts
{
    public class GetAllPostsCommand : IRequest<IList<GetAllPostsResult>>
    {
    }
}
