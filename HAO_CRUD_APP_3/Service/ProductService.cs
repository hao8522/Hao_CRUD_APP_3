using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HAO_CRUD_APP_3.Models;
using System.Data.Entity;

namespace HAO_CRUD_APP_3.Service
{
    public class ProductService
    {
        //public int AddProduct(Product product)
        //{
        //    using (HAO_Entities db = new HAO_Entities())
        //    {
        //        db.Products.Add(product);

        //        return db.SaveChanges();
        //    }


        //}

        //public int ModifyProduct(Product product)
        //{
        //    using (HAO_Entities db = new HAO_Entities())
        //    {
        //        db.Products.Attach(product);
        //        db.Entry<Product>(product).State = EntityState.Modified;
        //        return db.SaveChanges();
        //    }
        //}

        //public int DeleteProduct(int productId)
        //{
        //    using (HAO_Entities db = new HAO_Entities())
        //    {
        //        Product p = new Product()
        //        {
        //            Id = productId
        //        };

        //        db.Products.Attach(p);
        //        db.Products.Remove(p);

        //        return db.SaveChanges();
        //    }
        //}

        //public List<Product> GetAllProduct()
        //{
        //    using (HAO_Entities db = new HAO_Entities())
        //    {
        //        return (from p in db.Products select p).ToList();
        //    }
        //}

        //public Product GetProductById(int productId)
        //{
        //    using (HAO_Entities db = new HAO_Entities())
        //    {
        //        return (from p in db.Products where p.Id == productId select p).FirstOrDefault();

        //    }
        //}
        HAO_Entities db = new HAO_Entities();

        public IEnumerable<Product> GetAll()
        {
            

                return db.Products;
        
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



        public bool EditProduct(Product item)
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


        public bool DeleteProduct(int id)
        {
            // TO DO : Code to remove the records from database

            Product products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();

            return true;
        }

    }
}