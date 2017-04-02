using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.Repository
{
    public enum ProductStatus : int
    {
        Pending = 1,
        Approved = 2,
        Reject = 3

    }
    public enum ProductActive : int
    {
        Yes = 1,
        No = 2
    }
}
