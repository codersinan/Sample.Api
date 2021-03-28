using System.Collections.Generic;
using Sample.Api.Commons;

namespace Sample.Api.Entities
{
    public class Product : Auditable
    {
        public Product()
        {
            Tags = new List<Tag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<Tag> Tags { get; set; }
    }
}