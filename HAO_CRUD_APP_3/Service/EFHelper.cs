using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HAO_CRUD_APP_3.Service
{
    public class EFHelper
    {

        private DbContext dbContext = null;

        public EFHelper(DbContext context)
        {
            this.dbContext = context;
        }


        public int Add<T>(T entity) where T : class
        {

            dbContext.Entry<T>(entity).State = EntityState.Added;

            return dbContext.SaveChanges();

        }


        public int Modify<T>(T entity) where T : class
        {
            dbContext.Entry<T>(entity).State = EntityState.Modified;
            return dbContext.SaveChanges();
        }


        public int Delete<T>(T entity) where T : class
        {
            dbContext.Entry<T>(entity).State = EntityState.Deleted;
            return dbContext.SaveChanges();
        }
    }
}