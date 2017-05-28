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
            var OrderBL = new OrderBL();
            DashboardStatisticsVM viewModel = new DashboardStatisticsVM();

            viewModel.UsersCount = aspNetUserRepo.Retrive().Count();
            viewModel.ProductsCount = productRepo.Retrive().Count();

            viewModel.OrdersChart = OrderBL.GetOrdersForChart();
           


            return viewModel;
        }

        public int GetAllOrdersCount()
        {
            return new OrderRepository().Get().Count();
        }




    }
}
