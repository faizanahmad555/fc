﻿using MultivendorEcommerceStore.DB.Model;
using MultivendorEcommerceStore.DB.ViewModel;
using MultivendorEcommerceStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.BL
{
    public class AdminBL
    {
        public void AddSupplier(AddSupplierViewModel model)  //, HttpPostedFileBase ProfilePhoto)
        {
            ISupplierRepository repository = new SupplierRepository();
            Supplier supplier = new Supplier();
            supplier.SupplierID = Guid.NewGuid();
            supplier.AspNetUserID = model.AspNetUserID;
            supplier.SupplierFirstName = model.FirstName;
            supplier.SupplierLastName = model.LastName;
            supplier.ProfilePhoto = model.ProfilePhoto;
            supplier.Phone = model.MobileNumber;
            supplier.Address1 = model.Address;
            supplier.Country = model.Country;
            supplier.State = model.State;
            supplier.State = model.City;
            supplier.CNIC = model.CNIC;
            supplier.PostalCode = model.PostalCode;
            supplier.CreatedOn = DateTime.Now;

            repository.Create(supplier);
        }

        public IEnumerable<Supplier> SupplierList()
        {
            ISupplierRepository repository = new SupplierRepository();
            IEnumerable<Supplier> supplierList = repository.Retrive();
            return supplierList;
        }

        public void DeleteSupplier(Guid id)
        {
            ISupplierRepository repository = new SupplierRepository();
            repository.Delete(id);
        }

        //String path = "";
        //if (ProfilePhoto != null)
        //{
        //    //validate image
        //    if (ValidateImage(ProfilePhoto))
        //    {
        //        //Save image
        //        path = SaveImage(ProfilePhoto);
        //    }
        //}
        // }


        //private bool ValidateImage(HttpPostedFileBase file)
        //{
        //    //if (file != null)
        //    //{
        //    String format = Path.GetExtension(file.FileName).ToString();
        //    String[] allowedFormat = new String[4] { ".jpg", ".png", ".gif", ".bmp" };
        //    int maxSize = 1048576;
        //    int minSize = 30584;

        //    if (file.ContentLength < maxSize && file.ContentLength > minSize)
        //    {
        //        if (allowedFormat.Contains(format))
        //        {
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    else
        //        return false;
        //    //}
        //    //else
        //    //    return false;
        //}

        //private String SaveImage(HttpPostedFileBase file)
        //{
        //    String extension = Path.GetExtension(file.FileName).ToString();
        //    String path = HttpContext.Current.Server.MapPath("~/Content/Supplier/Profile/");
        //    String name = "";

        //    //Generating unique name for image
        //    string guid = Guid.NewGuid().ToString();
        //    name = guid + extension;
        //    //Generating Path to Save Image at Server
        //    String fullPath = Path.Combine(path, name);
        //    //Checking if directory exist
        //    if (!Directory.Exists(path))
        //        Directory.CreateDirectory(path);
        //    //Saving Image
        //    file.SaveAs(fullPath);

        //    return fullPath;
        //}

    }
}
