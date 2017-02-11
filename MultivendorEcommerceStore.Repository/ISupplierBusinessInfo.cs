using MultivendorEcommerceStore.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.Repository
{
    public interface ISupplierBusinessInfo
    {
        void Create(SupplierBusinessInformation entity);
        IEnumerable<SupplierBusinessInformation> Retrive();
        void Update(SupplierBusinessInformation entity);
        void Delete(Guid id);
        SupplierBusinessInformation GetById(Guid id);
    }
}
