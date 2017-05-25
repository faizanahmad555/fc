using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class AdminLayoutViewModel
    {
        public int UserCount { get; set; }
        public int SupplierCount { get; set; }
        public int CustomerCount { get; set; }
        public int ProductCount { get; set; }
        public int OrderCount { get; set; }
    }
}
