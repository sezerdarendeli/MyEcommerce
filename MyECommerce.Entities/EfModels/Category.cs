using MyECommerce.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyECommerce.Entities.Concrete
{
    [Table("Category")]
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlName { get; set; }
        public int ParentId { get; set; }
    }
}
