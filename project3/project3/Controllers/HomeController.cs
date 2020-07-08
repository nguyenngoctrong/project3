using Models;
using Models.FrameWork;
using Models.Service;
using project3.Models;
using System.Web.Mvc;
using System.Web.Security;



namespace project3.Controllers
{
    public class HomeController : Controller
    {
        private ProductModel product = new ProductModel();
        private JavaFloristEntities db = new JavaFloristEntities();
        // GET: Home
        public ActionResult Index()
        {
            product.AddToCart(2, 1028, 1);
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
                FormsAuthentication.SetAuthCookie(dataItem.Email, false);
                if(Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")&& !returnUrl.StartsWith("//") && !returnUrl.StartsWith("\\"))
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



    }


}