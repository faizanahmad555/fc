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

        // ADD: Supplier
        public void AddSupplier(AddSupplierViewModel model)
        {
            ISupplierRepository repository = new SupplierRepository();
            Supplier supplier = new Supplier();

            var fileName = Path.GetFileNameWithoutExtension(model.ProfilePhoto.FileName);
            fileName += DateTime.Now.Ticks + Path.GetExtension(model.ProfilePhoto.FileName);
            var basePath = "~/Content/Users/" + model.AspNetUserID + "/Profile/Images/";
            var path = Path.Combine(HttpContext.Current.Server.MapPath(basePath), fileName);
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Users/" + model.AspNetUserID + "/Profile/Images/"));
            model.ProfilePhoto.SaveAs(path);

            supplier.SupplierID = Guid.NewGuid();
            supplier.AspNetUserID = model.AspNetUserID;
            supplier.SupplierFirstName = model.FirstName;
            supplier.SupplierLastName = model.LastName;
            supplier.ProfilePhoto = basePath + fileName;
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

        // SHOW: All Suppliers
        public List<SupplierListViewModel> SupplierList()
        {
            ISupplierRepository supplierRepo = new SupplierRepository();
            ICountryRepository countryRepo = new CountryRepository();
            IStateRepository stateRepo = new StateRepository();
            ICityRepository cityRepo = new CityRepository();

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

        // DELETE: Supplier
        public void DeleteSupplier(string UserID)
        {
            ISupplierRepository repository = new SupplierRepository();
            repository.Delete(UserID);
        }


        // ADD: Supplier Busienss Information
        public void AddBusinessInfo(AddSupplierBusinessInfoVM viewModel)
        {
            ISupplierBusinessInfo repository = new SupplierBusinessInfo();
            SupplierBusinessInformation businessInfo = new SupplierBusinessInformation();

            businessInfo.BusinessInfoID = Guid.NewGuid();
            businessInfo.SupplierID = viewModel.SupplierID;
            businessInfo.CompanyName = viewModel.CompanyName;
            businessInfo.Logo = viewModel.Logo;
            //businessInfo.Country = viewModel.Country;
            //businessInfo.State = viewModel.State;
            //businessInfo.City = viewModel.City;
            businessInfo.Phone = viewModel.Mobile;
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
    }
}
