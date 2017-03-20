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
        public void CustomerRegister(CustomerRegisterLoginViewModel model)
        {
            ICustomerRepository customerRepo = new CustomerRepository();
            Customer customer = new Customer();
            
            customer.CustomerID = Guid.NewGuid();
            customer.AspNetUserID = model.CustomerRegisterVM.AspNetUserID;
            customer.Email = model.CustomerRegisterVM.EmailAddress;
            customer.FirstName = model.CustomerRegisterVM.FirstName;
            customer.LastName = model.CustomerRegisterVM.LastName;

            customerRepo.Create(customer);
        }
    }
}
