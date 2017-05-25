using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public class WishListRepository : IWishListRepository
    {
        private MultivendorEcommerceStoreEntities _db;
        public void Create(WishList entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            _db.WishLists.Add(entity);
            _db.SaveChanges();
        }

        public IEnumerable<WishList> Retrive()
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.WishLists.ToList();
        }

        public void Delete(Guid id)
        {
            var wishlist = GetById(id);
            _db.WishLists.Remove(wishlist);
            _db.SaveChanges();
        }

        public WishList GetById(Guid id)
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.WishLists.Where(s => s.WishListID == id).FirstOrDefault();
        }

    }
}
