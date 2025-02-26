using MediatR;
using FluentValidation;
using Prosigliere.Challenge.Domain.Repositories;
using Prosigliere.Challenge.Domain.Entities;
using AutoMapper;

namespace Prosigliere.Challenge.Domain.Posts.CreatePost
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, CreatePostResult>
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _repository;

        public CreatePostHandler(IMapper mapper, IBlogPostRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CreatePostResult> Handle(CreatePostCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreatePostValidation();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            
            var blogPost = _mapper.Map<BlogPost>(command);
            var createBlogPost = await _repository.CreateAsync(blogPost, cancellationToken);

            return _mapper.Map<CreatePostResult>(blogPost);
        }
    }
}
