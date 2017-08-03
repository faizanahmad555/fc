using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;
using MultivendorEcommerceStore.DB.ViewModel;
using MultivendorEcommerceStore.Repository;
using System.Web;
using System.IO;

namespace MultivendorEcommerceStore.BL
{
    public class CategoryBL
    {
        // ADD: Category
        public void AddCategory(AddCategoryViewModel model)
        {
            ICategoryRepository categoryRepo = new CategoryRepository();
            Category category = new Category();

            var fileName = Path.GetFileNameWithoutExtension(model.Picture.FileName);
            fileName += DateTime.Now.Ticks + Path.GetExtension(model.Picture.FileName);
            var basePath = "/Content/Admin/Category/" + model.CategoryName + "/Images/";
            var path = Path.Combine(HttpContext.Current.Server.MapPath(basePath), fileName);
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Content/Admin/Category/" + model.CategoryName + "/Images/"));
            model.Picture.SaveAs(path);

            category.CategoryID = Guid.NewGuid();
            category.CategoryName = model.CategoryName;
            //category.Description = model.Description;
            category.Picture = basePath + fileName;
            category.DisplayOrder = model.DisplayOrder;
            category.CreatedOn = DateTime.Now;

            categoryRepo.Create(category);
        }


        // ADD: SubCategory For DisplayOrder 1 And 2
        public void AddExistingCategory(AddExistingCategoryViewModel model)
        {
            ISubCategoryRepository subCategoryRepo = new SubCategoryRepository();
            SubCategory subCategory = new SubCategory();

            subCategory.SubCategoryID = Guid.NewGuid();
            subCategory.CategoryID = model.CategoryID;
            subCategory.SubCategoryName = model.SubCategoryName;
            subCategory.CreatedOn = DateTime.Now;
            subCategoryRepo.Create(subCategory);
        }


        // ADD: SubCategoryItem For DisplayOrder 1
        public void AddExistingCategoryItems(AddExistingCategoryItemViewModel model)
        {
            ISubCategoryItemRepository subCategoryItemRepo = new SubCategoryItemRepository();
            SubCategoryItem subCategoryItem = new SubCategoryItem();

            subCategoryItem.SubCategoryItemID = Guid.NewGuid();
            subCategoryItem.SubCategoryID = model.SubCategoryID;
            subCategoryItem.SubCategoryName = model.SubCategoryItem;
            subCategoryItem.CreatedOn = DateTime.Now;
            subCategoryItemRepo.Create(subCategoryItem);
        }




        public IEnumerable<Category> GetCategoriess()
        {
            ICategoryRepository categoryRepo = new CategoryRepository();
            return categoryRepo.Retrive().Where(c => c.DisplayOrder == 1);
        }


        // SHOW: All Categories(For Testing)
        public IEnumerable<Category> CategoryLists()
        {
            ICategoryRepository categoryRepo = new CategoryRepository();
            IEnumerable<Category> categoryList = categoryRepo.Retrive();
            return categoryList;
        }



        // SHOW: All Categories(For Front End)
        public List<CategoryListViewModel> CategoryList()
        {
            ICategoryRepository categoryRepo = new CategoryRepository();
            List<CategoryListViewModel> viewModelList = new List<CategoryListViewModel>();

            var MainCat = categoryRepo.Retrive().OrderBy(s=>s.CategoryName);

            foreach (var category in MainCat)
            {
                CategoryListViewModel viewModel = new CategoryListViewModel();

                CategoryEntity cat = new CategoryEntity();

                cat.CategoryID = category.CategoryID;
                cat.CategoryName = category.CategoryName;
                cat.CategoryPicture = category.Picture;
                cat.DisplayOrder = category.DisplayOrder;

                foreach (var subcategory in category.SubCategories)
                {
                    SubCategoryEntity subcat = new SubCategoryEntity();
                    subcat.SubCategoryID = subcategory.SubCategoryID;
                    subcat.SubCategoryName = subcategory.SubCategoryName;
                    cat.listSubCategoryEntity.Add(subcat);

                    foreach (var subcategoryitem in subcategory.SubCategoryItems)
                    {
                        SubCategoryItemEntity subcatItem = new SubCategoryItemEntity();
                        subcatItem.SubCategoryItemID = subcategoryitem.SubCategoryItemID;
                        subcatItem.SubCategoryItemName = subcategoryitem.SubCategoryName;
                        subcat.listSubCategoryItemEntity.Add(subcatItem);
                    }
                }
                viewModel.listCategoryEntity.Add(cat);

                viewModelList.Add(viewModel);
            }
            return viewModelList;
        }





        // GET: Category(For Category DropDown)
        public IEnumerable<Category> GetCategories()
        {
            ICategoryRepository categoryRepo = new CategoryRepository();
            return categoryRepo.Retrive();
        }


        // GET: SubCategories By CategoryID(For SubCategory DropDown)
        public IEnumerable<SubCategory> GetSubCategoriesByCategoryID(Guid ID)
        {
            ISubCategoryRepository subCategoryRepo = new SubCategoryRepository();
            return subCategoryRepo.Retrive().Where(c => c.CategoryID == ID).ToList();
        }


        // GET: SubCategoryItems By SubCategoryID(For SubCategoryItems DropDown)
        public IEnumerable<SubCategoryItem> GetSubCategoryItemsBySubCategoryID(Guid ID)
        {
            ISubCategoryItemRepository subCategoryItemRepo = new SubCategoryItemRepository();
            return subCategoryItemRepo.Retrive().Where(c => c.SubCategoryID == ID).ToList();
        }



















        public String CreateCategory(AddCategoryViewModel CategoryViewModel, HttpPostedFileBase LogoPath)
        {
            ICategoryRepository categoryRepo = new CategoryRepository();
            String path = "";
            if (LogoPath != null)
            {
                //validate image
                if (ValidateImage(LogoPath))
                {
                    //Save image
                    path = SaveImage(LogoPath);
                }
            }
            Category category = new Category();
            category.CategoryID = Guid.NewGuid();
            //category.CategoryName = CategoryViewModel.Name;
            category.Picture = Path.GetFileName(path);
            category.CreatedOn = DateTime.Now;
            categoryRepo.Create(category);
            return "Category Created";
        }

        private bool ValidateImage(HttpPostedFileBase file)
        {
            //if (file != null)
            //{
            String format = Path.GetExtension(file.FileName).ToString();
            String[] allowedFormat = new String[4] { ".jpg", ".png", ".gif", ".bmp" };
            int maxSize = 1048576;
            int minSize = 30584;

            if (file.ContentLength < maxSize && file.ContentLength > minSize)
            {
                if (allowedFormat.Contains(format))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
            //}
            //else
            //    return false;
        }

        private String SaveImage(HttpPostedFileBase file)
        {
            String extension = Path.GetExtension(file.FileName).ToString();
            String path = HttpContext.Current.Server.MapPath("~/Content/Category/logo/");
            String name = "";

            //Generating unique name for image
            string guid = Guid.NewGuid().ToString();
            name = guid + extension;
            //Generating Path to Save Image at Server
            String fullPath = Path.Combine(path, name);
            //Checking if directory exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //Saving Image
            file.SaveAs(fullPath);

            return fullPath;
        }
    }
}
