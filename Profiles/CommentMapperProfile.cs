using AutoMapper;
using dotnet_web_api.DTOs.Comment;
using dotnet_web_api.Models;

namespace dotnet_web_api.Profiles
{
    public class CommentMapperProfile : Profile
    {
        public CommentMapperProfile()
        {
            CreateMap<Comment, CommentDto>();
        }
    }
}
