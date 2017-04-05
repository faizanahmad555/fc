using Microsoft.AspNet.Identity;
using MultivendorEcommerceStore.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MultivendorEcommerceStore.Utility
{
    public static class IdentityExtensions
    {
        // GET: Current AspNetUserId
        public static string GetCurrentUserID(this IIdentity identity)
        {
            if (identity.GetUserId() != "")
            {
                    return identity.GetUserId();
            }
            return "";
        }

        // GET: Current SupplierID
        public static Guid GetSupplierCurrentID(this IIdentity identity)
        {
            if (identity.GetUserId() != "")
            {
                var userProfile = new UserProfileBL().GetProfileByUserIdentity(identity.GetUserId());
                if (userProfile != null)
                {
                    return userProfile.SupplierID;
                }
                return Guid.Empty;
            }
            return Guid.Empty;
        }

        // GET: Current CustomerID
        public static Guid GetCustomerCurrentID(this IIdentity identity)
        {
            if (identity.GetUserId() != "")
            {
                var userProfile = new UserProfileBL().GetProfileByUserIdentity(identity.GetUserId());
                if (userProfile != null)
                {
                    return userProfile.CustomerID;
                }
                return Guid.Empty;
            }
            return Guid.Empty;
        }

    }
}