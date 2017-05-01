using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class CartViewModel
    {
        public Guid ProductID { get; set; }

        public int Quantity { get; set; }

        public DisplayProductViewModel ProductDetail;
    }
}
