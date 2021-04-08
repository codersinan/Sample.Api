
using Sample.Api.Commons;

namespace Sample.Api.Responses
{
    public class TagResponse:Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}