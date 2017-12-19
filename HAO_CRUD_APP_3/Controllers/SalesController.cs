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
    }
}