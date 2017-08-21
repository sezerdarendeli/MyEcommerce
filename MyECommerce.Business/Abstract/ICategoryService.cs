using MyECommerce.Entities.Concrete;
using System.Collections.Generic;

namespace MyECommerce.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();

        Category Add(Category category);

        Category GetCategoryById(int id);

        Category GetCategoryByUrlName(string urlName);

        void Delete(Category category);
    }
}
