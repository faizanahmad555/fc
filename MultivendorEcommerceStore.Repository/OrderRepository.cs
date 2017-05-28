using MultivendorEcommerceStore.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.Repository
{
    public class OrderRepository: IOrderRepository
    {
        private readonly MultivendorEcommerceStoreEntities _context;
        public OrderRepository()
        {
            _context = new MultivendorEcommerceStoreEntities();
        }

        public IEnumerable<Order> Get()
        {
            return _context.Orders.ToList();
        }

        public Order GetByID(Guid? orderID)
        {
            return _context.Orders.Where(s=> s.OrderID == orderID).FirstOrDefault();
        }

        public IEnumerable<Order> GetBySupplierID(Guid? supplierID)
        {
            return _context.Orders.Where(s => s.OrderDetails.Any(i => i.Product.Supplier.SupplierID == supplierID)).ToList();
        }
        public void Insert(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }


        public Guid InsertAndReturnID(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
            return entity.OrderID;
        }

        public IEnumerable<Order> GetByCustomerID(Guid? customerID)
        {
            return Get().Where(s => s.CustomerID == customerID).ToList().OrderByDescending(w=>w.CreatedOn);
        }

        
    }
}
