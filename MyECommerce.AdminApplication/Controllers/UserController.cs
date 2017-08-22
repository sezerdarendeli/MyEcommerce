using MyECommerce.Business.Abstract;
using MyECommerce.Entities.Concrete;
using MyECommerce.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyECommerce.AdminApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersService _userService;
        private readonly IOrdersService _orderService;


        public UserController(IUsersService userService, IOrdersService orderService)
        {
            _userService = userService;
            _orderService = orderService;

        }

        public ActionResult List()//Kullanıcı listesini getiren  Action
        {
            return View(_userService.GetAll().OrderBy(o => o.Id));
        }

        //Kullanıcı detay sayfası için UserDetailViewModel'e servisten data çekip modeli dönen Action
        public ActionResult Detail(int id)
        {
            UserDetailViewModel model = new UserDetailViewModel();
            model.User = _userService.Get(e => e.Id == id);
            model.OrderList = _orderService.GetAll(e => e.UserId == id);

            return View(model);
        }

    }
}