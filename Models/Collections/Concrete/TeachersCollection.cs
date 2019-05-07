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
    public class TeachersCollections : IEntityCollection<Teacher>
    {
        private List<Teacher> Teachers;

        public TeachersCollections()
        {
            Teachers = new List<Teacher>();
        }
        public TeachersCollections(List<IEntity> teachers)
        {
            Teachers = new List<Teacher>();
            foreach (IEntity el in teachers)
            {
                Teachers.Add((Teacher)el);
            }
        }
        public void Add(Teacher teacher)
        {
            Teachers.Add(teacher);
        }
        public void Update(Teacher teacher)
        {
            foreach (Teacher te in Teachers)
            {
                if (te.Id == teacher.Id)
                {
                    Teachers[Teachers.IndexOf(te)] = teacher;
                    break;
                }
            }
        }
        public void Delete(int id)
        {
            Teachers.Remove(GetByID(id));
        }
        public void Delete(Teacher teacher)
        {
            Teachers.Remove(teacher);
        }
        public List<Teacher> GetAll()
        {
            return Teachers;
        }
        public Teacher GetByID(int id)
        {
            foreach (Teacher te in Teachers)
            {
                if (te.Id == id)
                {
                    return te;
                }
            }
            return null;
        }
        public int Length()
        {
            return Teachers.Count;
        }
    }
}
