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
        public List<DashboardStatisticsVM> DashboardStats()
        {
            IAspNetUsersRepository aspNetUserRepo = new AspNetUsersRepository();
            IProductRepository productRepo = new ProductRepository();

            List<DashboardStatisticsVM> viewModelList = new List<DashboardStatisticsVM>();
            DashboardStatisticsVM viewModel = new DashboardStatisticsVM();

            viewModel.UsersCount = aspNetUserRepo.Retrive().Count();
            viewModel.ProductsCount = productRepo.Retrive().Count();
            viewModelList.Add(viewModel);

            return viewModelList;
        }

        //public List<OrganizationUsersViewModel> DashboardStats()
        //{

        //    IUserProfileRepository userProfileRepository = new UserProfileRepository();
        //    IOrganizationRepository organizationRepository = new OrganizationRepository();

        //    List<OrganizationUsersViewModel> viewModelList = new List<OrganizationUsersViewModel>();

        //    var organizations = organizationRepository.Retrive();
        //    foreach (var item in organizations)
        //    {
        //        OrganizationUsersViewModel viewModel = new OrganizationUsersViewModel();
        //        viewModel.OrganizationID = item.OrganizationID;
        //        viewModel.OrganizationName = item.Name;
        //        viewModel.UsersCount = userProfileRepository.Get().Where(s => s.OrganizationID == item.OrganizationID).Count();

        //        viewModelList.Add(viewModel);
        //    }
        //    return viewModelList;
        //}

    }
}
