using MyECommerce.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyECommerce.WebApplication.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public readonly ICategoryService _categoryService;

        public MenuController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult List()//Menüyü oluşturan action.
        {

            var categoryList = _categoryService.GetAll().ToList();

            return View(categoryList);
        }
    }
}