using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private MultivendorEcommerceStoreEntities _db;
        public IEnumerable<Country> Get()
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.Countries.ToList();
        }
    }
}
