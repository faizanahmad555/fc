using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MultivendorEcommerceStore.DB;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public MultivendorEcommerceStoreEntities _db;
        public CategoryRepository()
        {
            _db = new MultivendorEcommerceStoreEntities();
        }

        public void Create(Category Entity)
        {
            _db.Categories.Add(Entity);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var category = GetById(id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
        }

        public Category GetById(Guid id)
        {
            var category = _db.Categories.Where(c => c.CategoryID == id).FirstOrDefault();
            return category;
        }

        public IEnumerable<Category> Retrive()
        {
            var category = _db.Categories.ToList();
            return category;
        }

  
        public void Update(Category Entity)
        {
            _db.Entry(Entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

     
    }
}
