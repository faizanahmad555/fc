﻿using MultivendorEcommerceStore.DB.Model;
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
            IProductRepository repositroy = new ProductRepository();
            Product product = new Product();

            var fileName = Path.GetFileNameWithoutExtension(model.ProductImage1.FileName);
            fileName += DateTime.Now.Ticks + Path.GetExtension(model.ProductImage1.FileName);
            var basePath = "~/Content/Users/Suppliers/" + model.SupplierID + "/Products/Images/";
            var path = Path.Combine(HttpContext.Current.Server.MapPath(basePath), fileName);
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Users/Suppliers/" + model.SupplierID + "/Products/Images/"));
            model.ProductImage1.SaveAs(path);

            product.ProductID = Guid.NewGuid();
            product.CategoryID = model.CategoryID;
            product.SubCategoryID = model.SubCategoryID;

            product.SupplierID = SupplierID;
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


        // GET: Current Supplier Products(For Supplier Side)
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
    }
}
