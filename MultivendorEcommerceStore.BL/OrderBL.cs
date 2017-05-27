using MultivendorEcommerceStore.DB.Model;
using MultivendorEcommerceStore.DB.ViewModel;
using MultivendorEcommerceStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.BL
{
    public class OrderBL
    {
        public dynamic GetOrdersForChart()
        {
            var orderRepo = new OrderRepository();
            dynamic ords = "";

            try
            {
                ords = orderRepo.Get().GroupBy(item => item.CreatedOn.Value.Date)
           .Select(group => new
           {

               CreatedOn = group.Key,
               Count = group.Count()
           })
           .ToList();

            }

            catch (Exception ex)
            {
                
            }

           
            return ords;
        }

        public void AddOrderDetail(AddOrderDetailViewModel viewModel)
        {
            IOrderDetailRepository repo = new OrderDetailRepository();
            OrderDetail entity = new OrderDetail();
            entity.OrderDetailID = Guid.NewGuid();
            entity.OrderID = viewModel.OrderID;
            entity.ProductID = viewModel.ProductID;
            entity.Quantity = viewModel.Quantity;
            entity.UnitPrice = viewModel.UnitPrice;
            repo.Insert(entity);
        }

        public Order GetOrderByPayPalReference(string PayPalReference)
        {
            IOrderRepository repo = new OrderRepository();
            return repo.Get().Where(s => s.PayPalReference == PayPalReference).FirstOrDefault();
        }

        public void AddOrder(AddOrderViewModel viewModel)
        {
            IOrderRepository orderRepo = new OrderRepository();
            var entity = new Order();
            entity.OrderID = Guid.NewGuid();
            entity.CustomerID = viewModel.CustomerID;
            //entity.PaymentID = viewModel.PaymentID;
            entity.Tax = viewModel.Tax;
            entity.SubTotal = viewModel.SubTotal;
            entity.Total = viewModel.Total;
            entity.Shipping = viewModel.Shipping;
            entity.PayPalReference = viewModel.PayPalReference;
            entity.CreatedOn = DateTime.Now;
            orderRepo.Insert(entity);
        }

        public Guid AddOrderReturnID(AddOrderViewModel viewModel)
        {
            IOrderRepository orderRepo = new OrderRepository();
            var entity = new Order();
            entity.OrderID = Guid.NewGuid();
            entity.CustomerID = viewModel.CustomerID;
            //entity.PaymentID = viewModel.PaymentID;
            entity.Tax = viewModel.Tax;
            entity.SubTotal = viewModel.SubTotal;
            entity.Total = viewModel.Total;
            entity.Shipping = viewModel.Shipping;
            entity.PayPalReference = viewModel.PayPalReference;
            entity.CreatedOn = DateTime.Now;
            return orderRepo.InsertAndReturnID(entity);
        }
    }
}
