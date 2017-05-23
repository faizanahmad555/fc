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
        public void AddProductstoWishList(Guid CustomerId, Guid productId)
        {
            IWishListRepository wishListRepo = new WishListRepository();
            WishList wishList = new WishList();

            wishList.WishListID = Guid.NewGuid();
            wishList.ProductID = productId;
            wishList.CustomerID = CustomerId;

            wishListRepo.Create(wishList);
        }

        // SHOW: Current Customer Products WishList(For Front Side)
        public IEnumerable<DisplayWishListViewModel> GetWishListByCustomerID(Guid customerId)
        {
            IWishListRepository wishListRepo = new WishListRepository();

            var wishlist = wishListRepo.Retrive().Where(w => w.CustomerID == customerId).ToList();

            return wishlist.Select(s => new DisplayWishListViewModel
            {
                CustomerID = s.CustomerID,
                ProductID = s.ProductID,
                Price = s.Product.UnitPrice,
                ProductImage1 = s.Product.ProductPicture,
                ProductName = s.Product.ProductName,
            });

        }





    }
}
