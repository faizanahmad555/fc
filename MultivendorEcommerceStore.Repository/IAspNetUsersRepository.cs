using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public interface IAspNetUsersRepository
    {
        IEnumerable<AspNetUser> Retrive();
    }
}
