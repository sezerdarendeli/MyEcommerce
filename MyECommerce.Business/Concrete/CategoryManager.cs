using MyECommerce.Business.Abstract;
using MyECommerce.DataLayer.Abstract;
using MyECommerce.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace MyECommerce.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category Add(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetList().ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.Get(m => m.Id == id);
        }


        public Category GetCategoryByUrlName(string urlName)
        {
            return _categoryRepository.Get(m => m.UrlName == urlName);
        }


        public void Delete(Category category)
        {
             _categoryRepository.Delete(category);
        }
      
    }
}
