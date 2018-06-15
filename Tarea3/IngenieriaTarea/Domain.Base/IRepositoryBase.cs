using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        List<T> GetAll();
        List<T> FindBy(T entity);
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
    }
}
