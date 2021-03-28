using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Sample.Api.Mapping
{
    public class PatchMappings : Profile
    {
        public PatchMappings()
        {
            CreateMap(typeof(JsonPatchDocument<>), typeof(JsonPatchDocument<>));
            CreateMap(typeof(Operation<>), typeof(Operation<>));
        }
    }
}