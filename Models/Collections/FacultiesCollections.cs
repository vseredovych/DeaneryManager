using Models.Entities;
using System.Collections.ObjectModel;

namespace Models.Collections
{
    public class FacultiesCollections
    {
        private ObservableCollection<Faculties> faculties;

        public FacultiesCollections()
        {
            faculties = new ObservableCollection<Faculties>();
        }

        //public void Add(Expense expense)
        //{
        //    expenses.Add(expense);
        //}

        public ObservableCollection<Faculties> GetExpenses()
        {
            return faculties;
        }
    }
}
