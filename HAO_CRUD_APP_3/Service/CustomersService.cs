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
        //// add customer
        //public int AddCustomer(Customer customer)
        //{

        //    using (HAO_Entities db = new HAO_Entities())
        //    {
        //        db.Customers.Add(customer);

        //        return db.SaveChanges();
        //    }

        //}

        //public int ModifyCustomer(Customer customer)
        //{
        //    using (HAO_Entities db = new HAO_Entities())
        //    {
        //        db.Customers.Attach(customer);
        //        db.Entry<Customer>(customer).State = EntityState.Modified;
        //        return db.SaveChanges();
        //    }
        //}

        //public int DeleteCustomer(int customerId)
        //{
        //    using (HAO_Entities db = new HAO_Entities())
        //    {
        //        Customer customer = new Customer()
        //        {
        //            Id = customerId
        //        };


        //        db.Customers.Attach(customer);
        //        db.Customers.Remove(customer);
        //        return db.SaveChanges();
        //    }
        //}


        //public List<Customer> GetAllCustomer()
        //{
        //    using (HAO_Entities db = new HAO_Entities())
        //    {
        //        return (from c in db.Customers select c).ToList();
        //    }
        //}


        //public Customer GetCustomerById(int customerId)
        //{
        //    using (HAO_Entities db = new HAO_Entities())
        //    {
        //        return (from c in db.Customers where c.Id == customerId select c).FirstOrDefault();
        //    }
        //}

        HAO_Entities db = new HAO_Entities();

        public IEnumerable<Customer> GetAll()
        {


            return db.Customers;

        }


        public Customer Add(Customer item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to save record into database
            db.Customers.Add(item);
            db.SaveChanges();
            return item;
        }



        public bool EditCustomer(Customer item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }



            var customers = db.Customers.Single(a => a.Id == item.Id);
            customers.Name = item.Name;

            customers.Address = item.Address;
            db.SaveChanges();

            return true;
        }


        public bool DeleteCustomer(int id)
        {
            // TO DO : Code to remove the records from database

            Customer customers = db.Customers.Find(id);
            db.Customers.Remove(customers);
            db.SaveChanges();

            return true;
        }
    }
}