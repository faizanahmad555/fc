using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public class SubCategoryItemRepository : ISubCategoryItemRepository
    {
        private MultivendorEcommerceStoreEntities _db;

        public void Create(SubCategoryItem Entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            _db.SubCategoryItems.Add(Entity);
            _db.SaveChanges();
        }

        public SubCategoryItem GetByID(Guid id)
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.SubCategoryItems.Where(c => c.SubCategoryItemID == id).FirstOrDefault();
        }

        public IEnumerable<SubCategoryItem> Retrive()
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.SubCategoryItems.ToList();
        }



    }
}
