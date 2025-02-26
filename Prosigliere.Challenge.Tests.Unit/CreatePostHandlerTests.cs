using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Prosigliere.Challenge.Domain.Entities;
using Prosigliere.Challenge.Domain.Posts.CreatePost;
using Prosigliere.Challenge.Domain.Repositories;

namespace Prosigliere.Challenge.Tests.Unit
{
    public class CreatePostHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _repository;

        public CreatePostHandlerTests()
        {
            _repository = Substitute.For<IBlogPostRepository>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public async Task CreatePostHandlerTest()
        {
            var blogPost = new BlogPost { Id = new Random().Next(10, 21), Title = "Teste", Content = "Content here...." };
            var command = new CreatePostCommand { Title = blogPost.Title, Content = blogPost.Content };
            var result = new CreatePostResult { Id = blogPost.Id };

            _mapper.Map<BlogPost>(command).Returns(blogPost);
            _mapper.Map<CreatePostResult>(blogPost).Returns(result);

            _repository.CreateAsync(Arg.Any<BlogPost>(), Arg.Any<CancellationToken>()).Returns(blogPost);

            var createPostResult = await new CreatePostHandler(_mapper, _repository).Handle(command, CancellationToken.None);

            createPostResult.Should().NotBeNull();
            createPostResult.Id.Should().Be(blogPost.Id);
            await _repository.Received(1).CreateAsync(Arg.Any<BlogPost>(), Arg.Any<CancellationToken>());
        }
    }
}
