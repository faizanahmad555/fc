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
    public class SupplierProfileBL
    {
        // GET: Supplier Profile
        public SupplierProfileViewModel GetProfileByUserIdentity(string userID)
        {
            SupplierRepository repo = new SupplierRepository();
            ICountryRepository countryRepo = new CountryRepository();
            IStateRepository stateRepo = new StateRepository();
            ICityRepository cityRepo = new CityRepository();

            SupplierProfileViewModel viewModel = new SupplierProfileViewModel();

            var yourProfile = repo.Retrive().Where(s => s.AspNetUserID == userID).FirstOrDefault();
            if (yourProfile != null)
            {
                //var city = cityRepo.Get().Where(s => s.CityID == yourProfile.CityID).FirstOrDefault();
                //var state = stateRepo.Get().Where(s => s.StateID == yourProfile.StateID).FirstOrDefault();
                //var country = countryRepo.Get().Where(s => s.CountryID == state.CountryID).FirstOrDefault();

                viewModel.UserID = userID;
                viewModel.SupplierID = yourProfile.SupplierID;
                viewModel.FirstName = yourProfile.SupplierFirstName;
                viewModel.LastName = yourProfile.SupplierLastName;
                viewModel.Email = yourProfile.Email;
                viewModel.Address = yourProfile.Address;
                viewModel.PhoneNo = yourProfile.Phone;
                viewModel.ProfilePhoto = yourProfile.ProfilePhoto;
                //viewModel.City = city.Name;
                //viewModel.State = state.Name;
                //viewModel.Country = country.Name;
            }
            return viewModel;
        }


        // GET EXISTING : SupplierProfile For Edit
        public EditSupplierViewModel EditSupplierProfile(string UserID, Guid supplierID)
        {
            ISupplierRepository supplierRepo = new SupplierRepository();

            var supplierProfile = supplierRepo.Retrive().Where(s => s.AspNetUserID == UserID && s.SupplierID == supplierID).FirstOrDefault();

            EditSupplierViewModel viewModel = new EditSupplierViewModel();
            viewModel.AspNetUserID = UserID;
            viewModel.SupplierID = supplierID;
            viewModel.FirstName = supplierProfile.SupplierFirstName;
            viewModel.LastName = supplierProfile.SupplierLastName;
            viewModel.ProfilePhotoPath = supplierProfile.ProfilePhoto;
            viewModel.MobileNumber = supplierProfile.Phone;
            viewModel.CNIC = supplierProfile.CNIC;
            viewModel.Address = supplierProfile.Address;
            viewModel.PostalCode = supplierProfile.PostalCode;
            return viewModel;
        }

        // ADD EXISTING: New SupplierProfile Info
        public void AddEditedSupplierProfile(EditSupplierViewModel viewModel)
        {
            ISupplierRepository supplierRepo = new SupplierRepository();
            Supplier supplier = new Supplier();

            if (viewModel.ProfilePhoto != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(viewModel.ProfilePhoto.FileName);
                fileName += DateTime.Now.Ticks + Path.GetExtension(viewModel.ProfilePhoto.FileName);
                var basePath = "~/Content/Users/" + viewModel.AspNetUserID + "/Profile/Images/";
                var path = Path.Combine(HttpContext.Current.Server.MapPath(basePath), fileName);
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Users/" + viewModel.AspNetUserID + "/Profile/Images/"));
                viewModel.ProfilePhoto.SaveAs(path);

                supplier.ProfilePhoto = basePath + fileName;
            }
            else
            {
                supplier.ProfilePhoto = viewModel.ProfilePhotoPath;
            }

            supplier.AspNetUserID = viewModel.AspNetUserID;
            supplier.SupplierID = viewModel.SupplierID;
            supplier.SupplierFirstName = viewModel.FirstName;
            supplier.SupplierLastName = viewModel.LastName;
            supplier.Phone = viewModel.MobileNumber;
            supplier.CNIC = viewModel.CNIC;
            supplier.Address = viewModel.Address;
            supplier.PostalCode = viewModel.PostalCode;

            supplierRepo.Update(supplier);
        }





















        //public List<SupplierProfileViewModel> GetSuppliers()
        //{
        //    SupplierRepository supplierRepo = new SupplierRepository();
        //    var supplierTBL = supplierRepo.Retrive();
        //    return (suppliers(supplierTBL));
        //}



        //private List<SupplierProfileViewModel> suppliers(IEnumerable<DB.Model.Supplier> supplierTBL)
        //{
        //    ICountryRepository countryRepo = new CountryRepository();
        //    IStateRepository stateRepo = new StateRepository();
        //    ICityRepository cityRepo = new CityRepository();

        //    List<SupplierProfileViewModel> viewModels = new List<SupplierProfileViewModel>();
        //    foreach (var supplier_tbl in supplierTBL)
        //    {
        //        var city = cityRepo.Get().Where(s => s.CityID == supplier_tbl.CityID).FirstOrDefault();
        //        var state = stateRepo.Get().Where(s => s.StateID == city.StateID).FirstOrDefault();
        //        var country = countryRepo.Get().Where(s => s.CountryID == state.CountryID).FirstOrDefault();

        //        SupplierProfileViewModel supplierProfileViewModel = new SupplierProfileViewModel();
        //        supplierProfileViewModel.FirstName = supplier_tbl.SupplierFirstName;
        //        supplierProfileViewModel.LastName = supplier_tbl.SupplierLastName;
        //        supplierProfileViewModel.Email = supplier_tbl.Email;
        //        supplierProfileViewModel.Address = supplier_tbl.Address;
        //        //supplierProfileViewModel.Country = country.Name;
        //        //supplierProfileViewModel.State = state.Name;
        //        //supplierProfileViewModel.City = city.Name;

        //        viewModels.Add(supplierProfileViewModel);
        //    }
        //    return viewModels;
        //}
    }
}
