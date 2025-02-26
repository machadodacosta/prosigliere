using AutoMapper;
using FluentValidation;
using MediatR;
using Prosigliere.Challenge.Domain.Entities;
using Prosigliere.Challenge.Domain.Posts.CreatePost;
using Prosigliere.Challenge.Domain.Repositories;

namespace Prosigliere.Challenge.Domain.Posts.CreatePostComment
{
    public class CreatePostCommentHandler : IRequestHandler<CreatePostCommentCommand, CreatePostCommentResult>
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly ICommentRepository _commentRepository;

        public CreatePostCommentHandler(IMapper mapper, IBlogPostRepository blogPostRepository, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
            _commentRepository = commentRepository;
        }

        public async Task<CreatePostCommentResult> Handle(CreatePostCommentCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreatePostCommentValidation();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var blogPost = await _blogPostRepository.GetByIdAsync(command.IdBlogPost, cancellationToken);

            if (blogPost == null)
            {
                throw new ValidationException("Post not found.");
            }

            var comment = _mapper.Map<Comment>(command);
            comment.BlogPost = blogPost;

            var result = await _commentRepository.CreateCommentAsync(comment, cancellationToken);

            return _mapper.Map<CreatePostCommentResult>(result);
        }
    }
}
