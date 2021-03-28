using Sample.Api.Commons;

namespace Sample.Api.Entities
{
    public class Tag:Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}