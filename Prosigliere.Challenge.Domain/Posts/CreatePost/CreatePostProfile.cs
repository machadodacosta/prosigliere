using AutoMapper;
using Prosigliere.Challenge.Domain.Entities;

namespace Prosigliere.Challenge.Domain.Posts.CreatePost
{
    public class CreatePostProfile : Profile
    {
        public CreatePostProfile()
        {
            CreateMap<CreatePostCommand, BlogPost>();
            CreateMap<BlogPost, CreatePostResult>();
        }
    }
}
