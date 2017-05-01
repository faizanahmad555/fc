using MultivendorEcommerceStore.DB.ViewModel;
using MultivendorEcommerceStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.BL
{
    public class CartBL
    {
        public DisplayProductViewModel GetProductByID(Guid ProductID)
        {
            IProductRepository productRepo = new ProductRepository();
            DisplayProductViewModel viewModel = new DisplayProductViewModel();

            var product = productRepo.GetById(ProductID);

            viewModel.ProductID = product.ProductID;
            viewModel.ProductName = product.ProductName;
            viewModel.ProductDescription = product.ProductDescription;
            viewModel.ProductImage1 = product.ProductPicture;
            viewModel.Price = product.UnitPrice;
            viewModel.Quantity = product.Quantity;
            viewModel.Size = product.UnitSize;

            return viewModel;
        }
    }
}
