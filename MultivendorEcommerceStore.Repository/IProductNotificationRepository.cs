using MultivendorEcommerceStore.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.Repository
{
    public interface IProductNotificationRepository
    {
        
        List<ProductNotification> Get();

        void ChangeIsSeenByID(Guid ProductID);

        void Insert(ProductNotification entity);


    }
}
