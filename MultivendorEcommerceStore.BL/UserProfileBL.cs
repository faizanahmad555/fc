using MultivendorEcommerceStore.DB.ViewModel;
using MultivendorEcommerceStore.Repository;
using System;
using System.Linq;
using System.Web;

namespace MultivendorEcommerceStore.BL
{
    public class UserProfileBL
    {
        // GET: Current User Profile
        public UserProfileViewModel GetProfileByUserIdentity(string userID)
        {
            AspNetUsersRepository userRepo = new AspNetUsersRepository();
            SupplierRepository supplierRepo = new SupplierRepository();
            CustomerRepository customerRepo = new CustomerRepository();

            ICountryRepository countryRepo = new CountryRepository();
            IStateRepository stateRepo = new StateRepository();
            ICityRepository cityRepo = new CityRepository();

            UserProfileViewModel viewModel = new UserProfileViewModel();

            if (HttpContext.Current.User.IsInRole("Supplier"))
            {
                var yourProfile = supplierRepo.Retrive().Where(s => s.AspNetUserID == userID).FirstOrDefault();
                if (yourProfile != null)
                {
                    var city = cityRepo.Get().Where(s => s.CityID == yourProfile.CityID).FirstOrDefault();
                    var state = stateRepo.Get().Where(s => s.StateID == yourProfile.StateID).FirstOrDefault();
                    var country = countryRepo.Get().Where(s => s.CountryID == yourProfile.CountryID).FirstOrDefault();
                    
                    viewModel.UserID = userID;
                    viewModel.SupplierID = yourProfile.SupplierID;
                    viewModel.FirstName = yourProfile.SupplierFirstName;
                    viewModel.LastName = yourProfile.SupplierLastName;
                    viewModel.Email = yourProfile.Email;
                    viewModel.Address = yourProfile.Address;
                    viewModel.MobileNo = yourProfile.Phone;
                    viewModel.ProfilePhoto = yourProfile.ProfilePhoto;
                    viewModel.City = city.Name;
                    viewModel.State = state.Name;
                    viewModel.Country = country.Name;
                }
            }

            else if (HttpContext.Current.User.IsInRole("Customer"))
            {
                var yourProfile = customerRepo.Retrive().Where(s => s.AspNetUserID == userID).FirstOrDefault();
                if (yourProfile != null)
                {
                    //var city = cityRepo.Get().Where(s => s.CityID == yourProfile.CityID).FirstOrDefault();
                    //var state = stateRepo.Get().Where(s => s.StateID == yourProfile.StateID).FirstOrDefault();
                    //var country = countryRepo.Get().Where(s => s.CountryID == yourProfile.CountryID).FirstOrDefault();

                    viewModel.UserID = userID;
                    viewModel.CustomerID = yourProfile.CustomerID;
                    viewModel.FirstName = yourProfile.FirstName;
                    viewModel.LastName = yourProfile.LastName;
                    viewModel.Email = yourProfile.Email;
                    //viewModel.Address = yourProfile.Address1;
                    //viewModel.MobileNo = yourProfile.Phone;
                    //viewModel.ProfilePhoto = yourProfile.ProfilePhoto;
                    //viewModel.City = city.Name;
                    //viewModel.State = state.Name;
                    //viewModel.Country = country.Name;
                }
            }

            return viewModel;
        }



        // GET: Current Supplier Profile(For Admin Side)
        public UserProfileViewModel GetSupplierProfileByUserIdentity(string userID)
        {
            AspNetUsersRepository userRepo = new AspNetUsersRepository();
            SupplierRepository supplierRepo = new SupplierRepository();
            CustomerRepository customerRepo = new CustomerRepository();

            ICountryRepository countryRepo = new CountryRepository();
            IStateRepository stateRepo = new StateRepository();
            ICityRepository cityRepo = new CityRepository();

            UserProfileViewModel viewModel = new UserProfileViewModel();

            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                var yourProfile = supplierRepo.Retrive().Where(s => s.AspNetUserID == userID).FirstOrDefault();
                if (yourProfile != null)
                {
                    var city = cityRepo.Get().Where(s => s.CityID == yourProfile.CityID).FirstOrDefault();
                    var state = stateRepo.Get().Where(s => s.StateID == yourProfile.StateID).FirstOrDefault();
                    var country = countryRepo.Get().Where(s => s.CountryID == yourProfile.CountryID).FirstOrDefault();

                    viewModel.UserID = userID;
                    viewModel.SupplierID = yourProfile.SupplierID;
                    viewModel.FirstName = yourProfile.SupplierFirstName;
                    viewModel.LastName = yourProfile.SupplierLastName;
                    viewModel.Email = yourProfile.Email;
                    viewModel.Address = yourProfile.Address;
                    viewModel.MobileNo = yourProfile.Phone;
                    viewModel.ProfilePhoto = yourProfile.ProfilePhoto;
                    viewModel.City = city.Name;
                    viewModel.State = state.Name;
                    viewModel.Country = country.Name;
                }
            }
            
            return viewModel;
        }

    }
}
