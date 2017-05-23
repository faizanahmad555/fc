﻿using MultivendorEcommerceStore.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.Repository
{
    public interface ICustomerNotificationRepository
    {
        List<CustomerNotification> Get();

        void ChangeIsSeenByID(Guid customerID);

        void Insert(CustomerNotification entity);
    }
}
