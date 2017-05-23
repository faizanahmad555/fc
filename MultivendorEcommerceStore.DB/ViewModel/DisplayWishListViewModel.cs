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

        public Guid? ProductID { get; set; }

        public string ProductName { get; set; }

        public string ProductImage1 { get; set; }

        public int? Price { get; set; }

    }
}

