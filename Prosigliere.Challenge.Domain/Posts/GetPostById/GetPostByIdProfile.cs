using AutoMapper;
using Prosigliere.Challenge.Domain.Entities;

namespace Prosigliere.Challenge.Domain.Posts.GetPostById
{
    public class GetPostByIdProfile : Profile
    {
        public GetPostByIdProfile()
        {
            CreateMap<BlogPost, GetPostByIdResult>();
            CreateMap<Comment, GetPostByIdCommentResult>();
        }
    }
}
