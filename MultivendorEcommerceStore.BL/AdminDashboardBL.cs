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
            IDashboardRepository dashboardRepo = new DashboardRepository();
            DashboardStatisticsVM viewModel = new DashboardStatisticsVM();

            viewModel.UsersCount = dashboardRepo.Retrive().Count();
            viewModel.ProductsCount = dashboardRepo.Get().Count();
            return viewModel;
        }
    }
}
