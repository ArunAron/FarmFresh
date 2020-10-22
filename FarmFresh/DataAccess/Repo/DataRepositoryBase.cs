using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DataAccess.Model;
using FarmFresh.DBContext;
using FarmFresh.Utils;

namespace FarmFresh.Repo
{
    public abstract class DataRepositoryBase<T> where T : class, new()
    {
      
        protected abstract T AddEntity(FarmFreshDBContext entityContext, T entity);

        protected abstract T UpdateEntity(FarmFreshDBContext entityContext, T entity);

        protected abstract IQueryable<T> GetEntities(FarmFreshDBContext entityContext);
        protected abstract IQueryable<T> GetEntitiesWithoutTracking(FarmFreshDBContext entityContext);

        protected abstract IQueryable<T> GetEntitiesWithoutTracking();
        protected abstract IQueryable<T> GetQueryable();

        protected abstract T GetEntity(FarmFreshDBContext entityContext, int id);
        protected abstract T GetEntity(FarmFreshDBContext entityContext, string GUID);

        public T Add(T entity)
        {
            try
            {
                using (FarmFreshDBContext entityContext = new FarmFreshDBContext())
                {
                    T addedEntity = AddEntity(entityContext, entity);
                    entityContext.SaveChanges();
                    return addedEntity;
                }
            }
            catch(Exception ex)
            {
                return null;
            }        
        }     

        public void Remove(T entity)
        {
            using(FarmFreshDBContext entityContext = new FarmFreshDBContext())
            {
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }              
        }
        
        public void Remove(int id)
        {
            using(FarmFreshDBContext entityContext = new FarmFreshDBContext())
            {
                T entity = GetEntity(entityContext, id);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public T update(T entity)
        {
            using(FarmFreshDBContext entityContext = new FarmFreshDBContext())
            {
                T existingEntity = UpdateEntity(entityContext, entity);
                SimpleMapper.PropertyMap(entity, existingEntity);
                entityContext.SaveChanges();
                return existingEntity;
            }
        }

        public IEnumerable<T> Get()
        {
            using (FarmFreshDBContext entityContext = new FarmFreshDBContext())
            {
                //return (GetEntities(entityContext).ToArray().AsEnumerable());
                return (GetEntities(entityContext).AsEnumerable());
            }          
        }
        public IQueryable<T> Get(FarmFreshDBContext entityContext)
        {
            //return (GetEntities(entityContext).ToArray().AsEnumerable());
            return (GetEntities(entityContext));

        }
        //public IQueryable<T> GetWithoutTracking()
        //{
        //    //return (GetEntities(entityContext).ToArray().AsEnumerable());
        //    return (GetEntitiesWithoutTracking(Context entityContext));

        //}
        public T Get(int id)
        {   
            using(FarmFreshDBContext entityContext = new FarmFreshDBContext())
            {
                return GetEntity(entityContext, id);
            }     
        }

        public T Get(string GUID)
        {
            using (FarmFreshDBContext entityContext = new FarmFreshDBContext())
            {
                return GetEntity(entityContext, GUID);
            }
        }

        public IQueryable<T> GetDataSet()
        {
            return (GetQueryable()).AsQueryable();
        }
        public IQueryable<T> GetDataSetWithoutTracking()
        {
            return (GetEntitiesWithoutTracking()).AsQueryable();
        }
    }
}