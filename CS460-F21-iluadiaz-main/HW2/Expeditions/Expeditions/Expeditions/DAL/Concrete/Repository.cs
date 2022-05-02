﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Expeditions.DAL.Abstract;

namespace Expeditions.DAL.Concrete
{
        /// <summary>
        /// Base class repository that implements common and CRUD operations.  Meant to be like an abstract 
        /// base class, but not actually made abstract because it is often useful to have a repository 
        /// that only supports these common operations.
        /// 
        /// This is only a minimal version. There is quite a lot we could add to this, including:
        ///    - add better error checking/recovery (i.e. throw exceptions when something goes wrong; write a 
        ///      custom exception class to handle errors)
        ///    - Write a base model class for the parameterized type, i.e. require TEntity : ModelBase, 
        ///      and have ModelBase define important things like the PK name and type so we can enforce that in
        ///      FindById for example.
        ///    - Async versions
        ///    - Add a method called something like GetFiltered that takes Func delegate
        ///      and allows us to apply a filter like Where when getting an IQueryable of TEntity
        /// </summary>
        /// <typeparam name="TEntity">This is the entity for which we're making a repository</typeparam>
        public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
        {
            // The context is private to enforce full separation, preventing a subclass from accessing
            // entities other than this one.  If you need other entities, write a separate "service" or "provider" class
            // that has access to all repositories needed
            private readonly DbContext _context;
            // This one is OK to use in a subclass because it only represents the entity for this type of repository
            // and it can be mocked
            protected readonly DbSet<TEntity> _dbSet;

            public Repository(DbContext ctx)
            {
                _context = ctx;
                _dbSet = _context.Set<TEntity>();
            }

            // Find by ID assuming it's the PK and is an int
            public virtual TEntity FindById(int id)
            {
                TEntity entity = _dbSet.Find(id);
                return entity;  // null if not found
            }

            public virtual bool Exists(int id)
            {

                return FindById(id) != null;
            }

            public virtual IQueryable<TEntity> GetAll()
            {
                return _dbSet;
            }

            public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
            {
                // Apply includes one by one
                IQueryable<TEntity> dbs = _dbSet;
                foreach (var item in includes)
                {
                    dbs = dbs.Include(item);
                }
                return dbs;
            }

            public virtual TEntity AddOrUpdate(TEntity entity)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Entity must not be null to add or update");
                }
                _context.Update(entity);
                _context.SaveChanges();
                return entity;
            }

            public virtual void Delete(TEntity entity)
            {
                if (entity == null)
                {
                    throw new Exception("Entity to delete was not found or was null");
                }
                else
                {
                    _dbSet.Remove(entity);
                    _context.SaveChanges();
                }
                return;
            }

            public virtual void DeleteById(int id)
            {
                Delete(FindById(id));
                return;
            }


            public virtual TEntity Update(TEntity entity)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Entity must not be null to add or update");
                }
                _context.Update(entity);

                return entity;
            }
        }
    }

