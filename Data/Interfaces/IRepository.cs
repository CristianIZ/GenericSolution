using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<TModel, TEntity>
        where TEntity : class
        where TModel : class
    {
        TModel Get(int id);
        IEnumerable<TModel> List();
        TModel Add(TModel entity);
        void Remove(int entity);
        TModel Update(TModel entity);
    }
}
