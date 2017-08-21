using MyECommerce.Entities.Concrete;
using System.Collections.Generic;

namespace MyEcommerce.Entities.ViewModel
{
    public class CategoryViewModel : BaseViewModel
    {
        public List<Category> CategoryList { get; set; }

        public string CategoryName { get; set; }

        public int CurrenctCategoryId { get; set; }

        public List<Product> ProductList { get; set; }


    }
}
