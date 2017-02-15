using MultivendorEcommerceStore.DB.Model;
using MultivendorEcommerceStore.DB.ViewModel;
using MultivendorEcommerceStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.BL
{
    public class SupplierBL
    {
        public void AddProduct(AddProductViewModel model)
        {
            IProductRepository repositroy = new ProductRepository();
            Product product = new Product();

            product.ProductID = Guid.NewGuid();
            product.CategoryID = model.CategoryID;
            product.SubCategoryID = model.SubCategoryID;

            //Supplier supplier = new Supplier();
            //product.SupplierID = supplier.SupplierID;

            product.ProductName = model.ProductName;
            product.ProductDescription = model.ProductDescription;
            product.Quantity = model.Quantity;
            product.UnitSize = model.Size;
            product.CreatedOn = DateTime.Now;

            repositroy.Create(product);
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


