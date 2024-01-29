using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjektniZadatakTiac.DTO.COMMENT.Response;
using ProjektniZadatakTiac.DTO.POST.Response;
using ProjektniZadatakTiac.DTO.USER.Response;
using ProjektniZadatakTiac.Models;

namespace ProjektniZadatakTiac.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Post, PostDTO>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<User, UserFollowerDTO>();
            CreateMap<User, UserFollowingDTO>();
            //CreateMap<Post, PostDTO>();

            //CreateMap<PostDTO, Post>()
            //.ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(tagName => new Tag { Name = tagName })));


            CreateMap<PostDTO, Post>()
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(tagName => new Tag { Name = tagName })));

            //CreateMap<PostDTO, Post>()
            //.ForMember(dest => dest.Tags, opt => opt.MapFrom(x => x.Tags));

            // CreateMap<Post, PostDTO>()
            //.ForMember(dest => dest.Tags, opt => opt.MapFrom(src => GetTags(src)));
            //CreateMap<Tag, TagDTO>().ReverseMap();
        }
    }
}
