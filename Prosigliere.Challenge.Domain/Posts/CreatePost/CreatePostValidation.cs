using FluentValidation;

namespace Prosigliere.Challenge.Domain.Posts.CreatePost
{
    public class CreatePostValidation : AbstractValidator<CreatePostCommand>
    {
        public CreatePostValidation()
        {
            RuleFor(f => f.Title).MinimumLength(5).MaximumLength(150).WithMessage("Title should have between 5 and 150 caracters.");
            RuleFor(f => f.Content).MinimumLength(5).MaximumLength(150).WithMessage("Content should have between 5 and 150 caracters.");
        }
    }
}
