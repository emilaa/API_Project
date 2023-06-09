using DomainLayer.Common;

namespace DomainLayer.Entities
{
    public class Model : BaseEntity
    {
        public string? Name { get; set; }
        public int MarkaId { get; set; }
        public Marka? Marka { get; set; }
    }
}
