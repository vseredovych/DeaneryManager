using Models.Entities;
using System.Collections.ObjectModel;

namespace Models.Collections
{
    public class FacultiesCollections
    {
        private ObservableCollection<Faculty> faculties;

        public FacultiesCollections()
        {
            faculties = new ObservableCollection<Faculty>();
        }

        //public void Add(Expense expense)
        //{
        //    expenses.Add(expense);
        //}

        public ObservableCollection<Faculty> GetExpenses()
        {
            return faculties;
        }
    }
}
