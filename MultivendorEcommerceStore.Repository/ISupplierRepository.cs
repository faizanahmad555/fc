using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public interface ISupplierRepository
    {
        void Create(Supplier entity);
        IEnumerable<Supplier> Retrive();
        void Update(Supplier entity);
        void Delete(string UserID);
        Supplier GetById(Guid id);
        AspNetUser GetByAspNetUserID(string UserID);
    }
}
