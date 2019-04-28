using Models.Entities;
using System.Collections.ObjectModel;

namespace Models.Collections
{
    public class StudentsCollections
    {
        private ObservableCollection<Student> students;

        public StudentsCollections()
        {
            students = new ObservableCollection<Student>();
        }

        //public void Add(Expense expense)
        //{
        //    expenses.Add(expense);
        //}

        public ObservableCollection<Student> GetExpenses()
        {
            return students;
        }
    }
}
