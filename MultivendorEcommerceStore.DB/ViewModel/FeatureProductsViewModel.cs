using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class FeatureProductsViewModel
    {
        public List<CategoryEntity> CategoryListVM = new List<CategoryEntity>();

        public List<ProductListViewModel> ProductListVM = new List<ProductListViewModel>();
    }
}
