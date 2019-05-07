using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Collections.Abstract
{
    public interface IEntityCollection<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        List<T> GetAll();
        T GetByID(int id);
        int Length();
    }
}
