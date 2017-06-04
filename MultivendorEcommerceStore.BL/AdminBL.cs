using MultivendorEcommerceStore.DB.Model;
using MultivendorEcommerceStore.DB.ViewModel;
using MultivendorEcommerceStore.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MultivendorEcommerceStore.BL
{
    public class AdminBL
    {
        private MultivendorEcommerceStoreEntities _dbctx = new MultivendorEcommerceStoreEntities();
     
        #region Manage Supplier

        // ADD: Supplier(For Admin Side)
        public void AddSupplier(AddSupplierViewModel model)
        {
            ISupplierRepository repository = new SupplierRepository();
            Supplier supplier = new Supplier();

            var fileName = Path.GetFileNameWithoutExtension(model.ProfilePhoto.FileName);
            fileName += DateTime.Now.Ticks + Path.GetExtension(model.ProfilePhoto.FileName);
            var basePath = "~/Content/Users/Suppliers/" + model.AspNetUserID + "/Profile/Images/";
            var path = Path.Combine(HttpContext.Current.Server.MapPath(basePath), fileName);
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Users/Suppliers/" + model.AspNetUserID + "/Profile/Images/"));
            model.ProfilePhoto.SaveAs(path);


            supplier.SupplierID = Guid.NewGuid();
            supplier.AspNetUserID = model.AspNetUserID;
            supplier.SupplierFirstName = model.FirstName;
            supplier.SupplierLastName = model.LastName;
            supplier.ProfilePhoto = basePath + fileName;
            supplier.Gender = model.Gender;
            supplier.Phone = model.MobileNumber;
            supplier.Address = model.Address;
            supplier.Email = model.Email;
            supplier.CountryID = model.Country;
            supplier.StateID = model.State;
            supplier.CityID = model.City;
            supplier.CNIC = model.CNIC;
            supplier.PostalCode = model.PostalCode;
            supplier.CreatedOn = DateTime.Now;

            repository.Create(supplier);
        }

        // SHOW: All Suppliers(For Admin Side)
        public List<SupplierListViewModel> SupplierList()
        {
            var supplierRepo = new SupplierRepository();
            var countryRepo = new CountryRepository();
            var stateRepo = new StateRepository();
            var cityRepo = new CityRepository();

            List<SupplierListViewModel> viewModelList = new List<SupplierListViewModel>();

            var supplierTbl = supplierRepo.Retrive();
            
            foreach (var supplier in supplierTbl)
            {
                SupplierListViewModel viewModel = new SupplierListViewModel();

                var city = cityRepo.Get().Where(s => s.CityID == supplier.CityID).FirstOrDefault();
                var state = stateRepo.Get().Where(s => s.StateID == city.StateID).FirstOrDefault();
                var country = countryRepo.Get().Where(s => s.CountryID == state.CountryID).FirstOrDefault();

                viewModel.AspNetUserID = supplier.AspNetUserID;
                viewModel.SupplierID = supplier.SupplierID;
                viewModel.FirstName = supplier.SupplierFirstName;
                viewModel.LastName = supplier.SupplierLastName;
                viewModel.Email = supplier.Email;
                viewModel.Address = supplier.Address;
                viewModel.MobileNumber = supplier.Phone;
                viewModel.PostalCode = supplier.PostalCode;
                viewModel.ProfilePhoto = supplier.ProfilePhoto;
                viewModel.City = city.Name;
                viewModel.State = state.Name;
                viewModel.Country = country.Name;
                viewModelList.Add(viewModel);
            }
            return viewModelList;
        }

        // DELETE: Supplier(For Admin Side)
        public void DeleteSupplier(string UserID)
        {
            ISupplierRepository repository = new SupplierRepository();
            repository.DeleteSuppliers(UserID);
        }


        // ADD: Supplier Busienss Information(For Admin Side)
        public void AddBusinessInfo(AddSupplierBusinessInfoVM viewModel)
        {
            ISupplierBusinessInfo repository = new SupplierBusinessInfo();
            SupplierBusinessInformation businessInfo = new SupplierBusinessInformation();

            var fileName = Path.GetFileNameWithoutExtension(viewModel.Logo.FileName);
            fileName += DateTime.Now.Ticks + Path.GetExtension(viewModel.Logo.FileName);
            var basePath = "~/Content/Users/Suppliers/" + viewModel.SupplierID + "/BusinessInfo/Images/";
            var path = Path.Combine(HttpContext.Current.Server.MapPath(basePath), fileName);
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Users/Suppliers/" + viewModel.SupplierID + "/BusinessInfo/Images/"));
            viewModel.Logo.SaveAs(path);


            businessInfo.BusinessInfoID = Guid.NewGuid();
            businessInfo.SupplierID = viewModel.SupplierID;
            businessInfo.CompanyName = viewModel.CompanyName;
            businessInfo.Logo = basePath + fileName;
            businessInfo.BusinessEmail = viewModel.BusinessEmail;
            businessInfo.Phone = viewModel.Phone;
            businessInfo.BusinessExperience = viewModel.BusinessExperience;
            businessInfo.ProductType = viewModel.ProductsType;
            businessInfo.CreatedOn = DateTime.Now;

            repository.Create(businessInfo);
        }

        public Guid GetSupplierByUserID(string userID)
        {
            ISupplierRepository repo = new SupplierRepository();
            return repo.Retrive().FirstOrDefault(s => s.AspNetUserID == userID).SupplierID;
        }

        #endregion


        #region Manage Customers

        // EDIT: EXISTING Customer(For Admin Side)
        public EditCustomerViewModel EditCustomerInfo(string userID, Guid customerID)
        {
            var customerRepo = new CustomerRepository();
            var customer = customerRepo.Retrive().Where(s => s.AspNetUserID == userID && s.CustomerID == customerID).FirstOrDefault();

            EditCustomerViewModel viewModel = new EditCustomerViewModel();
            viewModel.AspNetUserID = customer.AspNetUserID;
            viewModel.CustomerID = customer.CustomerID;
            viewModel.FirstName = customer.FirstName;
            viewModel.LastName = customer.LastName;
            viewModel.EmailAddress = customer.Email;
            viewModel.Mobile = customer.Mobile;
            viewModel.Address = customer.Address;
            return viewModel;
        }

        // EDIT: Save Edited Customer(For Admin Side)
        public void SaveEditedCustomerInfo(EditCustomerViewModel viewModel)
        {
            var customerRepo = new CustomerRepository();
            var customer = new Customer();

            customer.CustomerID = viewModel.CustomerID;
            customer.AspNetUserID = viewModel.AspNetUserID;
            customer.FirstName = viewModel.FirstName;
            customer.LastName = viewModel.LastName;
            customer.Email = viewModel.EmailAddress;
            customer.Address = viewModel.Address;
            customer.Mobile = viewModel.Mobile;

            customerRepo.Update(customer);
        }





        #endregion



        #region CountryStateCity

        // GET: Countries
        public IEnumerable<CountryMaster> GetCountries()
        {
            ICountryRepository countryRepo = new CountryRepository();
            return countryRepo.Get();
        }

        // GET: States
        public IEnumerable<StateMaster> GetStatesByCountryID(int ID)
        {
            IStateRepository stateRepo = new StateRepository();
            return stateRepo.Get().Where(s => s.CountryID == ID).ToList();
        }

        // GET: Cities
        public IEnumerable<CityMaster> GetCitiesByStateID(int ID)
        {
            ICityRepository cityRepo = new CityRepository();
            return cityRepo.Get().Where(c => c.StateID == ID).ToList();
        }

        #endregion



      



    }
}
