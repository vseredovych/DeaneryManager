using Models.Entities;
using System.Collections.ObjectModel;

namespace Models.Collections
{
    public class TeachersCollections
    {
        private ObservableCollection<Faculties> teacher;

        public TeachersCollections()
        {
            teacher = new ObservableCollection<Faculties>();
        }

        //public void Add(Expense expense)
        //{
        //    expenses.Add(expense);
        //}

        public ObservableCollection<Faculties> GetExpenses()
        {
            return teacher;
        }
    }
}
