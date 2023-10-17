﻿using company.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RepositoryUsingEFinMVC.GenericRepository
{
    //The following GenericRepository class Implement the IGenericRepository Interface
    //And Here T is going to be a class
    //While Creating an Instance of the GenericRepository type, we need to specify the Class Name
    //That is we need to specify the actual class name of the type T
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //The following variable is going to hold the EmployeeDBContext instance
        private readonly CompanyContext _context;

        //The following Variable is going to hold the DbSet Entity
        private DbSet<T> table ;

        //Using the Parameterless Constructor, 
        //we are initializing the context object and table variable
        public GenericRepository()
        {
            this._context = new CompanyContext();

            //Whatever class name we specify while creating the instance of GenericRepository
            //That class name will be stored in the table variable
            table = _context.Set<T>();
        }

        //Using the Parameterized Constructor, 
        //we are initializing the context object and table variable
        public GenericRepository(CompanyContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        //This method will return all the Records from the table
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] expressionList)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var expression in expressionList)
            {
                query = query.Include(expression);
            }
            return query;
        }

        //This method will return the specified record from the table
        //based on the ID which it received as an argument
        public T GetById(object id, params Expression<Func<T, object>>[] expressionList)
        {


            if (expressionList.Any())
            {
                var set = expressionList .Aggregate<Expression<Func<T, object>>, IQueryable<T>>
                    (table, (current, expression) => current.Include(expression));

                return set.FirstOrDefault(o=>id==id);
            }

            return table.Find(id);
       
        }

        //This method will Insert one object into the table
        //It will receive the object as an argument which needs to be inserted into the database
        public void Insert(T obj)
        {
            //It will mark the Entity state as Added State
            table.Add(obj);
            Save();

        }

        //This method is going to update the record in the table
        //It will receive the object as an argument
        public void Update(T obj)
        {
            //First attach the object to the table
            table.Attach(obj);
            //Then set the state of the Entity as Modified
            _context.Entry(obj).State = EntityState.Modified;
            Save();

        }

        //This method is going to remove the record from the table
        //It will receive the primary key value as an argument whose information needs to be removed from the table
        public void Delete(object id)
        {
            //First, fetch the record from the table
            T existing = table.Find(id);
            //This will mark the Entity State as Deleted
            table.Remove(existing);
            Save();
        }

        public  IEnumerable<T> Get(Expression<Func<T, bool>> filter , Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _context.Set<T>().AsQueryable();

            //IQueryable<T> query = table;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }





        //This method will make the changes permanent in the database
        //That means once we call Insert, Update, and Delete Methods, 
        //Then we need to call the Save method to make the changes permanent in the database
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}