using Menu.Abstract;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Collections.Concrete;
using Menu.Concrete.MainMenu;
using Repository.Concrete.Database.Repositories;
using Models.Entities.Concrete;

namespace Menu.Concrete.CollectionsMenu
{
    class TeachersMenu : ICollectionMenu
    {
        public bool Add(IRepository teachersRepo, object teachersCollection)
        {
            Teacher teacher = new Teacher();
            try
            {
                //Console.Write("Input id: ");
                //teacher.Id = Convert.ToInt64(Console.ReadLine());
                Console.Write("Input Firstname: ");
                teacher.FirstName = Convert.ToString(Console.ReadLine());
                Console.Write("Input Lastname: ");
                teacher.LastName = Convert.ToString(Console.ReadLine());
                Console.Write("Input Faculty: ");
                teacher.Faculty = Convert.ToString(Console.ReadLine());
                Console.Write("Input Specialty: ");
                teacher.Specialty = Convert.ToString(Console.ReadLine());
                Console.Write("Input Scholarship: ");
                teacher.Salary = Convert.ToInt32(Console.ReadLine());
                Console.Write("Input Date of birth: ");
                teacher.Dob = Convert.ToDateTime(Console.ReadLine());
                if (teachersRepo is Repository.Concrete.Database.Repositories.TeachersRepository)
                {
                    ((TeachersRepository)teachersRepo).Insert(teacher);
                }
                else
                {
                    ((Repository.Concrete.File.Repositories.TeachersRepository)teachersRepo).Insert(teacher);
                }
                ((TeachersCollections)teachersCollection).Add(teacher);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return true;
        }
        public bool Update(IRepository teachersRepo, object teachersCollection, long id)
        {
            try
            {
                int index = (int)((Teacher)(((TeachersCollections)teachersCollection).GetAll()[(int)id])).Id;
                Teacher oldTeacher = (Teacher)((TeachersRepository)teachersRepo).GetByID(index);
                Teacher teacher = new Teacher();
                teacher.Id = oldTeacher.Id;
                Console.Write("Input Firstname (" + oldTeacher.FirstName + "): ");
                teacher.FirstName = Convert.ToString(MenuHelper.InputString(Convert.ToString(oldTeacher.FirstName)));
                Console.Write("Input Lastname (" + oldTeacher.LastName + "): ");
                teacher.LastName = Convert.ToString(MenuHelper.InputString(Convert.ToString(oldTeacher.LastName)));
                Console.Write("Input Faculty (" + oldTeacher.Faculty + "): ");
                teacher.Faculty = Convert.ToString(MenuHelper.InputString(Convert.ToString(oldTeacher.Faculty)));
                Console.Write("Input Specialty (" + oldTeacher.Specialty + "): ");
                teacher.Specialty = Convert.ToString(MenuHelper.InputString(Convert.ToString(oldTeacher.Specialty)));
                Console.Write("Input Salary (" + oldTeacher.Salary + "): ");
                teacher.Salary = Convert.ToInt32(MenuHelper.InputString(Convert.ToString(oldTeacher.Salary)));
                Console.Write("Input Date of birth (" + oldTeacher.Dob + "): ");
                teacher.Dob = Convert.ToDateTime(MenuHelper.InputString(Convert.ToString(oldTeacher.Dob)));
                ((TeachersRepository)teachersRepo).Update(teacher);
                ((TeachersCollections)teachersCollection).Update(teacher);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return true;
        }
        public bool Delete(IRepository teachersRepo, object teachersCollection, long id)
        {
            int index = (int)((Teacher)(((TeachersCollections)teachersCollection).GetAll()[(int)id])).Id;
            if (teachersRepo is Repository.Concrete.Database.Repositories.TeachersRepository)
            {
                ((TeachersRepository)teachersRepo).Delete(index);
            }
            else
            {
                ((Repository.Concrete.File.Repositories.TeachersRepository)teachersRepo).Delete(index);
            }
            ((TeachersCollections)teachersCollection).Delete(index);

            return true;
        }
        public void Print(object teachersCollection, long id)
        {
            TeachersCollections teachers = ((TeachersCollections)teachersCollection);
            for (int i = 0; i < teachers.Length(); i++)
            {
                MenuHelper.PrintArrow((int)id, i);
                Console.WriteLine(teachers.GetAll()[i]);
            }
        }
        public int Length(object teachersCollection)
        {
            return ((TeachersCollections)teachersCollection).Length();
        }
    }
}
