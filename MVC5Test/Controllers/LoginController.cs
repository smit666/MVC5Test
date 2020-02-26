using MVC5Test.Models;
using MVC5Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Test.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            IAuthenticationContainerModel model = JWTContainerModel.GetJWTContainerModel("smit","smit@smit.com");
            IAuthService authService = new JWTService(model.SecretKey);

            string token = authService.GenerateToken(model);

            return View();
        }

        [TokenHandler]
        public ActionResult Test()
        {
            return Content("Success!");
        }
    }
}