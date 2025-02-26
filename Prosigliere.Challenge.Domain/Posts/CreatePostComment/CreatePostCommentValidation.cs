using FluentValidation;

namespace Prosigliere.Challenge.Domain.Posts.CreatePostComment
{
    public class CreatePostCommentValidation : AbstractValidator<CreatePostCommentCommand>
    {
        public CreatePostCommentValidation()
        {
            RuleFor(f => f.Content).MinimumLength(5).MaximumLength(150).WithMessage("Content should have between 5 and 150 caracters.");
        }
    }
}
