using MediatR;
using Prosigliere.Challenge.Domain.Entities;

namespace Prosigliere.Challenge.Domain.Posts.CreatePost
{
    public class CreatePostCommand : IRequest<CreatePostResult>
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
