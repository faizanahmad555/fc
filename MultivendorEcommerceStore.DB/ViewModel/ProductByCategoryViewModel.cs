using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class ProductByCategoryViewModel
    {
        public IEnumerable<ProductListViewModel> ProductsList { get; set; }
        public Pager Pager { get; set; }
    }
}
