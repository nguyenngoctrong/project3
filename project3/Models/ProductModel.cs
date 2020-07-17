using Models.FrameWork;
using Models.Service;
using project3.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Mvc;


namespace Models
{
    public class ProductModel
    {
        private JavaFloristEntities db = new JavaFloristEntities();


        public ProductModel()
        {
            db.Configuration.ProxyCreationEnabled = false;

        }
        public List<Bouquest> getProduct()
        {
          var b = db.Bouquests.Take(4);

            return b.ToList();
        }
        public List<Bouquest> getListProduct(string status)
        {
            if( status != "")
            {
                var b= db.Bouquests.Where( x => x.Status == status);
                return b.ToList();
            }
            else
            {
                var b = db.Bouquests;
                return b.ToList();

            }

        }
        public List<Bouquest> getSearch( string query )
        {
            var b = db.Bouquests.Where(x => x.Name.Contains(query));
            return b.ToList();
        }
        public List<Bouquest> getFourBouquest()
        {
            var b = db.Bouquests.Take(4);
            return b.ToList();
        }
        public Bouquest getBouquestDetail(int id)
        {
            Bouquest b = db.Bouquests.Find(id);
            return b;
        }
        public Customer login( Customer customer)
        {

            var b = db.Customers.Where(x => x.Email == customer.Email).FirstOrDefault();
            if(b != null)
            {

                bool check =Hashing.ValidatePassword(customer.Password,b.Password);
                if (check)
                {
                    Customer customerReturn = new Customer();
                    customerReturn.Id_Cus = b.Id_Cus;
                    customerReturn.Id_Role = b.Id_Role;
                    customerReturn.FirstName = b.FirstName;
                    customerReturn.LastName = b.LastName;
                    customerReturn.Email = b.Email;
                    return customerReturn;
                }

            }
            
            return null;
        }
        public string[] getRole( string email)
        {
          
            string data = db.Customers.Join(db.Roles,
                customer => customer.Id_Role,
                roles => roles.Id_Role,
                (customer,role) => new {cus = customer, rol = role}

                ).Where( x => x.cus.Email == email).FirstOrDefault().rol.Role_Define;
            string[] result = { data };
            return result;
        }
        public List<SelectListItem> getRoles()
        {
            var data = db.Roles.Where(x => x.Role_Define != "admin").ToList();
            List<SelectListItem> selectLists = new List<SelectListItem>();

            foreach( var item in data)
            {
                selectLists.Add(new SelectListItem { Text = item.Role_Define, Value = item.Id_Role.ToString() });
            }
            

            return selectLists;
        }
        public bool checkEmail(string email)
        {
            var  result = db.ProCheck_U(email).ToList();
            if(result.Count == 0)
            {
                return true;
            }
            return false;
        }
        public dynamic register (Customer cus)
        {

         var result =   db.ProCus_Create(cus.Email, cus.Password, cus.FirstName, cus.LastName, cus.Image,
                                          cus.Birth, cus.Id_Gender, cus.Phone, cus.Address, cus.Id_Role).ToList();
            db.ProCart_CreateGetId((int)result[0]);
            return result;
        }

        public object AddToCart(int idCus, int id_bou, int amount)
        {
            var id_cart = db.Carts.Where(x => x.Id_Cus == idCus).FirstOrDefault().Id_Cart;
            var cartDetail = db.CartDetails.Where(x => x.Id_Cart == id_cart && x.Id_Bou == id_bou).FirstOrDefault();
            var bou = db.Bouquests.Where(x => x.Id_Bou == id_bou).FirstOrDefault();
            if (cartDetail != null)
            {
                var resultUpdate = db.ProCartDetails_Update(cartDetail.Id, (amount + cartDetail.Volume), ((amount + cartDetail.Volume) * bou.Price)).FirstOrDefault();
                return new
                {
                    Name =bou.Name,
                    Decription=bou.Description,
                    Img=bou.Image,
                    Price=bou.Price,
                    Id_Bou=bou.Id_Bou,
                    Id_Cus=bou.Id_Cus,
                    Id_Status=bou.Status,
                    cartDetail = resultUpdate,

                };
                
            }
            var resultInsert = db.ProCartDetails_Create(id_cart, id_bou, amount, (bou.Price * amount)).FirstOrDefault();


            return new
            {
                Name = bou.Name,
                Decription = bou.Description,
                Img = bou.Image,
                Price = bou.Price,
                Id_Bou = bou.Id_Bou,
                Id_Cus = bou.Id_Cus,
                Id_Status = bou.Status,
                cartDetail = resultInsert,

            };


        }
        public object getInforCart(int? idCus)
        {
            if (idCus != null)
            {
                var idCart = db.Carts.Where(x => x.Id_Cus == idCus).FirstOrDefault().Id_Cart;

                var result = db.CartDetails.Where(x => x.Id_Cart == idCart).Join(db.Bouquests,
                    cartDetail => cartDetail.Id_Bou,
                    bouquest => bouquest.Id_Bou,
                    (cartDetail, bouquest) => new {id=cartDetail.Id, id_cart = cartDetail.Id_Cart, Name = bouquest.Name, Img = bouquest.Image, Price = bouquest.Price, TotalPrice = cartDetail.Total_Price, amount = cartDetail.Volume }
                    ).ToList();
                return result;
            }

            
            return null;
        }

        public object deleteCart(int id)
        {
            db.ProCartDetails_Delete(id);
            return new { };
        }
        public CustomerInfor GetCustomers( int id)
        {
            var result = db.Customers.Where(x => x.Id_Cus == id).Join(db.Roles,customer=>customer.Id_Role,role=>role.Id_Role, 
                (customer,role) => new CustomerInfor
                {
                    Email=customer.Email,
                    FirstName=customer.FirstName,
                    LastName=customer.LastName,
                    Phone=customer.Phone,
                    Address=customer.Address,
                    Birth=customer.Birth,
                    Role=role.Role_Define
                }
                
                ).FirstOrDefault();
            return result;
        }
        public int UpdateCustomer ( int id, CustomerInfor cus)
        {
            int result = db.ProCus_Update(id, cus.FirstName, cus.LastName, null, cus.Birth, cus.Phone, cus.Address);
            return result;
        }
        public dynamic ChangePassword(int id,string password ,string newPassword)
        {
            var ps = db.Customers.Where(x => x.Id_Cus == id).FirstOrDefault();

            bool check = Hashing.ValidatePassword(password, ps.Password);
            if (check)
            {
                int result = db.ProCus_ChangePassword(id, Hashing.HashPassword(newPassword));
                return result;
            }
            return null;

        }
    }
}
