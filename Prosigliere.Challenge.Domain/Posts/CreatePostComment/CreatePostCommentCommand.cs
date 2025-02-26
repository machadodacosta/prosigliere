using MediatR;

namespace Prosigliere.Challenge.Domain.Posts.CreatePostComment
{
    public class CreatePostCommentCommand : IRequest<CreatePostCommentResult>
    {
        public int IdBlogPost { get; set; }
        public string Content { get; set; }
    }
}
