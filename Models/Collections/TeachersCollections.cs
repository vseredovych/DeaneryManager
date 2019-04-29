using Models.Entities;
using System.Collections.ObjectModel;

namespace Models.Collections
{
    public class TeachersCollections : IEntityCollection
    {
        private ObservableCollection<IEntity> teachers;
        public int TableCount { get; } = 7;

        public TeachersCollections()
        {
            teachers = new ObservableCollection<IEntity>();
        }

        public void Add(IEntity teacher)
        {
            teachers.Add(teacher);
        }
        public void Update(IEntity teacher)
        {
            teachers.Add(teacher);
        }
        public void Delete(int id)
        {
            //faculties.Remove(); 
        }

        public ObservableCollection<IEntity> GetAll()
        {
            return teachers;
        }
    }
}
