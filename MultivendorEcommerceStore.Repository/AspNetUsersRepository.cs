using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public class AspNetUsersRepository : IAspNetUsersRepository
    {
        private MultivendorEcommerceStoreEntities _db;
        public IEnumerable<AspNetUser> Retrive()
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.AspNetUsers.ToList();
        }
    }
}
