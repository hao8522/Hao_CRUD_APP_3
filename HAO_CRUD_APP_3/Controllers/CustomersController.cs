using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HAO_CRUD_APP_3.Models;
using HAO_CRUD_APP_3.Service;

namespace HAO_CRUD_APP_3.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        public ActionResult CustomersList()
        {

            List<Customer> customerList = new CustomersService().GetAllCustomer();

            ViewBag.list = customerList;
            return View("Customers");
        }
    }
}