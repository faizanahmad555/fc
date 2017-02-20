using MultivendorEcommerceStore.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.Repository
{
    public interface ISubCategoryItemRepository
    {
        void Create(SubCategoryItem Entity);
        IEnumerable<SubCategoryItem> Retrive();
        SubCategoryItem GetByID(Guid id);
    }
}
