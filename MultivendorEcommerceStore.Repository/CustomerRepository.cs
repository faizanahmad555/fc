using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private MultivendorEcommerceStoreEntities _db;

        public void Create(Customer entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            _db.Customers.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(string UserID)
        {
            throw new NotImplementedException();
        }

        public AspNetUser GetByAspNetUserID(string UserID)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Retrive()
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.Customers.ToList();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
