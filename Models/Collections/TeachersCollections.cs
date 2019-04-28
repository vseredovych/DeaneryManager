using Models.Entities;
using System.Collections.ObjectModel;

namespace Models.Collections
{
    public class TeachersCollections
    {
        private ObservableCollection<Faculty> teacher;

        public TeachersCollections()
        {
            teacher = new ObservableCollection<Faculty>();
        }

        //public void Add(Expense expense)
        //{
        //    expenses.Add(expense);
        //}

        public ObservableCollection<Faculty> GetExpenses()
        {
            return teacher;
        }
    }
}
