﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public interface IProductRepository
    {
        void Create(Product entity);
        IEnumerable<Product> Retrive();
        void Update(Product entity);
        void Delete(Guid id);
        Product GetById(Guid id);


        int? ChangeActiveStatus(Product entity);

       // Product GetByAspNetUserID(string id);

    }
}
