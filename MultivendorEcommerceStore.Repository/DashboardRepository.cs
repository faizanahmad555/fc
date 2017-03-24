using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private MultivendorEcommerceStoreEntities _db;

        public IEnumerable<Product> Get()
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.Products.ToList();
        }

        public IEnumerable<AspNetUser> Retrive()
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.AspNetUsers.ToList();   
        }
    }
}
