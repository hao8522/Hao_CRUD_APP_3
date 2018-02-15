using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HAO_CRUD_APP_3.Models;
using HAO_CRUD_APP_3.Service;

namespace HAO_CRUD_APP_3.Controllers
{
    public class SalesController : Controller
    {
        public ActionResult Sales()
        {
            var salesService = new SalesService();
            ViewBag.list = salesService.GetSaleList();
            return View("Sales");
        }


        [HttpPost]
        public JsonResult AddSale(Product item)
        {
            item = new SalesService().Add(item);
            return Json(item, JsonRequestBehavior.AllowGet);
        }


        public JsonResult EditSales(int id, Product product)
        {
            product.Id = id;
            if (new SalesService().EditSales(product))
            {
                return Json(new SalesService().GetSaleList(), JsonRequestBehavior.AllowGet);
            }

            return Json(null);
        }




        public JsonResult DeleteSales(int id)
        {

            if (new ProductService().DeleteProduct(id))
            {
                return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Status = false }, JsonRequestBehavior.AllowGet);

        }
    }
}