using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class DashboardStatisticsVM
    {
        public int UsersCount { get; set; }

        public int ProductsCount { get; set; }

        public int OrdersCount { get; set; }


        public dynamic OrdersChart { get; set; }

        public dynamic ProductsChart { get; set; }

        public dynamic SuppliersChart { get; set; }

        public dynamic CustomersChart { get; set; }





        public int SupplierProductsCount { get; set; }

        public int SupplierOrdersCount { get; set; }



        public dynamic SupplierProductsChart { get; set; }

        public dynamic SupplierOrdersChart { get; set; }







    }
}
