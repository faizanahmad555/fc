using System;
using System.Collections.Generic;
using MultivendorEcommerceStore.DB.ViewModel;

namespace MultivendorEcommerceStore.BL
{
    public interface IProductBL
    {
        void AddEditedSupplierProduct(EditProductViewModel viewModel);
        void AddProduct(AddProductViewModel model, Guid SupplierID);
        List<CustomerListViewModel> CustomerList();
        void CustomerRegister(CustomerLoginRegisterViewModel model);
        void DeleteCustomer(string UserID);
        void DeleteProduct(Guid ProductID);
        EditProductViewModel EditSupplierProduct(Guid SupplierID, Guid ProductID);
        List<ProductListViewModel> GetProductsBySupplierID(Guid SupplierID);
        List<ProductListViewModel> ProductList();
    }
}