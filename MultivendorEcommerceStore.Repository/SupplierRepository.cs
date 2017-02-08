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
            var suppliers = _db.Suppliers.ToList();
            return suppliers;
        }

        public void Update(Supplier entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var suppliers = GetById(id);
            _db.Suppliers.Remove(suppliers);
            _db.SaveChanges();
        }

        public Supplier GetById(Guid id)
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.Suppliers.Where(s => s.SupplierID == id).FirstOrDefault();
        }

        public Supplier GetByAspNetUserID(string id)
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.Suppliers.Where(s => s.AspNetUserID == id).FirstOrDefault();
        }
    }
}
