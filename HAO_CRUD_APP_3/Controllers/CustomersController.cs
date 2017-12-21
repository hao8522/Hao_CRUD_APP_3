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

            //List<Customer> customerList = new CustomersService().GetAllCustomer();

            //ViewBag.list = customerList;
            return View("Customers");
        }



        //KCustomerList



        public JsonResult KCustomerList()
        {
            return Json(new CustomersService().GetAll().Select(x => new { Id = x.Id, Name = x.Name,Address = x.Address }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddCustomer(Customer item)
        {
            item = new CustomersService().Add(item);
            return Json(item, JsonRequestBehavior.AllowGet);
        }


        public JsonResult EditCustomer(int id, Customer customer)
        {
            customer.Id = id;
            if (new CustomersService().EditCustomer(customer))
            {
                return Json(new CustomersService().GetAll(), JsonRequestBehavior.AllowGet);
            }

            return Json(null);
        }




        public JsonResult DeleteCustomer(int id)
        {

            if (new CustomersService().DeleteCustomer(id))
            {
                return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Status = false }, JsonRequestBehavior.AllowGet);

        }
    }
}