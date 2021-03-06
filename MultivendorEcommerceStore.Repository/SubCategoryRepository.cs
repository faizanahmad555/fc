﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivendorEcommerceStore.DB.Model;

namespace MultivendorEcommerceStore.Repository
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private MultivendorEcommerceStoreEntities _db;
        public void Create(SubCategory Entity)
        {
            _db = new MultivendorEcommerceStoreEntities();
            _db.SubCategories.Add(Entity);
            _db.SaveChanges();
         }

        public IEnumerable<SubCategory> Retrive()
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.SubCategories.ToList();
        }

        public SubCategory GetByID(Guid? id)
        {
            _db = new MultivendorEcommerceStoreEntities();
            return _db.SubCategories.Where(c => c.SubCategoryID == id).FirstOrDefault();
        }

        
    }
}
