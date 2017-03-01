using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.Repository;
using MultivendorEcommerceStore.DB.Model;
using System.Web;

namespace MultivendorEcommerceStore.BL
{
    public class HomeBL
    {
        public IEnumerable<Category> CategoryList()
        {
            ICategoryRepository categoryRepo = new CategoryRepository();
            IEnumerable<Category> categoryList = categoryRepo.Retrive().Where(s=> )
            return categoryList;
        }

    }
}