using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prosigliere.Challenge.Domain.Posts.CreatePost;
using Prosigliere.Challenge.Domain.Posts.CreatePostComment;
using Prosigliere.Challenge.Domain.Posts.GetAllPosts;
using Prosigliere.Challenge.Domain.Posts.GetPostById;

namespace Prosigliere.Challenge.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IMediator _mediator;
        
        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var request = new GetAllPostsCommand();
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            var location = Url.Action("GetById", "Posts", new { id = result.Id });

            return Created(location, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new GetPostByIdCommand { Id = id };
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> CreateComment([FromRoute] int id, [FromBody] string content, CancellationToken cancellationToken)
        {
            var command = new CreatePostCommentCommand { IdBlogPost = id, Content = content };
            var result = await _mediator.Send(command, cancellationToken);
            var location = Url.Action("GetById", "Posts", new { id = id });

            return Created(location, result);
        }
    }
}
