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
        public DashboardStatisticsVM DashboardStats()
        {
            var aspNetUserRepo = new AspNetUsersRepository();
            var productRepo = new ProductRepository();
            var orderRepo = new OrderRepository();

            var OrderBL = new OrderBL();
            var ProductBL = new ProductBL();
            var AdminBL = new AdminBL();
            var CustomerBL = new CustomerBL();

            DashboardStatisticsVM viewModel = new DashboardStatisticsVM();

            viewModel.UsersCount = aspNetUserRepo.Retrive().Count();
            viewModel.ProductsCount = productRepo.Retrive().Count();
            viewModel.OrdersCount = orderRepo.Get().Count();


            viewModel.OrdersChart = OrderBL.GetOrdersForChart();
            viewModel.ProductsChart = ProductBL.GetProductsForChart();
            viewModel.SuppliersChart = AdminBL.GetSuppliersForChart();
            viewModel.CustomersChart = CustomerBL.GetCustomersForChart();


            return viewModel;
        }


        public DashboardStatisticsVM SupplierDashboardStats(Guid? supplierID)
        {
           
            var productRepo = new ProductRepository();
            var orderRepo = new OrderRepository();

            var OrderBL = new OrderBL();
            var ProductBL = new ProductBL();
            DashboardStatisticsVM viewModel = new DashboardStatisticsVM();


            viewModel.SupplierProductsCount = productRepo.Retrive().Where(s=>s.SupplierID == supplierID).Count();
            viewModel.SupplierOrdersCount = OrderBL.GetOrdersBySupplierID(supplierID).Count();

            viewModel.OrdersChart = OrderBL.GetOrdersForChart();
            viewModel.SupplierProductsChart = ProductBL.GetProductsChartForSupplier(supplierID);
            viewModel.SupplierOrdersChart = OrderBL.GetOrdersChartForSuppliers(supplierID);

            return viewModel;
        }




        public int GetAllOrdersCount()
        {
            return new OrderRepository().Get().Count();
        }




    }
}
