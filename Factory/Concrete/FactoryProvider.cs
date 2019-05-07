using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory.Abstract;
using Models.Entities;

namespace Factory.Concrete
{
    public static class FactoryProvider
    {
        public static IFactory GetFactory(string factoryType)
        {
            if (factoryType == "Database") return new DatabaseFactory();
            //else if (factoryType == "File") return new TextFactory();
            else throw new Exception(string.Format("Factory \"{0}\" not exist", factoryType));
        }
    }
}