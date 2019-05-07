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
    public class FacultiesCollection : IEntityCollection<Faculty>
    {
        private List<Faculty> Faculties;

        public FacultiesCollection()
        {
            Faculties = new List<Faculty>();
        }
        public FacultiesCollection(List<IEntity> faculties)
        {
            Faculties = new List<Faculty>();
            foreach (IEntity el in faculties)
            {
                Faculties.Add((Faculty)el);
            }
        }

        public void Add(Faculty faculty)
        {
            Faculties.Add(faculty);
        }
        public void Update(Faculty faculty)
        {
            foreach (Faculty fa in Faculties)
            {
                if (fa.Id == faculty.Id)
                {
                    Faculties.Remove(fa);
                }
            }
        }
        public void Delete(int id)
        {
            Faculties.Remove(GetByID(id));
        }
        public List<Faculty> GetAll()
        {
            return Faculties;
        }
        public Faculty GetByID(int id)
        {
            foreach (Faculty fa in Faculties)
            {
                if (fa.Id == id)
                {
                    return fa;
                }
            }
            return null;
        }
        public int Length()
        {
            return Faculties.Count;
        }
    }
}
