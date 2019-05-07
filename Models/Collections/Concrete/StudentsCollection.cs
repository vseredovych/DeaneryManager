using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities.Concrete;
using Models.Collections.Abstract;
using Models.Entities.Abstract;

namespace Models.Collections.Concrete
{
    public class StudentsCollections : IEntityCollection<Student>
    {
        private List<Student> Students;

        public StudentsCollections()
        {
            Students = new List<Student>();
        }
        public StudentsCollections(List<IEntity> students)
        {
            Students = new List<Student>();
            foreach (IEntity el in students)
            {
                Students.Add((Student)el);
            }
        }
        public void Add(Student student)
        {
            Students.Add(student);
        }
        public void Update(Student student)
        {
            foreach (Student st in Students)
            {
                if (st.Id == student.Id)
                {
                    Students[Students.IndexOf(st)] = student;
                    break;
                }
            }
        }
        public void Delete(int id)
        {
            Students.Remove(GetByID(id));
        }
        public void Delete(Student student)
        {
            Students.Remove(student);
        }

        public List<Student> GetAll()
        {
            return Students;
        }
        public Student GetByID(int id)
        {
            foreach (Student st in Students)
            {
                if (st.Id == id)
                {
                    return st;
                }
            }
            return null;
        }
        public int Length()
        {
            return Students.Count;
        }
    }
}
