using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HAO_CRUD_APP_3.Models;
using HAO_CRUD_APP_3.Service;

namespace HAO_CRUD_APP_3.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult ProductList()
        {

            //List<Product> productList = new ProductService().GetAllProduct();

            //ViewBag.list = productList;
            return View("Products");
        }


        public JsonResult KProductList()
        {
            return Json(new ProductService().GetAll().Select(x => new { Id = x.Id, Name = x.Name, Price = x.Price }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddProduct(Product item)
        {
            item = new ProductService().Add(item);
            return Json(item, JsonRequestBehavior.AllowGet);
        }


        public JsonResult EditProduct(int id, Product product)
        {
            product.Id = id;
            if (new ProductService().EditProduct(product))
            {
                return Json(new ProductService().GetAll(), JsonRequestBehavior.AllowGet);
            }

            return Json(null);
        }




        public JsonResult DeleteProduct(int id)
        {

            if (new ProductService().DeleteProduct(id))
            {
                return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Status = false }, JsonRequestBehavior.AllowGet);

        }

    }
}