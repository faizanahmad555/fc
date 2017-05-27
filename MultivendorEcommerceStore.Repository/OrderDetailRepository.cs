using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly MultivendorEcommerceStoreEntities _context;
        public OrderDetailRepository()
        {
            _context = new MultivendorEcommerceStoreEntities();
        }
        public IEnumerable<OrderDetail> Get()
        {
            return _context.OrderDetails.ToList();
        }
        public IEnumerable<OrderDetail> GetByOrderID(Guid? orderID)
        {
            return _context.OrderDetails.Where(s => s.OrderID == orderID).ToList();
        }
        public void Insert(OrderDetail entity)
        {
            _context.OrderDetails.Add(entity);
            _context.SaveChanges();
        }
    }
}
