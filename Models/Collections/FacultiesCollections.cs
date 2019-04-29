using Models.Entities;
using System.Collections.ObjectModel;
using Repository.Concrete.Operations;
using System.Collections.Generic;

namespace Models.Collections
{
    public class FacultiesCollections : IEntityCollection
    {
        private ObservableCollection<IEntity> faculties;
        public int TableCount { get; } = 3;
        private FacultiesRepository facultiesOperations;

        public FacultiesCollections()
        {
            facultiesOperations = new FacultiesRepository();
            faculties = new ObservableCollection<IEntity>();
        }

        public void Add(IEntity faculty)
        {
            faculties.Add(faculty);
        }
        public void Update(IEntity faculty)
        {
            faculties.Add(faculty);
        }
        public void Delete(int id)
        {
            //faculties.Remove(); 
        }
        public ObservableCollection<IEntity> GetAll()
        {
            faculties = facultiesOperations.GetAll();
            return faculties;
        }
    }
}
