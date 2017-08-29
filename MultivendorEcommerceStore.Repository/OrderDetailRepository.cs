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
        public IEnumerable<Orders_Detail> Get()
        {
            return _context.Orders_Detail.ToList();
        }
        public IEnumerable<Orders_Detail> GetByOrderID(Guid? orderID)
        {
            return _context.Orders_Detail.Where(s => s.Id == orderID).ToList();
        }
        public void Insert(Orders_Detail entity)
        {
            _context.Orders_Detail.Add(entity);
            _context.SaveChanges();
        }
    }
}
