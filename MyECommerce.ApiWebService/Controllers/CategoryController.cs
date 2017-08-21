using MyECommerce.Business.Abstract;
using MyECommerce.Entities.EfModels;
using System.Collections.Generic;
using System.Web.Http;

namespace MyECommerce.ApiWebService.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        //Category Listesini getiren Controller
        [HttpGet]
        public IHttpActionResult GetCategoryList ()
        {
            //var listCategory=_categoryManager.GetAll();


            return Ok("aa");

        }
    }
}
