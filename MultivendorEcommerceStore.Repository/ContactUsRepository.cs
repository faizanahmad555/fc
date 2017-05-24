using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public class ContactUsRepository : IContactUsRepository
    {
        private MultivendorEcommerceStoreEntities _db;

        public void Create(ContactU entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            _db.ContactUS.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Guid ContactID)
        {
            var contact = GetById(ContactID);
            _db.ContactUS.Remove(contact);
            _db.SaveChanges();
        }

        public ContactU GetById(Guid? id)
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.ContactUS.Where(s => s.ContactID == id).FirstOrDefault();
        }

        public IEnumerable<ContactU> Retrive()
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.ContactUS.ToList();
        }

        public void Update(ContactU entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            var contactMessage = _db.ContactUS.Where(s => s.ContactID == entity.ContactID).FirstOrDefault();
            contactMessage.FirstName = entity.FirstName;
            contactMessage.LastName = entity.LastName;
            contactMessage.Email = entity.Email;
            contactMessage.Message = entity.Message;
            _db.SaveChanges();
        }
    }
}
