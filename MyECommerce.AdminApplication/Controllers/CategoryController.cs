using MyECommerce.Business.Abstract;
using MyECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyECommerce.AdminApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult List()
        {
            return View(_categoryService.GetAll().OrderBy(o => o.Id));
        }

        public ActionResult Add()
        {
            ViewBag.Title = "Kategori Ekle";

            ViewBag.ParentID = new SelectList(items: _categoryService.GetAll(),
                                dataValueField: "Id",
                                dataTextField: "UrlName");
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            ViewBag.ParentID = new SelectList(items: _categoryService.GetAll(),
                                dataValueField: "Id",
                                dataTextField: "UrlName");

            try
            {
                ModelState.Remove("Id");
                ModelState.Remove("ParentId");
                if (ModelState.IsValid)
                {
                    _categoryService.Add(category);

                    return RedirectToAction("List");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }

        [HttpPost]
        public ActionResult DeleteCategory(int categoryId)
        {
            var category = _categoryService.GetCategoryById(categoryId);
            _categoryService.Delete(category);
            var newcategoryList = _categoryService.GetAll().OrderBy(o => o.Id);
            return PartialView("_TableList", newcategoryList);
        }

    }
}