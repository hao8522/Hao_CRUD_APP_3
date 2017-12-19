using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HAO_CRUD_APP_3.Models;
using System.Data.Entity;

namespace HAO_CRUD_APP_3.Service
{
    public class CustomersService
    {
        // add customer
        public int AddCustomer(Customer customer)
        {

            using (HAO_Entities db = new HAO_Entities())
            {
                db.Customers.Add(customer);

                return db.SaveChanges();
            }

        }

        public int ModifyCustomer(Customer customer)
        {
            using (HAO_Entities db = new HAO_Entities())
            {
                db.Customers.Attach(customer);
                db.Entry<Customer>(customer).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public int DeleteCustomer(int customerId)
        {
            using (HAO_Entities db = new HAO_Entities())
            {
                Customer customer = new Customer()
                {
                    Id = customerId
                };


                db.Customers.Attach(customer);
                db.Customers.Remove(customer);
                return db.SaveChanges();
            }
        }


        public List<Customer> GetAllCustomer()
        {
            using (HAO_Entities db = new HAO_Entities())
            {
                return (from c in db.Customers select c).ToList();
            }
        }


        public Customer GetCustomerById(int customerId)
        {
            using (HAO_Entities db = new HAO_Entities())
            {
                return (from c in db.Customers where c.Id == customerId select c).FirstOrDefault();
            }
        }


    }
}