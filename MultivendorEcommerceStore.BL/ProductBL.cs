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
    public class ProductBL
    {
        // ADD: Product
        public void AddProduct(AddProductViewModel model, Guid SupplierID)
        {
            MultivendorEcommerceStoreEntities _db = new MultivendorEcommerceStoreEntities();
            IProductRepository productRepo = new ProductRepository();
            Product product = new Product();

            var fileName = Path.GetFileNameWithoutExtension(model.ProductImage1.FileName);
            fileName += DateTime.Now.Ticks + Path.GetExtension(model.ProductImage1.FileName);
            var basePath = "~/Content/Users/Suppliers/" + SupplierID + "/Products/Images/";
            var path = Path.Combine(HttpContext.Current.Server.MapPath(basePath), fileName);
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Users/Suppliers/" + SupplierID + "/Products/Images/"));
            model.ProductImage1.SaveAs(path);

            product.ProductID = Guid.NewGuid();
            product.CategoryID = model.CategoryID;
            product.SubCategoryID = model.SubCategoryID;
            product.SubCategoryItemID = model.SubCategoryItemID;

            product.SupplierID = SupplierID;
            product.FeatureProduct = model.FeatureProduct;
            product.ProductName = model.ProductName;
            product.ProductDescription = model.ProductDescription;
            //product.ProductLongDescription = model.ProductLongDescription;
            product.ProductPicture = basePath + fileName;
            product.UnitPrice = model.Price;
            product.Quantity = model.Quantity;
            product.UnitSize = model.Size;
            product.Status = (int)ProductStatus.Pending;
            product.IsActive = (int)ProductActive.Yes;
            product.CreatedOn = DateTime.Now;


            var productID = productRepo.InsertAndGetID(product);

            var productNE = new ProductNotification();
            var productNR = new ProductNotificationRepository();

            productNE.ProductID = productID;
            productNE.CreatedOn = DateTime.Now;
            productNE.Description = "New Product has been added";
            productNE.URL = "/Notification/ProductDetail?productID=" + productID;
            productNE.IsSeen = false;

            productNR.Insert(productNE);

        }


        // SHOW: ALL Supplier Products(For Admin Side)
        public List<ProductListViewModel> ProductList()
        {
            IProductRepository productRepo = new ProductRepository();
            ICategoryRepository categoryRepo = new CategoryRepository();
            ISubCategoryRepository subCategoryRepo = new SubCategoryRepository();

            List<ProductListViewModel> viewModelList = new List<ProductListViewModel>();

            var productTbl = productRepo.Retrive().ToList();

            foreach (var product in productTbl)
            {
                var category = categoryRepo.Retrive().Where(c => c.CategoryID == product.CategoryID).FirstOrDefault();
                var subCategory = subCategoryRepo.Retrive().Where(c => c.SubCategoryID == product.SubCategoryID).FirstOrDefault();

                ProductListViewModel viewModel = new ProductListViewModel();

                viewModel.SupplierID = product.SupplierID;
                viewModel.ProductID = product.ProductID;
                viewModel.FeatureProduct = product.FeatureProduct;
                viewModel.CategoryName = category.CategoryName;
                viewModel.SubCategoryName = subCategory.SubCategoryName;
                viewModel.ProductName = product.ProductName;
                viewModel.ProductDescription = product.ProductDescription;
                viewModel.ProductImage1 = product.ProductPicture;
                viewModel.Price = product.UnitPrice;
                viewModel.Quantity = product.Quantity;
                viewModel.Size = product.UnitSize;
                viewModel.Status = Enum.GetName(typeof(ProductStatus), product.Status);
                viewModel.Active = Enum.GetName(typeof(ProductActive), product.IsActive);
                viewModel.CreatedOn = product.CreatedOn;
                viewModelList.Add(viewModel);
            }
            return viewModelList;
        }


        // SHOW: Current Supplier Products(For Supplier Side)
        public List<ProductListViewModel> GetProductsBySupplierID(Guid SupplierID)
        {
            IProductRepository productRepo = new ProductRepository();
            ICategoryRepository categoryRepo = new CategoryRepository();
            ISubCategoryRepository subCategoryRepo = new SubCategoryRepository();

            List<ProductListViewModel> viewModelList = new List<ProductListViewModel>();

            var productTbl = productRepo.Retrive().Where(p => p.SupplierID == SupplierID).ToList();

            foreach (var product in productTbl)
            {
                var category = categoryRepo.Retrive().Where(c => c.CategoryID == product.CategoryID).FirstOrDefault();
                var subCategory = subCategoryRepo.Retrive().Where(c => c.SubCategoryID == product.SubCategoryID).FirstOrDefault();

                ProductListViewModel viewModel = new ProductListViewModel();

                viewModel.SupplierID = product.SupplierID;
                viewModel.ProductID = product.ProductID;
                viewModel.CategoryName = category.CategoryName;
                viewModel.SubCategoryName = subCategory.SubCategoryName;
                viewModel.ProductName = product.ProductName;
                viewModel.ProductDescription = product.ProductDescription;
                viewModel.ProductImage1 = product.ProductPicture;
                viewModel.Price = product.UnitPrice;
                viewModel.Quantity = product.Quantity;
                viewModel.Size = product.UnitSize;
                viewModel.Status = Enum.GetName(typeof(ProductStatus), product.Status);
                viewModel.Active = Enum.GetName(typeof(ProductActive), product.IsActive);
                viewModel.CreatedOn = product.CreatedOn;
                viewModelList.Add(viewModel);
            }
            return viewModelList;
        }


        // EDIT: EXISTING Product For Edit(For Admin & Supplier Side)
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

        // EDIT: Save Edited Product INFO(For Admin & Supplier Side)
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


        // CHANGE: Product Active/InActive State
        public int? ChangeProductStatus(Guid ProductID, int IsActive)
        {
            IProductRepository productRepo = new ProductRepository();
            var productTbl = productRepo.Retrive().Where(p => p.ProductID == ProductID).FirstOrDefault();

            if (IsActive == 1)
            {
                IsActive = 0;
            }
            else if (IsActive == 0)
            {
                IsActive = 1;
            }
            productTbl.IsActive = IsActive;

            return productRepo.ChangeActiveStatus(productTbl);

        }

        
        // DELETE: Products of All Suppliers(For Admin Side)
        public void DeleteProduct(Guid ProductID)
        {
            IProductRepository productRepo = new ProductRepository();
            productRepo.Delete(ProductID);
        }




        // SHOW: ALL Products According to Categories(For Front End Side)
        public List<ProductListViewModel> ProductLists(Guid PId)
        {
            IProductRepository productRepo = new ProductRepository();
            ICategoryRepository categoryRepo = new CategoryRepository();
            ISubCategoryRepository subCategoryRepo = new SubCategoryRepository();
            ISubCategoryItemRepository subCategoryItemRepo = new SubCategoryItemRepository();

            List<ProductListViewModel> viewModelList = new List<ProductListViewModel>();

            var productTbl = productRepo.Retrive().Where(p => p.SubCategoryItemID == PId || p.SubCategoryID == PId).ToList();

            foreach (var product in productTbl)
            {
                var category = categoryRepo.Retrive().Where(c => c.CategoryID == product.CategoryID).FirstOrDefault();
                var subCategory = subCategoryRepo.Retrive().Where(c => c.SubCategoryID == product.SubCategoryID).FirstOrDefault();
                var subCategoryItem = subCategoryItemRepo.Retrive().Where(c => c.SubCategoryItemID == product.SubCategoryItemID).FirstOrDefault();

                ProductListViewModel viewModel = new ProductListViewModel();

                viewModel.SupplierID = product.SupplierID;
                viewModel.ProductID = product.ProductID;
                viewModel.CategoryName = category.CategoryName;
                viewModel.SubCategoryName = subCategory.SubCategoryName;
                //viewModel.SubCategoryItemName = subCategoryItem.SubCategoryName;
                viewModel.ProductName = product.ProductName;
                viewModel.ProductDescription = product.ProductDescription;
                viewModel.ProductImage1 = product.ProductPicture;
                viewModel.Price = product.UnitPrice;
                viewModel.Quantity = product.Quantity;
                viewModel.Size = product.UnitSize;
                viewModel.Status = Enum.GetName(typeof(ProductStatus), product.Status);
                viewModel.Active = Enum.GetName(typeof(ProductActive), product.IsActive);
                viewModel.CreatedOn = product.CreatedOn;
                viewModelList.Add(viewModel);
            }
            return viewModelList;
        }

        
        // SHOW: ALL Feature Products(For Front End Side)
        public List<FeatureProductsViewModel> FeatureProductList()
        {
            IProductRepository productRepo = new ProductRepository();
            ICategoryRepository categoryRepo = new CategoryRepository();
            ISubCategoryRepository subCategoryRepo = new SubCategoryRepository();

            List<FeatureProductsViewModel> viewModelList = new List<FeatureProductsViewModel>();

            var productTbl = productRepo.Retrive().ToList();
            var categoryTbl = categoryRepo.Retrive().ToList();

            foreach (var product in productTbl)
            {
                var category = categoryRepo.Retrive().Where(c => c.CategoryID == product.CategoryID).FirstOrDefault();
                var subCategory = subCategoryRepo.Retrive().Where(c => c.SubCategoryID == product.SubCategoryID).FirstOrDefault();

                FeatureProductsViewModel viewModel = new FeatureProductsViewModel();

                ProductListViewModel productVM = new ProductListViewModel();

                productVM.SupplierID = product.SupplierID;
                productVM.ProductID = product.ProductID;
                productVM.FeatureProduct = product.FeatureProduct;
                productVM.CategoryName = category.CategoryName;
                productVM.SubCategoryName = subCategory.SubCategoryName;
                productVM.ProductName = product.ProductName;
                productVM.ProductDescription = product.ProductDescription;
                productVM.ProductImage1 = product.ProductPicture;
                productVM.Price = product.UnitPrice;
                productVM.Quantity = product.Quantity;
                productVM.Size = product.UnitSize;
                productVM.Status = Enum.GetName(typeof(ProductStatus), product.Status);
                productVM.Active = Enum.GetName(typeof(ProductActive), product.IsActive);
                productVM.CreatedOn = product.CreatedOn;

                viewModel.ProductListVM.Add(productVM);
                viewModelList.Add(viewModel);

            }

            foreach (var category in categoryTbl)
            {
                FeatureProductsViewModel viewModel = new FeatureProductsViewModel();

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
                }
                viewModel.CategoryListVM.Add(cat);
                viewModelList.Add(viewModel);

            }

            return viewModelList;
        }


        // GET: Products Detial With Supplier Info(For Front End Side)
        public List<DisplayProductViewModel> GetProductDetails(Guid ProductID)
        {
            IProductRepository productRepo = new ProductRepository();
            ISupplierRepository supplierRepo = new SupplierRepository();
            ICategoryRepository categoryRepo = new CategoryRepository();
            ISubCategoryRepository subCategoryRepo = new SubCategoryRepository();
            ISubCategoryItemRepository subCategoryItemRepo = new SubCategoryItemRepository();

            List<DisplayProductViewModel> viewModelList = new List<DisplayProductViewModel>();

            var productDetail = productRepo.Retrive().Where(s => s.ProductID == ProductID).ToList();


            foreach (var product in productDetail)
            {
                var category = categoryRepo.Retrive().Where(c => c.CategoryID == product.CategoryID).FirstOrDefault();
                var subCategory = subCategoryRepo.Retrive().Where(c => c.SubCategoryID == product.SubCategoryID).FirstOrDefault();
                var subCategoryItem = subCategoryItemRepo.Retrive().Where(c => c.SubCategoryItemID == product.SubCategoryItemID).FirstOrDefault();


                DisplayProductViewModel viewModel = new DisplayProductViewModel();
                viewModel.CategoryName = category.CategoryName;
                viewModel.SubCategoryName = subCategory.SubCategoryName;
                //viewModel.SubCategoryItemName = subCategoryItem.SubCategoryName;

                viewModel.ProductID = product.ProductID;

                viewModel.ProductName = product.ProductName;
                viewModel.ProductDescription = product.ProductDescription;
                viewModel.ProductImage1 = product.ProductPicture;
                viewModel.Price = product.UnitPrice;
                viewModel.Quantity = product.Quantity;
                viewModel.Size = product.UnitSize;
                viewModelList.Add(viewModel);

                var supplierDetail = supplierRepo.Retrive().Where(s => s.SupplierID == product.SupplierID).ToList();

                foreach (var supplier in supplierDetail)
                {
                    viewModel.SupplierID = supplier.SupplierID;
                    viewModel.SupplierName = supplier.SupplierFirstName;

                    viewModelList.Add(viewModel);
                }

            }

            return viewModelList;
        }
     
    }
}
