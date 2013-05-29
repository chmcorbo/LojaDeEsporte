using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LojaDeEsporte.Presentation.WebApp.Models;

namespace LojaDeEsporte.Presentation.WebApp.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                //if (loginViewModel.UserName == "Admin" && loginViewModel.Password == "password")
                if (FormsAuthentication.Authenticate(loginViewModel.UserName, loginViewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(loginViewModel.UserName, false);
                    return Redirect(returnUrl ?? Url.Action("Index", "Categoria"));
                }
                ModelState.AddModelError("", "Login Invalido");
            }

            return View();
        }
    }
}