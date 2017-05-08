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
            var supplierProduct = _db.Products.Where(s => s.SupplierID == entity.SupplierID && s.ProductID == entity.ProductID).FirstOrDefault();
            supplierProduct.ProductName = entity.ProductName;
            supplierProduct.ProductDescription = entity.ProductDescription;
            supplierProduct.Quantity = entity.Quantity;
            supplierProduct.UnitPrice = entity.UnitPrice;
            supplierProduct.ProductPicture = entity.ProductPicture;
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

        public int? ChangeActiveStatus(Product entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            var product = _db.Products.Where(s => s.ProductID == entity.ProductID).FirstOrDefault();
            product.IsActive = entity.IsActive;
            _db.SaveChanges();
            return entity.IsActive;
        }


        public Guid InsertAndGetID(Product entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            _db.Products.Add(entity);
            _db.SaveChanges();
            return entity.ProductID;
        }

    }
}
