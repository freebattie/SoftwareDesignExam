using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Db {
    
    public interface IRepository<T> {
        void Add(T entity);
        void Update(T entity);
        List<T> GetAll();
        T GetById(int id);
    }
    
}
