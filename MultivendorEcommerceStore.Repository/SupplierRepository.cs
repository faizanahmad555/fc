using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private MultivendorEcommerceStoreEntities _db;

        public void Create(Supplier entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            _db.Suppliers.Add(entity);
            _db.SaveChanges();
        }


        public IEnumerable<Supplier> Retrive()
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.Suppliers.ToList();
           
        }


        public void Update(Supplier entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            var supplierProfile = _db.Suppliers.Where(s => s.AspNetUserID == entity.AspNetUserID).FirstOrDefault();
            supplierProfile.SupplierFirstName = entity.SupplierFirstName;
            supplierProfile.SupplierLastName = entity.SupplierLastName;
            supplierProfile.Gender = entity.Gender;
            supplierProfile.Address = entity.Address;
            supplierProfile.Phone = entity.Phone;
            supplierProfile.ProfilePhoto = entity.ProfilePhoto;
            supplierProfile.PostalCode = entity.PostalCode;
            supplierProfile.CNIC = entity.CNIC;
            supplierProfile.CountryID = entity.CountryID;
            supplierProfile.StateID = entity.StateID;
            supplierProfile.CityID = entity.CityID;
            _db.SaveChanges();
        }


        public void DeleteSuppliers(string UserID)
        {
            var suppliers = GetByAspNetUserID(UserID);
            _db.AspNetUsers.Remove(suppliers);
            _db.SaveChanges();
        }


        public AspNetUser GetByAspNetUserID(string UserID)
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.AspNetUsers.Where(s => s.Id == UserID).FirstOrDefault();
        }


        public Supplier GetById(Guid? id)
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.Suppliers.Where(s => s.SupplierID == id).FirstOrDefault();
        }


      
    }
}
