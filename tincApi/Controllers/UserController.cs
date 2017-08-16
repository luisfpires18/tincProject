using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using tincApi.DAL;
using tincApi.Models;

namespace tincApi.Controllers
{
    public class UserController : Controller
    {
        private TincContext db = new TincContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Crypto.HashPassword(user.Password);
                user.ConfirmPassword = user.Password;
                db.User.Add(user);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = user.Nome + " " + user.Apelido + " registado com sucesso.";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(HttpRequestMessage request, User user)
        {
            var utilizador = db.User.Single(u => u.Username == user.Username && u.Password == user.Password);
            if (utilizador != null)
            {
                Session["UserID"] = utilizador.ID.ToString();
                Session["Username"] = utilizador.Username;
                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wrong.");
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                var user = User.Identity.Name;
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


    }
}