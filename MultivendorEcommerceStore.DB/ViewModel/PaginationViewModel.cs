using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.DB.ViewModel
{
    public class PaginationViewModel
    {
        public IEnumerable<string> Items { get; set; }
        public Pager Pager { get; set; }
    }

 
}
