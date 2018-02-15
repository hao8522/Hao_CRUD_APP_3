using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HAO_CRUD_APP_3.Models;
using HAO_CRUD_APP_3.Service;

namespace HAO_CRUD_APP_3.Service
{
    public class SalesService
    {
        HAO_Entities db = new HAO_Entities();
        public IEnumerable<Sales> GetSaleList()
        {
            List<Sales> sales = new List<Sales>();
            using (HAO_Entities db = new HAO_Entities())
            {
                var aa = (from ps in db.ProductSolds

                          join c in db.Customers on ps.CustomerId equals c.Id
                          join p in db.Products on ps.ProductId equals p.Id
                          join s in db.Stores on ps.StoreId equals s.Id

                          select (new { CustomerName = c.Name, ProductName = p.Name, ProductSold = ps.DateSold, ProductId = ps.Id })
                        ).ToList();

                foreach (var sale in aa)
                {
                    sales.Add(new Sales()
                    {
                        CustomerName = sale.CustomerName,
                        ProductName = sale.ProductName,
                        ProductSold = sale.ProductSold,
                        ProductId = sale.ProductId
                    });
                }

                return sales;



            }
        }


        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to save record into database
            db.Products.Add(item);
            db.SaveChanges();
            return item;
        }



        public bool EditSales(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }



            var products = db.Products.Single(a => a.Id == item.Id);
            products.Name = item.Name;

            products.Price = item.Price;
            db.SaveChanges();

            return true;
        }


        public bool DeleteSales(int id)
        {
            // TO DO : Code to remove the records from database

            Product products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();

            return true;
        }

    }
}