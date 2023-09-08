using DOTNET_PROJECT.Models;
using System;
using DotNetOpenAuth.GoogleOAuth2;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DOTNET_PROJECT.Controllers
{
    [Authorize]
    [AllowAnonymous]
    public class HomeController : Controller
    {
      public DOTNETEntities entities = new DOTNETEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User user)
        {
            Validate_User_Result roleUser = entities.Validate_User(user.Username, user.password).FirstOrDefault();
            string message;
            switch (roleUser.userid.Value)
            {
                case -1:
                    message = "Email / Password is incorrect.";
                    break;
              
                default:
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.email, DateTime.Now, DateTime.Now.AddMinutes(30), false, roleUser.Roles, FormsAuthentication.FormsCookiePath);
                    string hash = FormsAuthentication.Encrypt(ticket)
;
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                    if (ticket.IsPersistent)
                    {
                        cookie.Expires = ticket.Expiration;
                    }
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index","Home");
            }
            ViewBag.Message = message;
            return View(user);
        }
      
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "userid,Username,Roleid,password,email,phone ")] User newUser)
        {
            if (ModelState.IsValid)
            {
                entities.Users.Add(newUser);
                entities.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }
      
       

       

        public ActionResult Index()
        {
        return View();
        }

        [Authorize(Roles="Admin")]
        public ActionResult UsersIndex()
        {
            List<User> users = new List<User>();
            return View(users);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? Id)
        {
            User users = entities.Users.Find(Id);
            List<Role> Role = entities.Roles.ToList();
            ViewBag.Roles = new SelectList(Role, "roleid", "RoleName");
            return View(users);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userid, Username,email,phone, Password, Roleid, modified_date ")] User employee)
        {
            if (ModelState.IsValid)
            {
                entities.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                return RedirectToAction("UsersIndex");

            }
            return View();
        }
    }
}