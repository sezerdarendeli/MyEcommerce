using MyEcommerce.Entities.ViewModel;
using MyEcommerce.Web.Infrastructure;
using MyECommerce.Business.Abstract;
using MyECommerce.Entities.ComlexTypes;
using MyECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyECommerce.WebApplication.Controllers
{
    public class ShoppingCartController : BaseController
    {
        public readonly IBasketService _basketService;
        public readonly IAddressService _addressService;
        public readonly IProductService _productService;
        public readonly IOrdersService _ordersService;

        public ShoppingCartController(IBasketService basketService, IProductService productService, IAddressService addressService, IOrdersService ordersService)
        {
            _basketService = basketService;
            _productService = productService;
            _addressService = addressService;
            _ordersService = ordersService;

        }

        #region Sepet 1. Adım işlemleri
        [HttpPost]
        public ActionResult AddToCart(int productId)
        {
            var basketItem = new Basket();
            if (UserSession.BasketId != 0)// Mevcutbir sepet var ise sepet listesini oluştur.
            {
                basketItem = _basketService.GetAll(e => e.BasketId == UserSession.BasketId && e.ProductId == productId).FirstOrDefault();

            }
            if (basketItem != null)//Sepet listesi değeri var ise ilgili satırın Quantity değerini tabloda 1 artır.
            {
                if (basketItem.ProductId != 0)
                {
                    basketItem.Quantity = basketItem.Quantity + 1;
                    _basketService.Update(basketItem);
                }
                else
                {
                    var basket = _basketService.Add(new Basket
                    {
                        ProductId = productId,
                        CreatedTime = DateTime.Now,
                        Quantity = 1
                    });
                    basket.BasketId = basket.Id;
                    _basketService.Update(basket);
                    UserSession.BasketId = basket.Id;
                }

            }//İlk defa ilgili ürün ekleniyorsa sepete ekleme işlemi yapılıyor.
            else
            {
                if (UserSession.BasketId == 0)
                {
                    var basket = _basketService.Add(new Basket
                    {
                        ProductId = productId,
                        CreatedTime = DateTime.Now,
                        Quantity = 1,
                    });
                    basket.BasketId = basket.Id;
                    _basketService.Update(basket);
                    UserSession.BasketId = basket.Id;
                }
                else
                {
                    var basket = _basketService.Add(new Basket
                    {
                        ProductId = productId,
                        CreatedTime = DateTime.Now,
                        Quantity = 1,
                        BasketId = UserSession.BasketId
                    });
                }


            }
            var count = _basketService.GetAll(e => e.BasketId == UserSession.BasketId).ToList().Count();

            return Json(new { Process = "Ok", Message = "Ürün sepete eklenmiştir" ,Quantiy= count });
        }

        [HttpPost]
        public ActionResult BasketItemProcess(int productId, string itemType, int itemQuantity)
        {
            var shoppingcartViewModel = new ShoppingCartViewModel();
            var shoppingCartItemList = new List<ShoppingCartItemModel>();

            var basket = _basketService.GetAll(e => e.BasketId == UserSession.BasketId && e.ProductId == e.ProductId).FirstOrDefault();
            if (itemType == "UPDATE")
            {
                basket.Quantity = itemQuantity;
                _basketService.Update(basket);
            }
            else if (itemType == "DELETE")
            {
                _basketService.Delete(basket);
            }

            var basketItemList = _basketService.GetAll(e => e.BasketId == UserSession.BasketId);

            double subTotal = 0;
            foreach (var basketItem in basketItemList)
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
            shoppingcartViewModel.IsSuccess = true;
            shoppingcartViewModel.ShoppingCartList = shoppingCartItemList;
            shoppingcartViewModel.SubTotal = subTotal;


            return Json(new { Process = true, Message = "İşlem gerçekleştirilmiştir." });
        }

        [HttpGet]
        public ActionResult Index()
        {
            var shoppingcartViewModel = new ShoppingCartViewModel();

          
            if (UserSession == null)
            {
                shoppingcartViewModel.IsSuccess = false;
                shoppingcartViewModel.Message = "Sepetinizde ürün bulunmamaktadır.";
                return View(shoppingcartViewModel);
            }
            else
            {
                if (UserSession.BasketId == 0)
                {

                    shoppingcartViewModel.IsSuccess = false;
                    shoppingcartViewModel.Message = "Sepetinizde ürün bulunmamaktadır.";
                    return View(shoppingcartViewModel);
                }
            }

            var basketItemList = _basketService.GetAll(e => e.BasketId == UserSession.BasketId);
            var shoppingCartItemList = new List<ShoppingCartItemModel>();
            double subTotal = 0;
            foreach (var basketItem in basketItemList)
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

            shoppingcartViewModel.Address = _addressService.GetAddressById(1).AddressText;
            shoppingcartViewModel.IsSuccess = true;
            shoppingcartViewModel.ShoppingCartList = shoppingCartItemList;
            shoppingcartViewModel.SubTotal = subTotal;
            return View(shoppingcartViewModel);
        }

        #endregion


        #region Sipariş Onay
     
      



        [HttpPost]
        public ActionResult PostOrderSummary()
        {
            _ordersService.Add(new Orders
            {
                BasketId = UserSession.BasketId,
                UserId = UserSession.User.Id,
                CreatedDate = DateTime.Now,
                AddressId = UserSession.SelectedAddresId
            });

            var basketList = _basketService.GetAll(e => e.BasketId == UserSession.BasketId);
            foreach (var item in basketList)
            {
                var basket = new Basket();
                basket = item;
                basket.Active = true;
                _basketService.Update(basket);
            }
            UserSession.BasketId = 0;
            UserSession.SelectedAddresId = 0;

            return Json(new { Process = true, Message = "Sipariş alınmıştır." });
        }

        #endregion
    }
}