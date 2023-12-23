using AutoMapper;
using BloggingSystem.Domain.Models;
using BloggingSystem.Models;

namespace BloggingSystem.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Blog, BlogModel>();
        CreateMap<BlogModel, Blog>();
        
        CreateMap<Post, PostModel>();
        CreateMap<PostModel, Post>();
    }

    
}