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
    public class NotificationBL
    {
        public NotificationViewModel GetUnSeenNotification()
        {
            var productNR = new ProductNotificationRepository();
            var productRepo = new ProductRepository();

            var customerRepo = new CustomerRepository();
            var customerNR = new CustomerNotificationRepository();

            var list = new NotificationViewModel();


            IEnumerable<CustomerNotification> customerNotification = customerNR.GetUnSeen();
            List<CustomerNotificationViewModel> customerNL = customerNotification.Select(i => new CustomerNotificationViewModel
            {
                CustomerNotificationID = Guid.NewGuid(),
                CustomerID = i.CustomerID,
                CustomerNotificationDescription = i.Description,
                //CustomerNotificationID = i.CustomerNotificationID,
                CustomerNotificationIsSeen = i.IsSeen,
                CustomerNotificationURL = i.URL,
                CustomerImage = customerRepo.Retrive().Where(c => c.CustomerID == i.CustomerID).Select(c => c.ProfilePhoto).FirstOrDefault(),
            }).ToList();

            
            IEnumerable<ProductNotification> productNotification = productNR.GetUnSeen();
            List<ProductNotificationViewModel> productNL = productNotification.Select(i => new ProductNotificationViewModel
            {
                ProductNotificationID = i.ProductNotificationID,
                ProductID = i.ProductID,
                ProductNotificationDescription = i.Description,
                ProductNotificationIsSeen = i.IsSeen,
                ProductNotificationURL = i.URL,
                ProductImage = productRepo.Retrive().Where(p => p.ProductID == i.ProductID).Select(p => p.ProductPicture).FirstOrDefault(),
            }).ToList();




            list.ProductNotificationList = productNL;
            list.CustomerNotificationList = customerNL;
            
            return list;
        }

        public void ChangeIsSeenState(SeenNotifications model)
        {
            for (int i = 1; i < model.ProductArray.Count(); i++)
            {
                ChangeProductSeenStatus(model.ProductArray[i]);
            }
            for (int i = 1; i < model.CustomerArray.Count(); i++)
            {
                ChangeCustomerSeenStatus(model.CustomerArray[i]);
            }
        }

        public void ChangeProductSeenStatus(Guid productID)
        {
            var productNR = new ProductNotificationRepository();
            productNR.ChangeIsSeenByID(productID);
        }

        public void ChangeCustomerSeenStatus(Guid customerID)
        {
            var customerNR = new CustomerNotificationRepository();
            customerNR.ChangeIsSeenByID(customerID);
        }



        public DisplayProductViewModel GetProductDetail(Guid productID)
        {
            var productRepo = new ProductRepository();
            var supplierRepo = new SupplierRepository();
            var supplierBusinessRepo = new SupplierBusinessInfo();

            var product = productRepo.GetById(productID);
            var supplier = supplierRepo.GetById(product.SupplierID);
            var supplierBusinessInfo = supplierBusinessRepo.GetById(supplier.SupplierID);

            return new DisplayProductViewModel()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductImage1 = product.ProductPicture,
                Price = product.UnitPrice,
                Quantity = product.Quantity,

                UserID = supplier.AspNetUserID,
                SupplierID = supplier.SupplierID,
                FirstName = supplier.SupplierFirstName,
                LastName = supplier.SupplierLastName,
                ProfilePhoto = supplier.ProfilePhoto,

                BusinessExperience = supplierBusinessInfo.BusinessExperience,
                ProductsType = supplierBusinessInfo.ProductType,
                CompanyName = supplierBusinessInfo.CompanyName,
            };
        }


    }
}
