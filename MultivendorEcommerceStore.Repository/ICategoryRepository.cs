using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public interface ICategoryRepository
    {
        void Create(Category Entity);
        void Update(Category Entity);
        void Delete(Guid id);
        Category GetById(Guid id);
        IEnumerable<Category> Retrive();
    }
}
