using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public class CityRepository : ICityRepository
    {
        private MultivendorEcommerceStoreEntities _db;
        public IEnumerable<CityMaster> Get()
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.CityMasters.ToList();
        }
    }
}
