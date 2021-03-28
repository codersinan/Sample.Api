using System.Collections.Generic;
using Sample.Api.Entities;

namespace Sample.Api.Requests
{
    public class PatchProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Tag> Tags { get; set; }
    }
}