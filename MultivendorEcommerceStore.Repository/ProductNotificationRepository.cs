using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public class ProductNotificationRepository : IProductNotificationRepository
    {
        private MultivendorEcommerceStoreEntities _db;

        public List<ProductNotification> Get()
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.ProductNotifications.ToList();
        }


        public void ChangeIsSeenByID(Guid ProductID)
        {
            _db = new MultivendorEcommerceStoreEntities();
            var info = _db.ProductNotifications.Where(n => n.ProductID == ProductID).FirstOrDefault();
            info.IsSeen = true;
            _db.SaveChanges();
        }


        public List<ProductNotification> GetUnSeen()
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.ProductNotifications.Where(n => n.IsSeen == false).ToList();
        }


        public void Insert(ProductNotification entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            _db.ProductNotifications.Add(entity);
            _db.SaveChanges();
        }
    }
}
