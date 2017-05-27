using MultivendorEcommerceStore.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.Repository
{
    public interface IOrderDetailRepository
    {
        void Insert(OrderDetail entity);
        IEnumerable<OrderDetail> Get();
        IEnumerable<OrderDetail> GetByOrderID(Guid? orderID);
    }
}
