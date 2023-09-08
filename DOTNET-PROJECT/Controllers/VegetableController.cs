using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DOTNET_PROJECT.Controllers
{
    [Authorize]
    public class VegetableController : Controller
    {
        // GET: Vegetable

      
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Users")]
        public ActionResult Index()
        {
            return Content("Successfully signed in :)");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}