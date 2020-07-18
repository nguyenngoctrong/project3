using Models.FrameWork;
using Models.Service;
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

        public dynamic AddToCart(int id_cart, int id_bou, int amount)
        {
            var cartDetail = db.CartDetails.Where(x => x.Id_Cart == id_cart && x.Id_Bou == id_bou).FirstOrDefault();
            var bou = db.Bouquests.Where(x => x.Id_Bou == id_bou).FirstOrDefault();
            var result = db.ProCartDetails_Create(id_cart, id_bou, amount, (bou.Price * amount)).FirstOrDefault();
            return result;
        }
    }
}
