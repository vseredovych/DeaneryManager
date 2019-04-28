using Models.Entities;
using System.Collections.ObjectModel;

namespace Repository.Abstract
{
    interface IFacultiesRepository
    {
        void Insert(Faculty faculty);
        void Delete(long Id);
        void Update(Faculty faculty);
        ObservableCollection<Faculty> GetAll();
        Faculty GetByID(long id);
    }
}