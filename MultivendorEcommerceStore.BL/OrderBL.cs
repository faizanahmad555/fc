﻿using MultivendorEcommerceStore.DB.Model;
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
        public void AddOrderDetail(AddOrderDetailViewModel viewModel)
        {
            IOrderDetailRepository repo = new OrderDetailRepository();
            Orders_Detail entity = new Orders_Detail();
            entity.Id = Guid.NewGuid();
            entity.OrderId = viewModel.OrderID;
            entity.ProductID = viewModel.ProductID;
            entity.Quantity = viewModel.Quantity;
            entity.Product.UnitPrice = viewModel.UnitPrice;
            repo.Insert(entity);
        }

        //public Order GetOrderByPayPalReference(string PayPalReference)
        //{
        //    IOrderRepository repo = new OrderRepository();
        //    return repo.Get().Where(s => s.PayPalReference == PayPalReference).FirstOrDefault();
        //}

        public void AddOrder(AddOrderViewModel viewModel)
        {
            IOrderRepository orderRepo = new OrderRepository();
            var entity = new Order();
            entity.Id = Guid.NewGuid();
            entity.CustomerID = viewModel.CustomerID;
            //entity.PaymentID = viewModel.PaymentID;
            //entity.Tax = viewModel.Tax;
            //entity.SubTotal = viewModel.SubTotal;
            //entity.Total = viewModel.Total;
            //entity.Shipping = viewModel.Shipping;
            //entity.PayPalReference = viewModel.PayPalReference;
            entity.CreatedOn = DateTime.Now;
            orderRepo.Insert(entity);
        }

        public Guid AddOrderReturnID(AddOrderViewModel viewModel)
        {
            IOrderRepository orderRepo = new OrderRepository();
            var entity = new Order();
            entity.Id = Guid.NewGuid();
            entity.CustomerID = viewModel.CustomerID;
            //entity.PaymentID = viewModel.PaymentID;
            //entity.Tax = viewModel.Tax;
            //entity.SubTotal = viewModel.SubTotal;
            //entity.Total = viewModel.Total;
            //entity.Shipping = viewModel.Shipping;
            //entity.PayPalReference = viewModel.PayPalReference;
            entity.CreatedOn = DateTime.Now;
            return orderRepo.InsertAndReturnID(entity);
        }


        // Get All Orders(For Admin Side)
        public IEnumerable<DisplayOrderViewModel> GetAllOrders()
        {
            var orderRepo = new OrderRepository();
            var customerRepo = new CustomerRepository();
            IEnumerable<DisplayOrderViewModel> orderList = orderRepo.Get().Select(s => new DisplayOrderViewModel
            {
                OrderID = s.Id,
                CustomerName = customerRepo.GetById(s.CustomerID).FirstName,
                Email = customerRepo.GetById(s.CustomerID).Email,
                Mobile = customerRepo.GetById(s.CustomerID).Mobile,

                CreatedOn = s.CreatedOn,
                //Tax = s.Tax,
                //Total = s.Total,
                //Shipping = s.Shipping,
                //SubTotal = s.SubTotal,
            });
            return orderList;
        }


        public DisplayOrderViewModel GetOrderByID(Guid orderID)
        {
            var orderRepo = new OrderRepository();
            var order = orderRepo.GetByID(orderID);
            var customerRepo = new CustomerRepository();
            var viewModel = new DisplayOrderViewModel();
            viewModel.CustomerName = customerRepo.GetById(order.CustomerID).FirstName;
            viewModel.Email = customerRepo.GetById(order.CustomerID).Email;
            viewModel.Mobile = customerRepo.GetById(order.CustomerID).Mobile;
            //viewModel.Tax = order.Tax;
            //viewModel.Shipping = order.Shipping;
            //viewModel.Total = order.Total;
            //viewModel.SubTotal = order.SubTotal;
            viewModel.CreatedOn = order.CreatedOn;
            return viewModel;
        }

        public IEnumerable<DisplayOrderDetailViewModel> GetOrderDetailByOrderID(Guid orderID)
        {
            var orderDetailRepo = new OrderDetailRepository();
            var productRepo = new ProductRepository();
            IEnumerable<DisplayOrderDetailViewModel> orderDetailList = orderDetailRepo.GetByOrderID(orderID).Select(s => new DisplayOrderDetailViewModel
            {
                OrderDetailID = s.OrderId,
                OrderID = s.Id,

                ProductID = s.ProductID,
                Product = productRepo.GetById(s.ProductID).ProductName,
                ProductImage = productRepo.GetById(s.ProductID).ProductPicture,

                Quantity = s.Quantity,
                UnitPrice = s.Product.UnitPrice,
            });
            return orderDetailList;
        }


        // GET : All Order of Current Supplier(For Supplier Side)
        public IEnumerable<DisplayOrderViewModel> GetOrdersBySupplierID(Guid? supplierID)
        {
            var orderRepo = new OrderRepository();
            var customerRepo = new CustomerRepository();
            IEnumerable<DisplayOrderViewModel> orderList = orderRepo.GetBySupplierID(supplierID).Select(s => new DisplayOrderViewModel
            {
                OrderID = s.Id,
                CustomerName = customerRepo.GetById(s.CustomerID).FirstName,
                Email = customerRepo.GetById(s.CustomerID).Email,
                Mobile = customerRepo.GetById(s.CustomerID).Mobile,

                CreatedOn = s.CreatedOn,
                //Tax = s.Tax,
                //Total = s.Total,
                //Shipping = s.Shipping,
                //SubTotal = s.SubTotal,
            });
            return orderList;
        }
        
        // GET: Order By DateTime Range(For Supplier Side)
        public IEnumerable<DisplayOrderViewModel> GetOrdersByRange(Guid? supplierID, DateTime from, DateTime to)
        {
            var orderRepo = new OrderRepository();
            IEnumerable<DisplayOrderViewModel> orderList = orderRepo.GetBySupplierID(supplierID).Where(w => w.CreatedOn >= from && w.CreatedOn <= to).Select(s => new DisplayOrderViewModel
            {
                OrderID = s.Id,
                CustomerName = s.Customer.FirstName,
                Email = s.Customer.Email,
                Mobile = s.Customer.Mobile,
                CreatedOn = s.CreatedOn,
                //Tax = s.Tax,
                //Total = s.Total,
                //Shipping = s.Shipping,
                //SubTotal = s.SubTotal,
            });
            return orderList;
        }



        // GET: Order By DateTime Range(For Admin Side)
        public IEnumerable<DisplayOrderViewModel> GetAllOrdersByRange(DateTime from, DateTime to)
        {
            var orderRepo = new OrderRepository();
            var customerRepo = new CustomerRepository();
            IEnumerable<DisplayOrderViewModel> orderList = orderRepo.Get().Where(w => w.CreatedOn >= from && w.CreatedOn <= to).Select(s => new DisplayOrderViewModel
            {
                OrderID = s.Id,
                CustomerName = s.Customer.FirstName,
                Email = s.Customer.Email,
                Mobile = s.Customer.Mobile,
                CreatedOn = s.CreatedOn,
                //Tax = s.Tax,
                //Total = s.Total,
                //Shipping = s.Shipping,
                //SubTotal = s.SubTotal,
            });
            return orderList;
        }
    }
}
