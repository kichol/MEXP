using MediaExpert.Products.Domain.Common;

namespace MediaExpert.Products.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }


    }
}
