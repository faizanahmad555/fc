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
            var customers = GetByAspNetUserID(UserID);
            _db.AspNetUsers.Remove(customers);
            _db.SaveChanges();
        }


        public Guid InsertAndGetID(Customer entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            _db.Customers.Add(entity);
            _db.SaveChanges();
            return entity.CustomerID;
        }



        public AspNetUser GetByAspNetUserID(string UserID)
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.AspNetUsers.Where(s => s.Id == UserID).FirstOrDefault();
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
