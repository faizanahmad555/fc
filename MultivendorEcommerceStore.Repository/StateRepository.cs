using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public class StateRepository : IStateRepository
    {
        private MultivendorEcommerceStoreEntities _db;
        public IEnumerable<State> Get()
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.States.ToList();
        }
    }
}
