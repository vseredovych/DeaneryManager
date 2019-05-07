using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities.Abstract;

namespace Repository.Abstract
{
    public interface IRepository
    {
        List<IEntity> GetAll();
        IEntity GetByID(long id);
        bool Insert(IEntity item);
        bool Update(IEntity item);
        bool Delete(long id);
        long GetScalarValue(string commandText);
    }
}
