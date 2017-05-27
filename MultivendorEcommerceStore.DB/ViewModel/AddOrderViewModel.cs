using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class AddOrderViewModel
    {
        public Guid? CustomerID { get; set; }
        public Guid PaymentID { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Total { get; set; }
        public decimal? Shipping { get; set; }
        public string PayPalReference { get; set; }
        public decimal? SubTotal { get; set; }
    }
}
