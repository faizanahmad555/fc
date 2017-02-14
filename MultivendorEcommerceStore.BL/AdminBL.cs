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
        public void AddSupplier(AddSupplierViewModel model) //, HttpPostedFileBase ProfilePhoto)
        {
            //String path = "";
            //if (ProfilePhoto != null)
            //{
            //    //validate image
            //    if (ValidateImage(ProfilePhoto))
            //    {
            //        //Save image
            //        path = SaveImage(ProfilePhoto);
            //    }
            //}

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
            //supplier.CityID = model.City;
            supplier.CNIC = model.CNIC;
            supplier.PostalCode = model.PostalCode;
            supplier.CreatedOn = DateTime.Now;

            repository.Create(supplier);

            
            //ISupplierRepository repository = new SupplierRepository();
            //Supplier supplier = new Supplier();
            //supplier.SupplierID = Guid.NewGuid();
            //supplier.AspNetUserID = model.AspNetUserID;
            //supplier.SupplierFirstName = model.FirstName;
            //supplier.SupplierLastName = model.LastName;
            //supplier.ProfilePhoto = model.ProfilePhoto;
            //supplier.Email = model.Email;
            //supplier.Phone = model.MobileNumber;
            //supplier.Address = model.Address;
            //supplier.CountryID = model.Country;
            //supplier.StateID = model.State;
            ///*supplier.CityID = model.City*/;
            //supplier.PostalCode = model.PostalCode;
            //supplier.CNIC = model.CNIC;
            //supplier.CreatedOn = DateTime.Now;

            //repository.Create(supplier);
        }

        public IEnumerable<Supplier> SupplierList()
        {
            ISupplierRepository repository = new SupplierRepository();
            IEnumerable<Supplier> supplierList = repository.Retrive();
            return supplierList;
        }

        public void DeleteSupplier(Guid id)
        {
            ISupplierRepository repository = new SupplierRepository();
            repository.Delete(id);
        }


        //String path = "";
        //if (ProfilePhoto != null)
        //{
        //    //validate image
        //    if (ValidateImage(ProfilePhoto))
        //    {
        //        //Save image
        //        path = SaveImage(ProfilePhoto);
        //    }
        //}
        // }


        //private bool ValidateImage(HttpPostedFileBase file)
        //{
        //    //if (file != null)
        //    //{
        //    String format = Path.GetExtension(file.FileName).ToString();
        //    String[] allowedFormat = new String[4] { ".jpg", ".png", ".gif", ".bmp" };
        //    int maxSize = 1048576;
        //    int minSize = 30584;

        //    if (file.ContentLength < maxSize && file.ContentLength > minSize)
        //    {
        //        if (allowedFormat.Contains(format))
        //        {
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    else
        //        return false;
        //    //}
        //    //else
        //    //    return false;
        //}

        //private String SaveImage(HttpPostedFileBase file)
        //{
        //    String extension = Path.GetExtension(file.FileName).ToString();
        //    String path = HttpContext.Current.Server.MapPath("~/Content/Supplier/Profile/");
        //    String name = "";

        //    //Generating unique name for image
        //    string guid = Guid.NewGuid().ToString();
        //    name = guid + extension;
        //    //Generating Path to Save Image at Server
        //    String fullPath = Path.Combine(path, name);
        //    //Checking if directory exist
        //    if (!Directory.Exists(path))
        //        Directory.CreateDirectory(path);
        //    //Saving Image
        //    file.SaveAs(fullPath);

        //    return fullPath;
        //}






        // GET: Countries
        public IEnumerable<Country> GetCountries()
        {
            ICountryRepository countryRepo = new CountryRepository();
            return countryRepo.Get();
        }

        // GET: States
        public IEnumerable<State> GetStatesByCountryID(int ID)
        {
            IStateRepository stateRepo = new StateRepository();
            return stateRepo.Get().Where(s => s.CountryID == ID).ToList();
        }

        // GET: Cities
        public IEnumerable<City> GetCitiesByStateID(int ID)
        {
            ICityRepository cityRepo = new CityRepository();
            return cityRepo.Get().Where(c => c.StateID == ID).ToList();
        }

    }
}
