using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class DisplayWishListViewModel
    {
        public Guid? CustomerID { get; set; }
        public Guid? WishListID { get; set; }
        public Guid? ProductID { get; set; }

        public DisplayProductViewModel Product { get; set; }

        public Pager Pager { get; set; }
    }

    public class WishListViewModel
    {
        public IEnumerable<DisplayWishListViewModel> WishList { get; set; }
        public Pager Pager { get; set; }
    }




}

