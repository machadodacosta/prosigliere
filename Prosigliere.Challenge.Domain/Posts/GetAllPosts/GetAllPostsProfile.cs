using AutoMapper;
using Prosigliere.Challenge.Domain.Entities;

namespace Prosigliere.Challenge.Domain.Posts.GetAllPosts
{
    public class GetAllPostsProfile : Profile
    {
        public GetAllPostsProfile()
        {
            CreateMap<BlogPost, GetAllPostsResult>()
                .ForMember(result => result.TotalComments, post => post.MapFrom(src => src.Comments.Count()));
        }
    }
}
