using MyEcommerce.Entities.ViewModel;
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
    public class OrderController : Controller
    {
        private readonly IOrdersService _orderService;
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public OrderController(IOrdersService orderService , IBasketService basketService,IProductService productService)
        {
            _orderService = orderService;
            _basketService = basketService;
            _productService = productService;

        }

        public ActionResult List()
        {
            return View(_orderService.GetAll().OrderBy(o => o.Id));
        }

        //Kullanıcı detay sayfası için UserDetailViewModel'e servisten data çekip modeli dönen servis
        public ActionResult Detail(int id)
        {
            ShoppingCartViewModel model = new ShoppingCartViewModel();

            var shoppingCartItemList = new List<ShoppingCartItemModel>();
            var orders = _orderService.GetOrdersById(id);//Sipariş class'ını oluştur.

            var basketItemList = _basketService.GetAll(e => e.BasketId == orders.BasketId);
            double subTotal = 0;
            foreach (var basketItem in basketItemList) // Basket içerisindeki ürünlerin bilgileri alınır.
            {

                var product = _productService.GetProductById(basketItem.ProductId);

                shoppingCartItemList.Add(
                                new ShoppingCartItemModel
                                {
                                    ProductId = product.Id,
                                    Price = product.Price,
                                    ProductName = product.Name,
                                    ProductImageUrl = product.ImageUrl,
                                    Quantity = basketItem.Quantity,
                                    ItemTotalPrice = basketItem.Quantity * product.Price
                                });
                subTotal = subTotal + (product.Price * basketItem.Quantity);
            }

            model.ShoppingCartList = shoppingCartItemList;
            model.SubTotal = subTotal;

            return View(model);
        }

    }
}