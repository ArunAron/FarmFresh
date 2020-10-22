using DataAccess.Model;
using FarmFresh.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmFresh.Repo
{
    public class ProductRepository : DataRepositoryBase<Product>
    {
        public FarmFreshDBContext _context;
        public ProductRepository(FarmFreshDBContext context)
        {
            _context = context;
        }

        public ProductRepository()
        {

        }
        protected override Product AddEntity(FarmFreshDBContext entityContext, Product entity)
        {
            return entityContext.ProductSet.Add(entity);
        }
        protected override Product UpdateEntity(FarmFreshDBContext entityContext, Product entity)
        {
            return entityContext.ProductSet.FirstOrDefault(a => a.ID == entity.ID);
        }
        protected override IQueryable<Product> GetEntities(FarmFreshDBContext entityContext)
        {
            return entityContext.ProductSet;
        }
        protected override IQueryable<Product> GetEntitiesWithoutTracking(FarmFreshDBContext entityContext)
        {
            return entityContext.ProductSet.AsNoTracking();
        }
        protected override IQueryable<Product> GetEntitiesWithoutTracking()
        {
            return _context.ProductSet.AsNoTracking();
        }
        protected override IQueryable<Product> GetQueryable()
        {
            return _context.ProductSet;
        }

        // Was faked with Count due to issure with GUID
        protected override Product GetEntity(FarmFreshDBContext entityContext, int id)
        {
            return entityContext.ProductSet.FirstOrDefault(a => a.ID == id);
        }

        protected override Product GetEntity(FarmFreshDBContext entityContext, string GUID)
        {
            return entityContext.ProductSet.FirstOrDefault(a => a.GUID == GUID);
        }
    }
}