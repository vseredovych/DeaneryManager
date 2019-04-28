using Models.Entities;
using System.Collections.ObjectModel;

namespace Models.Collections
{
    public class StudentsCollections
    {
        private ObservableCollection<Students> students;

        public StudentsCollections()
        {
            students = new ObservableCollection<Students>();
        }

        //public void Add(Expense expense)
        //{
        //    expenses.Add(expense);
        //}

        public ObservableCollection<Students> GetExpenses()
        {
            return students;
        }
    }
}
