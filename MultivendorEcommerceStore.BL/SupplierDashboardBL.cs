using MultivendorEcommerceStore.DB.ViewModel;
using MultivendorEcommerceStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.BL
{
    public class SupplierDashboardBL
    {

        public int GetAllProductsCount(Guid supplierID)
        {
            return new ProductRepository().Retrive().Where(s => s.Supplier.SupplierID == supplierID).Count();
        }

        public int GetAllOrdersCount(Guid supplierID)
        {
            return new OrderRepository().Get().Where(s => s.OrderDetails.Any(i => i.Product.Supplier.SupplierID == supplierID)).Count();
        }


        public dynamic GetProductsForChartForSuppliers(Guid? supplierID)
        {
            var productRepo = new ProductRepository();
            dynamic prds = "";

            try
            {
                prds = productRepo.Retrive().Where(p=>p.SupplierID == supplierID).GroupBy(item => item.CreatedOn.Value.Date)
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

            return prds;
        }

        public dynamic GetOrdersChartForSuppliers(Guid? supplierID)
        {
            var orderRepo = new OrderRepository();
            dynamic ords = "";

            try
            {
                ords = orderRepo.GetBySupplierID(supplierID).GroupBy(item => item.CreatedOn.Value.Date)
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


    }
}
