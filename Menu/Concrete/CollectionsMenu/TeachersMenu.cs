using Menu.Abstract;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Collections.Concrete;

namespace Menu.Concrete.CollectionsMenu
{
    class TeachersMenu : ICollectionMenu
    {
        public bool Add(IRepository teachersRepo, object teachersCollection)
        {
            return true;
        }
        public bool Update(IRepository teachersRepo, object teachersCollection, long id)
        {
            return true;
        }
        public bool Delete(IRepository teachersRepo, object teachersCollection, long id)
        {
            return true;
        }
        public int Length(object teachersCollection)
        {
            return ((TeachersCollections)teachersCollection).Length();
        }
    }
}
