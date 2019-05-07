using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory.Abstract;
using Repository.Abstract;

namespace Factory.Concrete
{
    public class DatabaseFactory : IFactory
    {

        public IRepository GetRepository(string name)
        {
            if (name == "Faculties")
            {
                return new Repository.Concrete.Database.Repositories.FacultiesRepository();
            }
            else if (name == "Students")
            {
                return new Repository.Concrete.Database.Repositories.StudentsRepository();
            }
            else if (name == "Teachers")
            {
                return new Repository.Concrete.Database.Repositories.TeachersOperatinos();
            }
            else throw new Exception("There is no " + name + " repository!");
        }
    }
}
