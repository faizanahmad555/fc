using MultivendorEcommerceStore.DB.ViewModel;
using MultivendorEcommerceStore.Repository;
using MultivendorEcommerceStore.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.BL
{
    public class CustomerBL
    {
        // ADD: Customer
        public void CustomerRegister(CustomerLoginRegisterViewModel model)
        {
            ICustomerRepository customerRepo = new CustomerRepository();
            Customer customer = new Customer();
            
            customer.CustomerID = Guid.NewGuid();
            customer.AspNetUserID = model.CustomerRegisterVM.AspNetUserID;
            customer.Email = model.CustomerRegisterVM.EmailAddress;
            customer.FirstName = model.CustomerRegisterVM.FirstName;
            customer.LastName = model.CustomerRegisterVM.LastName;
            customer.CreatedOn = DateTime.Now;

            customerRepo.Create(customer);
        }


        // GET: All Customers (For Admin Side)
        public List<CustomerListViewModel> CustomerList()
        {
            ICustomerRepository customerRepo = new CustomerRepository();
            List<CustomerListViewModel> viewModelList = new List<CustomerListViewModel>();

            var customerTbl = customerRepo.Retrive().ToList();

            foreach (var customer in customerTbl)
            {
                CustomerListViewModel viewModel = new CustomerListViewModel();

                viewModel.CustomerID = customer.CustomerID;
                viewModel.AspNetUserID = customer.AspNetUserID;
                viewModel.FirstName = customer.FirstName;
                viewModel.LastName = customer.LastName;
                viewModel.Email = customer.Email;
                //viewModel.Phone = customer.Phone;
                viewModel.CreatedOn = customer.CreatedOn;
                viewModelList.Add(viewModel);
            }
            return viewModelList;
        }


        // DELETE: Customer (For Admin Side)
        public void DeleteCustomer(string UserID)
        {
            ICustomerRepository customerRepo = new CustomerRepository();
            customerRepo.Delete(UserID);
        }

    }
}
