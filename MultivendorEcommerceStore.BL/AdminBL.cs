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
            supplier.CityID = model.City;
            supplier.CNIC = model.CNIC;
            supplier.PostalCode = model.PostalCode;
            supplier.CreatedOn = DateTime.Now;

            repository.Create(supplier);
        }

        // GET: Supplier
        public IEnumerable<Supplier> SupplierList()
        {
            ISupplierRepository repository = new SupplierRepository();
            IEnumerable<Supplier> supplierList = repository.Retrive();
            return supplierList;
        }

        // DELETE: Supplier
        public void DeleteSupplier(Guid id)
        {
            ISupplierRepository repository = new SupplierRepository();
            repository.Delete(id);
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


        // Add Category
        public void AddCategory(AddCategoryViewModel model)
        {
            ICategoryRepository categoryRepo = new CategoryRepository();
            Category category = new Category();

            var fileName = Path.GetFileNameWithoutExtension(model.Picture.FileName);
            fileName += DateTime.Now.Ticks + Path.GetExtension(model.Picture.FileName);
            var basePath = "~/Content/Admin/Category/" + model.CategoryName + "/Images/";
            var path = Path.Combine(HttpContext.Current.Server.MapPath(basePath), fileName);
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Admin/Category/" + model.CategoryName + "/Images/"));
            model.Picture.SaveAs(path);

            category.CategoryID = Guid.NewGuid();
            category.CategoryName = model.CategoryName;
            category.Description = model.Description;
            category.Picture = basePath + fileName;
            category.DisplayOrder = model.DisplayOrder;
            category.CreatedOn = DateTime.Now;
            categoryRepo.Create(category);

            ISubCategoryRepository subCategoryRepo = new SubCategoryRepository();
            SubCategory subCategory = new SubCategory();

            subCategory.SubCategoryID = Guid.NewGuid();
            subCategory.CategoryID = category.CategoryID;
            subCategory.SubCategoryName = model.SubCategoryName;

            subCategoryRepo.Create(subCategory);


            ISubCategoryItemRepository subCategoryItemRepo = new SubCategoryItemRepository();
            SubCategoryItem subCategoryItem = new SubCategoryItem();

            subCategoryItem.SubCategoryItemID = Guid.NewGuid();
            subCategoryItem.SubCategoryID = subCategory.SubCategoryID;
            subCategoryItem.SubCategoryName = model.SubCategoryItem;
            subCategoryItem.CreatedOn = DateTime.Now;

            subCategoryItemRepo.Create(subCategoryItem);
        }

    }
}
