using MultivendorEcommerceStore.DB.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.Repository
{
    public class SupplierBusinessInfo : ISupplierBusinessInfo
    {
        private MultivendorEcommerceStoreEntities _db;

        public SupplierBusinessInfo()
        {
            _db = new MultivendorEcommerceStoreEntities();
        }

        public void Create(SupplierBusinessInformation entity)
        {
            _db.SupplierBusinessInformations.Add(entity);
            _db.SaveChanges();
        }

        public IEnumerable<SupplierBusinessInformation> Retrive()
        {
            var businessInfo = _db.SupplierBusinessInformations.ToList();
            return businessInfo;
        }

        public void Update(SupplierBusinessInformation entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var businessInfoID = GetById(id);
            _db.SupplierBusinessInformations.Remove(businessInfoID);
            _db.SaveChanges();
        }

        public SupplierBusinessInformation GetById(Guid id)
        {
            var businessInfoID = _db.SupplierBusinessInformations.Where(b => b.SupplierID == id).FirstOrDefault();
            return businessInfoID;
        }
    }
}
