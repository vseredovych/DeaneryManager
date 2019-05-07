using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities.Abstract;
using Repository.Abstract;

namespace Menu.Abstract
{
    interface ICollectionMenu
    {
        bool Add(IRepository repository, object collection);
        bool Delete(IRepository repository, object collection, long id);
        bool Update(IRepository repository, object collection, long id);
        void Print(object collection, long id);
        //List<IEntity> GetAll();
        int Length(object collection);
    }
}
