using MyECommerce.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyECommerce.Entities.Concrete
{
    [Table("Product")]
    public class Product : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Descprition { get; set; }

        public string ImageUrl { get; set; }

        public string BrandName { get; set; }

        public int CategoryId { get; set; }

        public string CurrencyCode { get; set; }

        public string UrlName { get; set; }

    }
}
