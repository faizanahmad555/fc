using MultivendorEcommerceStore.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.Repository
{
    public interface ICustomerRepository
    {
        void Create(Customer entity);


        IEnumerable<Customer> Retrive();
        void Update(Customer entity);
        void Delete(string UserID);
        Customer GetById(Guid Id);
        AspNetUser GetByAspNetUserID(string UserID);
    }
}
