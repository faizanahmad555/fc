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

            var list = new NotificationViewModel();

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


            return list;
        }

        public void ChangeIsSeenState(SeenNotifications model)
        {
            for (int i = 1; i < model.ProductArray.Count(); i++)
            {
                ChangeProductSeenStatus(model.ProductArray[i]);
            }
        }

        public void ChangeProductSeenStatus(Guid productID)
        {
            var productNR = new ProductNotificationRepository();
            productNR.ChangeIsSeenByID(productID);
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
