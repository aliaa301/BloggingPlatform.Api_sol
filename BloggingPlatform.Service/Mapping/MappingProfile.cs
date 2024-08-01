using AutoMapper;
using BloggingPlatform.Data.Entities;
using BloggingPlatform.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogPost, BlogPostDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Follower, FollowerDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
