using Microsoft.EntityFrameworkCore;
using FlowerShop.Models;
using FlowerShop.Repositories.Interfaces;
using System.Linq.Expressions;

namespace FlowerShop.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        protected FlowersContext FlowersContext { get; set; }

        public RepositoryBase(FlowersContext FlowersContext)
        {
            this.FlowersContext = FlowersContext;
        }

        public IQueryable<T> FindAll()
        {
            return FlowersContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return FlowersContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            FlowersContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            FlowersContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            FlowersContext.Set<T>().Remove(entity);
        }
    }
}
