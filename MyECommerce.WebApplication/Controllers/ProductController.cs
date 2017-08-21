using MyEcommerce.Entities.ViewModel;
using MyECommerce.Business.Abstract;
using MyECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyECommerce.WebApplication.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductService _productService;
        public readonly ICategoryService _categoryService;
        // GET: Product

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public ActionResult Detail(string urlName)
        {
            var productViewModel = new ProductDetailViewModel();

            var product = _productService.GetProductByUrlName(urlName);

            var category = _categoryService.GetCategoryById(product.CategoryId);
            var parentCategory = _categoryService.GetCategoryById(category.ParentId);//bulunan categoryId ye göre  parrentcategory classı doldurulur.


            productViewModel.Product = product;
            ViewBag.Title = product.Name;

            return View(productViewModel);
        }

        public ActionResult  HomeProductList()
        {

            var productList = _productService.GetAll().Take(12).ToList();

            return View(productList);
        }
    }
}