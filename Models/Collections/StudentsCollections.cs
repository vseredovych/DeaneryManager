using Models.Entities;
using System.Collections.ObjectModel;

namespace Models.Collections
{
    public class StudentsCollections : IEntityCollection
    {
        private ObservableCollection<IEntity> students;
        public int TableCount { get; } = 6;

        public StudentsCollections()
        {
            students = new ObservableCollection<IEntity>();
        }

        public void Add(IEntity student)
        {
            students.Add(student);
        }
        public void Update(IEntity student)
        {
            students.Add(student);
        }
        public void Delete(int id)
        {
            //faculties.Remove(); 
        }

        public ObservableCollection<IEntity> GetAll()
        {
            return students;
        }
    }
}
