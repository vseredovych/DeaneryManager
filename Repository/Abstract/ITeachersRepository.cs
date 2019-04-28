using Models.Entities;
using System.Collections.ObjectModel;

namespace Repository.Abstract
{
    interface ITeachersRepository
    {
        void Insert(Teacher teacher);
        void Delete(long Id);
        void Update(Teacher teacher);
        ObservableCollection<Teacher> GetAll();
        Teacher GetByID(long id);
    }
}