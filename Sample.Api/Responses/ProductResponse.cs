using System.Collections.Generic;
using Sample.Api.Commons;

namespace Sample.Api.Responses
{
    public class ProductResponse:Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<TagResponse> Tags { get; set; }
    }
}