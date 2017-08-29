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
        void Insert(Orders_Detail entity);
        IEnumerable<Orders_Detail> Get();
        IEnumerable<Orders_Detail> GetByOrderID(Guid? orderID);
    }
}
