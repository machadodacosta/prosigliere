using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Prosigliere.Challenge.Domain.Repositories;
using Prosigliere.Challenge.ORM.Repositories;

namespace Prosigliere.Challenge.IoC
{
    public static class Initializer
    {
        public static void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
        }
    }
}
