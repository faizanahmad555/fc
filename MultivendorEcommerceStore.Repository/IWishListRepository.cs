﻿using MultivendorEcommerceStore.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.Repository
{
    public interface IWishListRepository
    {
        void Create(WishList entity);

        IEnumerable<WishList> Retrive();

        void Delete(Guid id);
        WishList GetById(Guid id);
    }
}
