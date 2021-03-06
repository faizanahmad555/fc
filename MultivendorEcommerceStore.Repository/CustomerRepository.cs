﻿using System;
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

        public Customer GetById(Guid? Id)
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.Customers.Where(w => w.CustomerID == Id).FirstOrDefault();
        }

        public IEnumerable<Customer> Retrive()
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.Customers.ToList();
        }

        public void Update(Customer entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            var customer = _db.Customers.Where(s => s.AspNetUserID == entity.AspNetUserID && s.CustomerID == entity.CustomerID).FirstOrDefault();
            customer.FirstName = entity.FirstName;
            customer.LastName = entity.LastName;
            customer.Mobile = entity.Mobile;
            customer.Address = entity.Address;
            //customer.CountryID = entity.CountryID;
            //customer.StateID = entity.StateID;
            //customer.CityID = entity.CityID;
            _db.SaveChanges();
        }

    }
}
