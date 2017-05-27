using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class AddOrderDetailViewModel
    {
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public int? UnitPrice { get; set; }
        public int Quantity { get; set; }     
    }
}
