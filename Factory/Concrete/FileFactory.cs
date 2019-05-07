using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory.Abstract;
using Repository.Concrete.File;
using Repository.Abstract;

namespace Factory.Concrete
{
    public class FileFactory : IFactory
    {
        public IRepository GetRepository(string name)
        {
            if (name == "Students")
            {
                return new Repository.Concrete.File.Repositories.StudentsRepository();
            }
            else if (name == "Teachers")
            {
                return new Repository.Concrete.File.Repositories.TeachersRepository();
            }
            else if (name == "Faculties")
            {
                return new Repository.Concrete.File.Repositories.FacultiesRepository();
            }
            else throw new Exception("No such repository with name " + name);
        }
    }
}
