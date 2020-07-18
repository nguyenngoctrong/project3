using Models;
using Models.FrameWork;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Controllers
{
    public class ProductController : Controller
    {
        private ProductModel product = new ProductModel();

        // GET: Product
        public ActionResult Index( int? page, string status)
        {
            var s = status ?? "";
            var floris = product.getListProduct(s);
            var pageNumber = page ?? 1;
            var pageSize = 4;
            var products = floris.ToPagedList(pageNumber, pageSize);
            ViewBag.Status = s;
            return View(products);
        }

        public ActionResult getSearchData( string query)
        {
            List<Bouquest> florist = new List<Bouquest>();

            if (query.Length == 0)
            {
                florist = product.getFourBouquest();
                return Json(florist, JsonRequestBehavior.AllowGet);

            }
            else
            {
                florist = product.getSearch(query);
                return Json(florist, JsonRequestBehavior.AllowGet);
            }
            
        }
        public ActionResult Detail(int id)
        {
            Bouquest b = product.getBouquestDetail(id);
            return View(b);
        }
    }
}