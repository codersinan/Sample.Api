using System;

namespace Sample.Api.Commons
{
    public abstract class Auditable
    {
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}