using DomainLayer.Common;

namespace DomainLayer.Entities
{
    public class Car : BaseEntity
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Color { get; set; }
        public DateTime Year { get; set; }
        public int ModelId { get; set; }
        public Model? Model { get; set; }
    }
}
