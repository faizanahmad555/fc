using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;
using System.Data.Entity;

namespace MultivendorEcommerceStore.Repository
{
    public class CustomerNotificationRepository : ICustomerNotificationRepository
    {
        private MultivendorEcommerceStoreEntities _db;

        public List<CustomerNotification> Get()
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.CustomerNotifications.ToList();
        }

        public List<CustomerNotification> GetUnSeen()
        {
            _db = new MultivendorEcommerceStoreEntities();
            var list =  _db.CustomerNotifications.Where(s=>s.IsSeen == false).ToList();
            return list;
        }

        public void ChangeIsSeenByID(Guid customerID)
        {
            _db = new MultivendorEcommerceStoreEntities();
            var info = _db.CustomerNotifications.Where(s => s.CustomerID == customerID).FirstOrDefault();
            info.IsSeen = true;
            _db.SaveChanges();
        }

        public void Insert(CustomerNotification entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            _db.CustomerNotifications.Add(entity);
            _db.SaveChanges();
        }

    }
}
