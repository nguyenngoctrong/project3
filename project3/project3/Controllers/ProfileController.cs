using Models;
using Models.FrameWork;
using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Controllers
{
    public class ProfileController : Controller
    {
        private ProductModel product = new ProductModel();

        // GET: Profile
        [Authorize]
        public ActionResult Index()
        {
            if(TempData["shortMessage"] != null)
            {
                ViewBag.Update = TempData["shortMessage"].ToString();
            }
            if(TempData["ChangePassword"] != null)
            {
                ViewBag.ChangePassword = TempData["ChangePassword"].ToString();


            }
            if (TempData["CurrentPassword"] != null)
            {
                ViewBag.ErrorMessage = TempData["CurrentPassword"].ToString();

            }
            else
            {
                ViewBag.ErrorMessage = "";

            }

            var id = Session["idUser"];
            CustomerInfor data = product.GetCustomers((int)id);
            Profile profile = new Profile();
            profile.customerInfor = data;
            return View(profile);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index( Profile profile)
        {
            var id = Session["idUser"];
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    int result = product.UpdateCustomer(Convert.ToInt32(id), profile.customerInfor);
                    TempData["shortMessage"] = result;
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }


            return RedirectToAction("Index");
            ;
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(Profile profile)
        {
            var id = Session["idUser"];
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    var a = product.ChangePassword(Convert.ToInt32(id), profile.password.CurrentPassword, profile.password.NewPassword);
                    if(a != null)
                    {
                        TempData["ChangePassword"] = a;
                        TempData["CurrentPassword"] = "";
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        TempData["CurrentPassword"] = "Current password is incorrect";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }


            return RedirectToAction("Index");
            ;
        }

    }
}