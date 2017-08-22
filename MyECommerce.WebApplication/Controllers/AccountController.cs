using MyEcommerce.Entities.ViewModel;
using MyEcommerce.Web.Infrastructure;
using MyECommerce.Business.Abstract;
using MyECommerce.Business.Concrete;
using MyECommerce.Core.Utilities;
using MyECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyECommerce.WebApplication.Controllers
{
    public class AccountController : BaseController
    {

            public readonly IUsersService _usersService;

            public AccountController(IUsersService usersService)
            {
                _usersService = usersService;
            }

            [HttpGet]
            public ActionResult SignUp()//Kayıt ol sayfasının get action'ı
            {
                var signUpUserViewModel = new SignUpUserViewModel();


                signUpUserViewModel.User = new Users();

                return View(signUpUserViewModel);
            }

            [HttpGet]
            public ActionResult SignOut()//Kullanıcı çıkış Action'ı
            {
                UserSession.User = null;
                UserSession = null;
                return RedirectToAction("Index", "Home");
            }

            [HttpPost]
            public ActionResult SignIn(string userName, string password)//Üye girişi Action'ı 
            {
                var generateHash = new GenerateHash();
                password = generateHash.Encrypt(password, ConfigurationManager.AppSettings["HashKey"].ToString());
                var user = _usersService.Get(e => e.Active == true &&
                                       e.EMailConfirmed == true &&
                                       e.Password == password &&
                                       e.EMailAdress == userName);

                if (user != null)//Eğer user classı boş ise servisten değer gelmemiş başarısız yönlendirmesi yapılır.
                {
                    UserSession.User = user;
                    return Json(new { Process = true, Message = "Giriş başarıyla yapılmıştır." });
                }
                else
                {
                    return Json(new { Process = false, Message = "Girdiğiniz bilgileri kontrol ediniz." });
                }

            }

            [HttpGet]
            public ActionResult SignIn()// Üye Girişi sayfası get Action'ı
            {
                var signUpUserViewModel = new SignUpUserViewModel();
              

                return View(signUpUserViewModel);
            }




            [HttpPost]
            public ActionResult SignUp(SignUpUserViewModel signUpViewModel)// Üye ol Post Action'ı
            {
                var generateHash = new GenerateHash();

                signUpViewModel.User.Password = generateHash.Encrypt(signUpViewModel.User.Password, ConfigurationManager.AppSettings["HashKey"].ToString());
                signUpViewModel.User.EMailConfirmed = false;
                signUpViewModel.User.CreatedTime = DateTime.Now;


                signUpViewModel.User.EMailConfirmed = true; 
                signUpViewModel.User.Active = true; 

                var user = _usersService.Add(signUpViewModel.User);//Kullanıcı servisinin add metodu ile yeni kullanıcı bilgileri set edilir.

                if (user.Id == 0)//Add metodu dönüşündeki user classında user bilgisi oluştu ise yeni Id bilgisi alır.Eğer almamışsa sayfaya geri dön.
                {
                    return View(signUpViewModel);
                }
                else
                {
                    UserSession.User = user;
                    return RedirectToAction("Index", "Home");
                }


            }
    }
}