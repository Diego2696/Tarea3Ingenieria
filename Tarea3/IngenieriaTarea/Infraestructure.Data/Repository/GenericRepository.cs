using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repository
{
    public abstract class GenericRepository<C, T> :
        IGenericRepository<T> where T : class where C : DbContext, new()
    {

        private C _entities = new C();
        public C Context
        {

            get { return _entities; }
            set { _entities = value; }
        }

        public virtual bool Add(T entity)
        {
            try
            {
                _entities.Set<T>().Add(entity);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public virtual bool Delete(T entity)
        {
            try
            {
                _entities.Set<T>().Attach(entity);
                _entities.Set<T>().Remove(entity);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public virtual IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            try
            {
                IQueryable<T> query = _entities.Set<T>().Where(predicate);
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            try
            {
                IQueryable<T> query = _entities.Set<T>();
                return query;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public virtual bool Update(T entity)
        {
            try
            {
                _entities.Set<T>().Attach(entity);
                _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                _entities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
