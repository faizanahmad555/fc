﻿using MultivendorEcommerceStore.DB.ViewModel;
using MultivendorEcommerceStore.Repository;
using MultivendorEcommerceStore.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace MultivendorEcommerceStore.BL
{
    public class CustomerBL
    {

        // ADD: Customer
        public void CustomerRegister(CustomerLoginRegisterViewModel model)
        {
            var customerRepo = new CustomerRepository();
            Customer customer = new Customer();


            //var fileName = Path.GetFileNameWithoutExtension(model.CustomerRegisterVM.ProfilePicture.FileName);
            //fileName += DateTime.Now.Ticks + Path.GetExtension(model.CustomerRegisterVM.ProfilePicture.FileName);
            //var basePath = "~/Content/Customer/" + model.CustomerRegisterVM.AspNetUserID + "/ProfilePhoto/";
            //var path = Path.Combine(HttpContext.Current.Server.MapPath(basePath), fileName);
            //Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Customer/" + model.CustomerRegisterVM.AspNetUserID + "/ProfilePhoto/"));
            //model.CustomerRegisterVM.ProfilePicture.SaveAs(path);

            customer.CustomerID = Guid.NewGuid();
            customer.AspNetUserID = model.CustomerRegisterVM.AspNetUserID;
            customer.Email = model.CustomerRegisterVM.EmailAddress;
            customer.FirstName = model.CustomerRegisterVM.FirstName;
            customer.LastName = model.CustomerRegisterVM.LastName;
            //customer.ProfilePhoto = basePath + fileName;
            customer.Address = model.CustomerRegisterVM.Address;
            customer.Mobile = model.CustomerRegisterVM.Mobile;
            customer.CityID = model.CustomerRegisterVM.City;
            customer.StateID = model.CustomerRegisterVM.State;
            customer.CountryID = model.CustomerRegisterVM.Country;
            customer.CreatedOn = DateTime.Now;

            //customer.DOB = model.DOB;
            //customer.IsActive = true;

            //var customerID = customerRepo.InsertAndGetID(customer);

            //var customerNR = new CustomerNotificationRepository();
            //var customerNE = new CustomerNotification();

            //customerNE.CustomerNotificationID = Guid.NewGuid();
            //customerNE.CustomerID = customerID;
            //customerNE.Description = "New Customer has been added";
            //customerNE.IsSeen = false;
            //customerNE.URL = "/Notification/CustomerDetail?customerID=" + customerID;
            //customerNE.CreatedOn = DateTime.Now;

            //customerNR.Insert(customerNE);
            customerRepo.Create(customer);
        }


        // GET: All Customers (For Admin Side)
        public IEnumerable<CustomerListViewModel> CustomerList()
        {
            var customerRepo = new CustomerRepository();
            List<CustomerListViewModel> customersList = new List<CustomerListViewModel>();

            var customerTbl = customerRepo.Retrive().ToList();

            foreach (var customer in customerTbl)
            {
                CustomerListViewModel viewModel = new CustomerListViewModel();

                viewModel.CustomerID = customer.CustomerID;
                viewModel.AspNetUserID = customer.AspNetUserID;
                viewModel.FirstName = customer.FirstName;
                viewModel.LastName = customer.LastName;
                viewModel.Email = customer.Email;
                viewModel.Phone = customer.Mobile;
                viewModel.Address = customer.Address;
                viewModel.CreatedOn = customer.CreatedOn;
                customersList.Add(viewModel);
            }
            return customersList;
        }




        public IEnumerable<CustomerListViewModel> GetCustomersByRange(DateTime from, DateTime to)
        {
            return new CustomerRepository().Retrive().Where(s => s.CreatedOn >= from && s.CreatedOn <= s.CreatedOn).Select(i => new CustomerListViewModel
            {
                CustomerID = i.CustomerID,
                AspNetUserID = i.AspNetUserID,
                FirstName = i.FirstName,
                LastName = i.LastName,
                Email = i.Email,
                Phone = i.Mobile,
                Address = i.Address,
                CreatedOn = i.CreatedOn,
            });
        }


        // DELETE: Customer (For Admin Side)
        public void DeleteCustomer(string UserID)
        {
            ICustomerRepository customerRepo = new CustomerRepository();
            customerRepo.Delete(UserID);
        }


        // GET: Current Customer Orders(For Front End Side)
        public IEnumerable<DisplayOrderViewModel> GetMyOrder(Guid? customerID)
        {
            var orderRepo = new OrderRepository();
            var orders = orderRepo.GetByCustomerID(customerID);
            return orders.Select(s => new DisplayOrderViewModel
            {
                CreatedOn = s.CreatedOn,
                OrderID = s.Id,
                CustomerName = s.Customer.FirstName,
                //Shipping = s.Shipping,
                //SubTotal = s.SubTotal,
                //Tax = s.Tax,
                //Total = s.Total,
            });
        }



    }
}
