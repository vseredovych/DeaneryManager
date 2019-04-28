using Models.Entities;
using System.Collections.ObjectModel;

namespace Repository.Abstract
{
    interface IStudentsRepository
    {
        void Insert(Student student);
        void Delete(long Id);
        void Update(Student student);
        ObservableCollection<Student> GetAll();
        Student GetByID(long id);
    }
}