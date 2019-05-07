using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu.Abstract;
using Menu.Concrete.MainMenu;
using Models.Collections.Concrete;
using Models.Entities.Concrete;
using Models.Entities.Abstract;
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
                ((StudentsRepository)studentsRepo).Insert(student);
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
            int index = (int)((Student)(((StudentsCollections)studentsCollection).GetAll()[(int)id])).Id;
            Student oldStudent = (Student)((StudentsRepository)studentsRepo).GetByID(index);
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
                //studentsCollection = ((StudentsRepository)studentsRepo).GetAll(); //.Add(student);

                ((StudentsRepository)studentsRepo).Update(student);
                ((StudentsCollections)studentsCollection).Update(student);
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
            int index = (int)((Student)(((StudentsCollections)studentsCollection).GetAll()[(int)id])).Id;
            ((StudentsRepository)studentsRepo).Delete(index) ;
            ((StudentsCollections)studentsCollection).Delete(index);

            return true;
        }
        public void Print(object studentsCollection, long id)
        {
            StudentsCollections students = ((StudentsCollections)studentsCollection);
            for (int i = 0; i < students.Length(); i++)
            {
                MenuHelper.PrintArrow((int)id, i);
                Console.WriteLine(students.GetAll()[i]);
            }
        }
        public int Length(object studentsCollection)
        {///////////
            return ((StudentsCollections)studentsCollection).Length();
        }
    }
}
