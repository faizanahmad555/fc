using MultivendorEcommerceStore.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultivendorEcommerceStore.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }


        // CHANGE: Product Active Status
        [Authorize(Roles = "Admin, Supplier")]
        public int? ChangeProductActiveStatus(Guid ProductID, int IsActive)
        {
            ProductBL productBL = new ProductBL();
            return productBL.ChangeProductStatus(ProductID, IsActive);
        }


        // DELETE: Prompt Before Delete Product
        [Authorize(Roles = "Admin, Supplier")]
        public bool DeleteProductConfirm(Guid ProductID)
        {
            ProductBL productBL = new ProductBL();
            productBL.DeleteProduct(ProductID);
            return true;
        }




        // GET: SubCategory By CategoryID
        [Authorize(Roles = "Admin, Supplier")]
        public JsonResult SubCategoriesByCategoryID(Guid ID)
        {
            CategoryBL categoryBL = new CategoryBL();
            List<SelectListItem> list = new List<SelectListItem>();
            var subCategory = categoryBL.GetSubCategoriesByCategoryID(ID).Select(c => new
            {
                Text = c.SubCategoryName,
                Value = c.SubCategoryID
            }).ToList();
            var subcategory = new SelectList(subCategory, "Value", "Text");
            return Json(new { subcategory }, JsonRequestBehavior.AllowGet);
        }

        
        // GET: SubCategoryItems By SubCategoryID
        [Authorize(Roles = "Admin, Supplier")]
        public JsonResult SubCategoryItemsBySubCategoryID(Guid ID)
        {
            CategoryBL categoryBL = new CategoryBL();
            List<SelectListItem> list = new List<SelectListItem>();
            var subCategoryItem = categoryBL.GetSubCategoryItemsBySubCategoryID(ID).Select(c => new
            {
                Text = c.SubCategoryName,
                Value = c.SubCategoryItemID
            }).ToList();
            var subcategoryitem = new SelectList(subCategoryItem, "Value", "Text");
            return Json(new { subcategoryitem }, JsonRequestBehavior.AllowGet);
        }

    }
}