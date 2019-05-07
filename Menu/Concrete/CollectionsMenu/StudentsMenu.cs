using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu.Abstract;
using Menu.Concrete.MainMenu;
using Models.Collections.Concrete;
using Models.Entities.Concrete;
using Repository.Abstract;
using Repository.Concrete.Database.Repositories;

namespace Menu.Concrete.CollectionsMenu
{
    class StudentsMenu : ICollectionMenu
    {
        public bool Add(IRepository studentsRepo, object studentsCollection)
        {
            Student student = new Student();
            try
            {
                Console.Write("Input Firstname: ");
                student.FirstName = Convert.ToString(Console.ReadLine());
                Console.Write("Input Lastname: ");
                student.LastName = Convert.ToString(Console.ReadLine());
                Console.Write("Input Faculty: ");
                student.Faculty = Convert.ToString(Console.ReadLine());
                Console.Write("Input Scholarship: ");
                student.Scholarship = Convert.ToInt32(Console.ReadLine());
                Console.Write("Input Date of birth: ");
                student.Dob = Convert.ToDateTime(Console.ReadLine());
                ((StudentsCollections)studentsCollection).Add(student);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool Update(IRepository studentsRepo, object studentsCollection, long id)
        {
            Student oldStudent = (Student)((StudentsRepository)studentsRepo).GetByID((int)id + 1);
            Student student = new Student();
            try
            {
                student.Id = oldStudent.Id;
                Console.Write("Input Firstname (" + oldStudent.FirstName + "): ");
                student.FirstName = Convert.ToString(MenuHelper.InputString(Convert.ToString(oldStudent.FirstName)));
                Console.Write("Input Lastname (" + oldStudent.LastName + "): ");
                student.LastName = Convert.ToString(MenuHelper.InputString(Convert.ToString(oldStudent.LastName)));
                Console.Write("Input Faculty (" + oldStudent.Faculty + "): ");
                student.Faculty = Convert.ToString(MenuHelper.InputString(Convert.ToString(oldStudent.Faculty)));
                Console.Write("Input Scholarship (" + oldStudent.Scholarship + "): ");
                student.Scholarship = Convert.ToInt32(MenuHelper.InputString(Convert.ToString(oldStudent.Scholarship)));
                Console.Write("Input Date of birth (" + oldStudent.Dob + "): ");
                student.Dob = Convert.ToDateTime(MenuHelper.InputString(Convert.ToString(oldStudent.Dob)));
                ((StudentsRepository)studentsRepo).Update(student);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool Delete(IRepository studentsRepo, object studentsCollection, long id)
        {
            return true;
        }
        public int Length(object studentsCollection)
        {///////////
            return ((StudentsCollections)studentsCollection).Length();
        }
    }
}
