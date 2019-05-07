using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu.Abstract;
using Models.Entities.Abstract;
using Repository.Abstract;
using Models.Collections.Concrete;

namespace Menu.Concrete.CollectionsMenu
{
    public class FacultiesMenu : ICollectionMenu
    {
        public bool Add(IRepository facultiesRepo, object facultiesCollection)
        {
            return true;
        }
        public bool Update(IRepository facultiesRepo, object facultiesCollection, long id)
        {
            return true;
        }
        public bool Delete(IRepository facultiesRepo, object facultiesCollection, long id)
        {
            return true;
        }
        public int Length(object facultiesCollection)
        {
            return ((FacultiesCollection)facultiesCollection).Length();
        }
    }
}
