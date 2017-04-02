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
    public class SupplierBL
    {
        // ADD: Product
        public void AddProduct(AddProductViewModel model, string AspUserId)
        {
            MultivendorEcommerceStoreEntities _db = new MultivendorEcommerceStoreEntities();
            IProductRepository repositroy = new ProductRepository();
            Product product = new Product();

            model.SupplierID = _db.Suppliers.Where(x => x.AspNetUserID == AspUserId).Select(x => x.SupplierID).FirstOrDefault();

            var fileName = Path.GetFileNameWithoutExtension(model.ProductImage1.FileName);
            fileName += DateTime.Now.Ticks + Path.GetExtension(model.ProductImage1.FileName);
            var basePath = "~/Content/Users/Suppliers/" + model.SupplierID + "/Products/Images/";
            var path = Path.Combine(HttpContext.Current.Server.MapPath(basePath), fileName);
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Users/Suppliers/" + model.SupplierID + "/Products/Images/"));
            model.ProductImage1.SaveAs(path);

            product.ProductID = Guid.NewGuid();
            product.CategoryID = model.CategoryID;
            product.SubCategoryID = model.SubCategoryID;

            product.SupplierID = model.SupplierID;
            product.ProductName = model.ProductName;
            product.ProductDescription = model.ProductDescription;
            product.ProductPicture = basePath + fileName;
            product.UnitPrice = model.Price;
            product.Quantity = model.Quantity;
            product.UnitSize = model.Size;
            product.Status = (int)ProductStatus.Pending;
            product.IsActive = (int)ProductActive.Yes;
            product.CreatedOn = DateTime.Now;

            repositroy.Create(product);
        }

        // SHOW: ALL Products
        public IEnumerable<Product> ProductList()
        {
            IProductRepository repository = new ProductRepository();
            IEnumerable<Product> productList = repository.Retrive();
            return productList;
        }


        // EDIT: EXISTING Product For Edit
        public EditProductViewModel EditSupplierProduct(Guid SupplierID, Guid ProductID)
        {
            IProductRepository productRepo = new ProductRepository();

            var supplierProduct = productRepo.Retrive().Where(s => s.ProductID == ProductID && s.SupplierID == SupplierID).FirstOrDefault();

            EditProductViewModel viewModel = new EditProductViewModel();
            viewModel.SupplierID = (Guid)supplierProduct.SupplierID;
            viewModel.ProductID = (Guid)supplierProduct.ProductID;
            viewModel.ProductName = supplierProduct.ProductName;
            viewModel.ProductDiscription = supplierProduct.ProductDescription;
            viewModel.ProductImagePath = supplierProduct.ProductPicture;
            viewModel.UnitPrice = supplierProduct.UnitPrice;
            viewModel.Quantity = supplierProduct.Quantity;
            viewModel.Size = supplierProduct.UnitSize;
            return viewModel;
        }

        // EDIT: Save Edited Product INFO
        public void AddEditedSupplierProduct(EditProductViewModel viewModel)
        {
            IProductRepository productRepo = new ProductRepository();
            Product product = new Product();

            if (viewModel.ProductImage1 != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(viewModel.ProductImage1.FileName);
                fileName += DateTime.Now.Ticks + Path.GetExtension(viewModel.ProductImage1.FileName);
                var basePath = "~/Content/Users//Suppliers/" + viewModel.SupplierID + "/Products/Images/";
                var path = Path.Combine(HttpContext.Current.Server.MapPath(basePath), fileName);
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Users/Suppliers/" + viewModel.SupplierID + "/Products/Images/"));
                viewModel.ProductImage1.SaveAs(path);

                product.ProductPicture = basePath + fileName;
            }
            else
            {
                product.ProductPicture = viewModel.ProductImagePath;
            }

            product.ProductID = viewModel.ProductID;
            product.SupplierID = viewModel.SupplierID;
            product.ProductName = viewModel.ProductName;
            product.ProductDescription = viewModel.ProductDiscription;
            product.UnitPrice = viewModel.UnitPrice;
            product.Quantity = viewModel.Quantity;
            product.UnitSize = viewModel.Size;

            productRepo.Update(product);
        }





        public IEnumerable<Category> GetCategories()
        {
            ICategoryRepository categoryRepo = new CategoryRepository();
            return categoryRepo.Retrive();
        }

        public IEnumerable<SubCategory> GetSubCategoriesByCategoryID(Guid ID)
        {
            ISubCategoryRepository subCategoryRepo = new SubCategoryRepository();
            return subCategoryRepo.Retrive().Where(c => c.CategoryID == ID).ToList();
        }

    }
}


