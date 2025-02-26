using AutoMapper;
using MediatR;
using Prosigliere.Challenge.Domain.Repositories;

namespace Prosigliere.Challenge.Domain.Posts.GetAllPosts
{
    public class GetAllPostsHandler : IRequestHandler<GetAllPostsCommand, IList<GetAllPostsResult>>
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _repository;

        public GetAllPostsHandler(IMapper mapper, IBlogPostRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        
        public async Task<IList<GetAllPostsResult>> Handle(GetAllPostsCommand request, CancellationToken cancellationToken)
        {
            var getBlogPosts = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<IList<GetAllPostsResult>>(getBlogPosts);
        }
    }
}
