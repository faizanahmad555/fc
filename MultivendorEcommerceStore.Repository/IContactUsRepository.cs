using MultivendorEcommerceStore.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.Repository
{
    public interface IContactUsRepository
    {
        void Create(ContactU entity);
        IEnumerable<ContactU> Retrive();
        void Update(ContactU entity);
        void Delete(Guid ContactID);
        ContactU GetById(Guid? id);
    }
}
