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
        private ICategoryRepository repository;

        public CategoryBL()
        {
            repository = new CategoryRepository();
        }

        public IEnumerable<Category> CategoryList()
        {
            IEnumerable<Category> categoryList = repository.Retrive();
            return categoryList;
        }

        public String CreateCategory(AddCategoryViewModel CategoryViewModel, HttpPostedFileBase LogoPath)
        {
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
            repository.Create(category);
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
