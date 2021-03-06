﻿using MultivendorEcommerceStore.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.Repository
{
    public interface ISubCategoryRepository
    {
        void Create(SubCategory Entity);
        IEnumerable<SubCategory> Retrive();

        SubCategory GetByID(Guid? id);
    }
}
