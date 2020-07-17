using Models;
using Models.FrameWork;
using Models.Service;
using project3.Models;
using System.Web;
using System;
using System.Web.Mvc;
using System.Web.Security;



namespace project3.Controllers
{
    public class HomeController : Controller
    {
        private ProductModel product = new ProductModel();
        // GET: Home
        public ActionResult Index()
        {
            var a = Hashing.HashPassword("123456");

            Home home = new Home();
            home.bouquests = product.getProduct();
            return View(home);
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login( Customer model, string returnUrl ) {
            Customer dataItem = product.login(model);
            if(dataItem != null)
            {
                Session["idUser"] = dataItem.Id_Cus;
                var a = Session["idUser"];
                FormsAuthentication.SetAuthCookie(dataItem.Email, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")&& !returnUrl.StartsWith("//") && !returnUrl.StartsWith("\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid user or password");
                return View();
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            Session.Remove("idUser");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Home");
        }

        public ActionResult SignUp()
        {
            ViewBag.Role_id = product.getRoles();
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Register model)
        {
            ViewBag.Role_id = product.getRoles();
            if (ModelState.IsValid)
            {
                bool check = product.checkEmail(model.Email);
                if (!check)
                {
                    ModelState.AddModelError("", "Email aready exits !");
                    return View(model);
                }
                else
                {
                    Customer cus = new Customer();
                    cus.Email = model.Email;
                    cus.Password = Hashing.HashPassword(model.Password);
                    cus.Id_Role = model.Id_Role;
                    product.register(cus);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(model);
            }
        }
        [Authorize]

        public ActionResult GetCart()
        {
            var id = Session["idUser"];
            if(id != null)
            {
                object a = product.getInforCart(Convert.ToInt32(id));
                return Json(a, JsonRequestBehavior.AllowGet);

            }
            return Json(new { }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [Authorize]
        public ActionResult AddToCart(int id_bou,int amount)
        {
            var id = Session["idUser"];
            if(id != null)
            {
                JsonResult a = Json(product.AddToCart(Convert.ToInt32(id), id_bou, amount), JsonRequestBehavior.AllowGet);

                return a;
            }
            return Json(new { }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [Authorize]

        public ActionResult DeleteCart(int id)
        {
            product.deleteCart(id);
            return Json(new { }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult CheckLogin()
        {
            if (Session["idUser"] == null)
            {
                return Json(new { check = false }, JsonRequestBehavior.AllowGet);

            }
            return Json(new { check = true }, JsonRequestBehavior.AllowGet);

        }


    }


}