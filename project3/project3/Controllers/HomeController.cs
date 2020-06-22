using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Controllers
{
    public class HomeController : Controller
    {
        private ProductModel product = new ProductModel();
        // GET: Home
        public ActionResult Index()
        {
            var floris = product.getProduct();
            return View(floris);
        }
    }
}