using MultivendorEcommerceStore.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.Repository
{
    public interface IOrderRepository
    {
        void Insert(Order entity);
        IEnumerable<Order> Get();
        Order GetByID(Guid? orderID);
        Guid InsertAndReturnID(Order entity);
        //IEnumerable<Order> GetByShopID(int? shopID);
        IEnumerable<Order> GetByCustomerID(Guid? customerID);
    }
}
