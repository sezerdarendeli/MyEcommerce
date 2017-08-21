using MyECommerce.Business.Abstract;
using MyECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyECommerce.AdminApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;

        }

        public ActionResult List()
        {
            return View(_productService.GetAll().OrderBy(o => o.Id));
        }

        [HttpPost]
        public ActionResult DeleteProduct(int productId)
        {
            var product = _productService.GetProductById(productId);
            _productService.Delete(product);
            var newproductList = _productService.GetAll().OrderBy(o => o.Id);
            return PartialView("_TableList", newproductList);
        }

        public ActionResult Add()
        {
            ViewBag.Title = "Ürün Ekle";

            ViewBag.CategoryId = new SelectList(items: _categoryService.GetAll(),
                                dataValueField: "Id",
                                dataTextField: "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            ViewBag.CategoryId = new SelectList(items: _categoryService.GetAll(),
                                dataValueField: "Id",
                                dataTextField: "Name");

            try
            {
                ModelState.Remove("Id");
                ModelState.Remove("CategoryId");
                if (ModelState.IsValid)
                {
                    product.ImageUrl = "appletablet.jpg"; // ImageUpload ile resim yüklenebilirdi.
                    _productService.Add(product);

                    return RedirectToAction("List");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }
    }
}