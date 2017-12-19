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

            List<Product> productList = new ProductService().GetAllProduct();

            ViewBag.list = productList;
            return View("Products");
        }
    }
}