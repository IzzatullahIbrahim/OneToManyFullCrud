using Microsoft.EntityFrameworkCore;
using OneToMany.Data;
using OneToMany.Interfaces;
using OneToMany.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneToMany.Respository
{
    public class GenericRepository: IGenericRepository
    {
        private ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _db.Set<T>().AsQueryable();
        }


        // Add
        public void Add<T>(T entityToCreate) where T : class
        {
            _db.Set<T>().Add(entityToCreate);
            this.SaveChanges();
        }


        // Update
        public void Update<T>(T entityToUpdate) where T : class
        {
            _db.Set<T>().Update(entityToUpdate);
            this.SaveChanges();
        }


        //Delete
        public void Delete<T>(T entityToDelete) where T : class
        {
            _db.Set<T>().Remove(entityToDelete);
            this.SaveChanges();
        }


        /// <summary>
        /// Execute stored procedures and dynamic sql
        /// </summary>
        public IQueryable<T> SqlQuery<T>(string sql, params object[] parameters) where T : class
        {
            return _db.Set<T>().FromSql(sql, parameters);
        }


        //Save Changes
        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        //Dispose
        public void Dispose()
        {
            _db.Dispose();
        }
    }

}
