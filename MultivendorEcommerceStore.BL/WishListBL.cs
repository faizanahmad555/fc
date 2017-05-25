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
    public class WishListBL
    {
        public void AddProductstoWishList(Guid? CustomerId, Guid? productId)
        {
            var wishListRepo = new WishListRepository();
            var wishList = new WishList();

            wishList.WishListID = Guid.NewGuid();
            wishList.ProductID = productId;
            wishList.CustomerID = CustomerId;

            wishListRepo.Create(wishList);
        }

        // SHOW: Current Customer Products WishList(For Front Side)
        public IEnumerable<DisplayWishListViewModel> GetWishListByCustomerID(Guid customerId)
        {
            var wishListRepo = new WishListRepository();
            var wishlist = wishListRepo.Retrive().Where(w => w.CustomerID == customerId).ToList();

            return wishlist.Select(s => new DisplayWishListViewModel
            {
                WishListID = s.WishListID,
                CustomerID = s.CustomerID,
                ProductID = s.ProductID,
                Product = GetProductByID(s.ProductID),
            });
        }

        public DisplayProductViewModel GetProductByID(Guid? productID)
        {
            var productRepo = new ProductRepository();
            DisplayProductViewModel viewmodel = new DisplayProductViewModel();

            var product = productRepo.GetById(productID);
            viewmodel.ProductName = product.ProductName;
            viewmodel.ProductImage1 = product.ProductPicture;
            viewmodel.ProductDescription = product.ProductDescription;
            viewmodel.Size = product.UnitSize;
            viewmodel.Price = product.UnitPrice;

            return viewmodel;
        }





    }
}
