using AutoMapper;
using Sample.Api.Entities;
using Sample.Api.Responses;

namespace Sample.Api.Mapping
{
    public class TagMappings : Profile
    {
        public TagMappings()
        {
            CreateMap<Tag, TagResponse>();
        }
    }
}