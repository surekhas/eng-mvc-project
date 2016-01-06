using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security; // form authentication 
using Eng_Part.Models.Entity;
using Eng_Part.Models.ViewModels;

namespace Eng_Part.Controllers
{
    public class AccountController : Controller
    {
        
        // //GET: /Account/
        //public ActionResult Index()
        //{
        //    return View();
        //}


        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserSignUpView USV)
        {
            if (ModelState.IsValid)
            {
               UserManager UM = new UserManager();
                if (!UM.IsLoginNameExist(USV.LoginName))
                {
                    UM.AddUserAccount(USV);
                    FormsAuthentication.SetAuthCookie(USV.FirstName, false);
                    return RedirectToAction("ListPart", "Home");

                }
                else
                    ModelState.AddModelError("", "Login Name already taken.");
            }
            return View();
        }

        public ActionResult LogIn() {

            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserLoginView ULV, string returnUrl)
        {
            if (ModelState.IsValid)
            {
             UserManager UM = new UserManager();
                string password = UM.GetUserPassword(ULV.LoginName);

                if (string.IsNullOrEmpty(password))
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                else
                {
                    if (ULV.Password.Equals(password))
                    {
                        FormsAuthentication.SetAuthCookie(ULV.LoginName, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The password provided is incorrect.");
                    }
                }
            }

            // If we got this far, something failed, redisplay form  
            return View(ULV);
        }


        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        } 
    
    
    }


}