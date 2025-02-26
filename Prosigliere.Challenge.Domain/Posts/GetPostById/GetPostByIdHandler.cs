using AutoMapper;
using MediatR;
using Prosigliere.Challenge.Domain.Posts.GetAllPosts;
using Prosigliere.Challenge.Domain.Repositories;

namespace Prosigliere.Challenge.Domain.Posts.GetPostById
{
    public class GetPostByIdHandler : IRequestHandler<GetPostByIdCommand, GetPostByIdResult>
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _repository;
        public GetPostByIdHandler(IMapper mapper, IBlogPostRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetPostByIdResult> Handle(GetPostByIdCommand request, CancellationToken cancellationToken)
        {
            var blogPost = await _repository.GetByIdAsync(request.Id, cancellationToken);
            return _mapper.Map<GetPostByIdResult>(blogPost);
        }
    }
}
