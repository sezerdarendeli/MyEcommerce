using MyEcommerce.Entities.ViewModel;
using MyEcommerce.Web.Infrastructure;
using MyECommerce.Business.Abstract;
using MyECommerce.Business.Concrete;
using System.Linq;
using System.Web.Mvc;

namespace MyECommerce.WebApplication.Controllers
{
    public class CategoryController : BaseController
    {
        public readonly ICategoryService _categoryService;
        public readonly IProductService _productService;

        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        // GET: Product
        public ActionResult List(string categoryUrlName)
        {

            var categoryViewModel = new CategoryViewModel();

            var category = _categoryService.GetCategoryByUrlName(categoryUrlName);// Category urlName 'e göre kategori classı çekilir.
            var parentCategory = _categoryService.GetCategoryById(category.ParentId);//bulunan categoryId ye göre  parrentcategory classı doldurulur.
            var categoryList = _categoryService.GetAll();// Tüm kategori listesi çekilir kategori menüsü için.

            var productList = _productService.GetProductListByCategoryId(category.Id);


            //ViewModel Set edilmesi
            categoryViewModel.CategoryName = category.Name;
            categoryViewModel.CategoryList = categoryList.ToList();
            categoryViewModel.ProductList = productList.ToList();

            ViewBag.Title = category.Name;

            return View(categoryViewModel);
        }
    }
}