using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;
using System.Data.Entity;

namespace MultivendorEcommerceStore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private MultivendorEcommerceStoreEntities _db;

        public void Create(Product entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            _db.Products.Add(entity);
            _db.SaveChanges();
        }

        public IEnumerable<Product> Retrive()
        {
            _db = new MultivendorEcommerceStoreEntities();
            var product = _db.Products.ToList();
            return product;
        }

        public void Update(Product entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        
        public void Delete(Guid id)
        {
            var product = GetById(id);
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        public Product GetById(Guid id)
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.Products.Where(s => s.ProductID == id).FirstOrDefault();
        }


    }
}
