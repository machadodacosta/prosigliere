using MediatR;

namespace Prosigliere.Challenge.Domain.Posts.GetPostById
{
    public class GetPostByIdCommand : IRequest<GetPostByIdResult>
    {
        public int Id { get; set; }
    }
}
