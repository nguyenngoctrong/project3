using Models;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Controllers
{
    public class PurchaseController : Controller
    {
        private ProductModel product = new ProductModel();

        // GET: Purchase
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Detail()
        {
            if (TempData["shortMessage"] != null)
            {
                ViewBag.Update = TempData["shortMessage"].ToString();
            }
            var id = Session["idUser"];
            int totalPrice = 0;
            if(id  != null)
            {
                totalPrice=product.TotalPrice(Convert.ToInt32(id));
            }
            Customer cus = product.GetCustomerDetail(Convert.ToInt32(id));
            BillInfor billInfor = new BillInfor() { 
             Name = cus.LastName,
             Phone = cus.Phone,
             Cus_Note =  cus.Address,
             totalPrice= totalPrice
            };
            return View(billInfor);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail( BillInfor billInfor )
        {
            if (ModelState.IsValid)
            {
                var id = Session["idUser"];
                if (id != null)
                {
                    int i = product.Purchase(billInfor, Convert.ToInt32(id));
                    TempData["shortMessage"] = i;

                }

                return RedirectToAction("Detail", "Purchase");
            }
            else
            {
                return RedirectToAction("Detail", "Purchase");
            }
        }
    }
}