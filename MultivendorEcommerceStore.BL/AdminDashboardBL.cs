using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.Repository;
using MultivendorEcommerceStore.DB.ViewModel;

namespace MultivendorEcommerceStore.BL
{
    public class AdminDashboardBL
    {
        public int GetAllUsersCount()
        {
            return new AspNetUsersRepository().Retrive().Count();
        }

        public int GetAllSuppliersCount()
        {
            return new SupplierRepository().Retrive().Count();
        }

        public int GetAllCustomersCount()
        {
            return new CustomerRepository().Retrive().Count();
        }

        public int GetAllProductsCount()
        {
            return new ProductRepository().Retrive().Count();
        }

        public int GetAllOrdersCount()
        {
            return new OrderRepository().Get().Count();
        }



        public dynamic GetAllProductsForChart()
        {
            var productRepo = new ProductRepository();
            dynamic prds = "";

            try
            {
                prds = productRepo.Retrive().GroupBy(item => item.CreatedOn.Value.Date)
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

        public dynamic GetAllOrdersForChart()
        {
            var orderRepo = new OrderRepository();
            dynamic ords = "";

            try
            {
                ords = orderRepo.Get().GroupBy(item => item.CreatedOn.Date)
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

        public dynamic GetAllSuppliersForChart()
        {
            var supplierRepo = new SupplierRepository();
            dynamic sups = "";

            try
            {
                sups = supplierRepo.Retrive().GroupBy(item => item.CreatedOn.Value.Date)
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

            return sups;
        }

        public dynamic GetAllCustomersForChart()
        {
            var customerRepo = new CustomerRepository();
            dynamic cust = "";

            try
            {
                cust = customerRepo.Retrive().GroupBy(item => item.CreatedOn.Value.Date)
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

            return cust;
        }




    }
}
