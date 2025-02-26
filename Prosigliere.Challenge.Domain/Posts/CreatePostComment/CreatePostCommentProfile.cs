using AutoMapper;
using Prosigliere.Challenge.Domain.Entities;

namespace Prosigliere.Challenge.Domain.Posts.CreatePostComment
{
    public class CreatePostCommentProfile : Profile
    {
        public CreatePostCommentProfile()
        {
            CreateMap<CreatePostCommentCommand, Comment>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.BlogPost, opt => opt.MapFrom(src => new BlogPost { Id = src.IdBlogPost }));

            CreateMap<Comment, CreatePostCommentResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdBlogPost, opt => opt.MapFrom(src => src.BlogPost.Id));
        }
    }

}
