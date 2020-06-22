using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductModel
    {
        private FloristDbContext db = null;

        public ProductModel()
        {
            db = new FloristDbContext();
        }
        public List<Bouquest> getProduct()
        {
          var b = db.Bouquests.Take(4);

            return b.ToList();
        }
    }
}
