using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Admination;
using Admination.Models;

namespace project3.Models
{
    public class AdminController : Controller
    {
        private JavaFloristEntities db = new JavaFloristEntities();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageCustomer()
        {           
            var cu = db.ProCus_ReadMulti();

            List<AdminCustomer> customer = new List<AdminCustomer>();
            foreach (var item in cu)
            {                
                customer.Add(new AdminCustomer() 
                {
                    Id_Cus = int.Parse(item.Id_Cus.ToString()),
                    Image = item.Image,
                    Email = item.Email,
                    FullName = item.FirstName + " " + item.LastName,
                    Birth = item.Birth,
                    Gender = item.Gender_Define, Phone = item.Phone,
                    Address = item.Address 
                });
            }

            return View(customer);
        }

        // GET: Admin/Details/5
        public ActionResult DetailsCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = db.Customer.Find(id);



            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        // GET: Admin/Create
        public ActionResult CreateCustomer()
        {
            ViewBag.Id_Gender = new SelectList(db.Gender, "Id_Gender", "Gender_Define");
            ViewBag.Id_Role = new SelectList(db.Role, "Id_Role", "Role_Define");
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer([Bind(Include = "Id_Cus,Email,Password,FirstName,LastName,Image,Birth,Id_Gender,Phone,Address,Id_Role")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("ManageCustomer");
            }

            ViewBag.Id_Gender = new SelectList(db.Gender, "Id_Gender", "Gender_Define", customer.Id_Gender);
            ViewBag.Id_Role = new SelectList(db.Role, "Id_Role", "Role_Define", customer.Id_Role);
            return View(customer);
        }

        // GET: Admin/Edit/5
        public ActionResult EditCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Gender = new SelectList(db.Gender, "Id_Gender", "Gender_Define", customer.Id_Gender);
            ViewBag.Id_Role = new SelectList(db.Role, "Id_Role", "Role_Define", customer.Id_Role);
            return View(customer);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "Id_Cus,Email,Password,FirstName,LastName,Image,Birth,Id_Gender,Phone,Address,Id_Role")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageCustomer");
            }
            ViewBag.Id_Gender = new SelectList(db.Gender, "Id_Gender", "Gender_Define", customer.Id_Gender);
            ViewBag.Id_Role = new SelectList(db.Role, "Id_Role", "Role_Define", customer.Id_Role);
            return View(customer);
        }

        // GET: Admin/Delete/5
        public ActionResult DeleteCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("DeleteCustomer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int del = db.ProCus_Delete(id);
            //Customer customer = db.Customer.Find(id);
            //db.Customer.Remove(customer);
            //db.SaveChanges();
            return RedirectToAction("ManageCustomer");
        }


        // ----------------------------------SELLER------------------------------------- //

        public ActionResult SellerManagement()
        {
            var cu = db.Pro_ReadShop();

            List<AdminCustomer> customer = new List<AdminCustomer>();
            foreach (var item in cu)
            {
                customer.Add(new AdminCustomer()
                {
                    Id_Cus = int.Parse(item.Id_Cus.ToString()),
                    Image = item.Image,
                    Email = item.Email,
                    FullName = item.FirstName + " " + item.LastName,
                    Birth = item.Birth,
                    Gender = item.Gender_Define,
                    Phone = item.Phone,
                    Address = item.Address
                });
            }

            return View(customer);
        }

        public ActionResult SellerDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult SellerCreate()
        {
            ViewBag.Id_Gender = new SelectList(db.Gender, "Id_Gender", "Gender_Define");
            ViewBag.Id_Role = new SelectList(db.Role, "Id_Role", "Role_Define");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SellerCreate([Bind(Include = "Id_Cus,Email,Password,FirstName,LastName,Image,Birth,Id_Gender,Phone,Address,Id_Role")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("SellerManagement");
            }

            ViewBag.Id_Gender = new SelectList(db.Gender, "Id_Gender", "Gender_Define", customer.Id_Gender);
            ViewBag.Id_Role = new SelectList(db.Role, "Id_Role", "Role_Define", customer.Id_Role);
            return View(customer);
        }

        public ActionResult SellerEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Gender = new SelectList(db.Gender, "Id_Gender", "Gender_Define", customer.Id_Gender);
            ViewBag.Id_Role = new SelectList(db.Role, "Id_Role", "Role_Define", customer.Id_Role);
            return View(customer);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SellerEdit([Bind(Include = "Id_Cus,Email,Password,FirstName,LastName,Image,Birth,Id_Gender,Phone,Address,Id_Role")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SellerManagement");
            }
            ViewBag.Id_Gender = new SelectList(db.Gender, "Id_Gender", "Gender_Define", customer.Id_Gender);
            ViewBag.Id_Role = new SelectList(db.Role, "Id_Role", "Role_Define", customer.Id_Role);
            return View(customer);
        }

        public ActionResult SellerDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("SellerDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult SellerDelete(int id)
        {
            int del = db.ProCus_Delete(id);
            //Customer customer = db.Customer.Find(id);
            //db.Customer.Remove(customer);
            //db.SaveChanges();
            return RedirectToAction("SellerManagement");
        }


        // ------------------------------BILL-----------------------------

        public ActionResult Bill()
        {
            var bill = db.ProBill_ReadAll();

            List<BillModel> lb = new List<BillModel>();

            foreach (var item in bill)
            {
                lb.Add (new BillModel 
                {
                    Id_Bill = item.Id_Bill,
                    Id_Cus = item.Id_Cus,
                    Name = item.Name,
                    Price = item.Price,
                    Volume = item.Volume,
                    Delivery_Date = item.Delivery_Date,
                    Bill_Status = item.Bill_Status
                });
            }

            return View(lb);
        }

        public ActionResult BillDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bill.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        public ActionResult BillEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bill.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BillEdit([Bind(Include = "Id_Bill,Id_Bou,Name,Image,Description,Price,Id_Cus,Volume,Order_Date,Delivery_Date,Cus_Note,Bill_Status")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.ProBill_UpStt_Other(bill.Id_Bill, bill.Bill_Status);
                
                //db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Bill");
            }
            
            return View(bill);
        }

        //--------------------------BOUQUETS----------------------  

        public ActionResult Bouquets() 
        {
            var b = db.ProBouReadAll();
            List<BouquetModel> bou = new List<BouquetModel>();

            foreach (var item in b) 
            {              
                bou.Add(new BouquetModel
                {
                    Id = item.Id_Bou,
                    Image = item.Image,
                    Name = item.Name,
                    Price = item.Price,
                    Status = item.Status        
                });
            }

            return View(bou);
        }

        // GET: Bouquests/Details/5
        public ActionResult BouquetDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquest bouquest = db.Bouquest.Find(id);
            if (bouquest == null)
            {
                return HttpNotFound();
            }
            return View(bouquest);
        }       

        // GET: Bouquests/Edit/5
        public ActionResult BouquetEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquest bouquest = db.Bouquest.Find(id);
            if (bouquest == null)
            {
                return HttpNotFound();
            }
            
            return View(bouquest);
        }

        // POST: Bouquests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BouquetEdit([Bind(Include = "Id_Bou,Name,Image,Description,Price,Status,Id_Cus")] Bouquest bouquet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bouquet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Bouquets");
            }
            
            return View(bouquet);
        }

        // GET: Bouquests/Delete/5
        public ActionResult BouquetDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquest bouquest = db.Bouquest.Find(id);
            if (bouquest == null)
            {
                return HttpNotFound();
            }
            return View(bouquest);
        }

        // POST: Bouquests/Delete/5
        [HttpPost, ActionName("BouquetDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult BouquetDeleteConfirmed(int id)
        {
            Bouquest bouquest = db.Bouquest.Find(id);
            db.Bouquest.Remove(bouquest);
            db.SaveChanges();
            return RedirectToAction("Bouquets");
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
