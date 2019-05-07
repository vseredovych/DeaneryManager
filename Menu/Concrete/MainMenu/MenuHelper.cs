using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu.Abstract;
using Models.Collections.Concrete;
using Menu.Concrete.CollectionsMenu;

namespace Menu.Concrete.MainMenu
{
    class MenuHelper
    {
        static StudentsMenu studentsMenu;
        static TeachersMenu teachersMenu;
        static FacultiesMenu facultiesMenu;
        static readonly string[] operations = { "Add Item", "Delete Item", "Edit Item" };

        public static ICollectionMenu  DetermineCollection(object collection)
        {
            if (collection is StudentsCollections)
            {
                studentsMenu = new StudentsMenu();
                return (ICollectionMenu)studentsMenu;
            }
            else if (collection is TeachersCollections)
            {
                teachersMenu = new TeachersMenu();
                return (ICollectionMenu)teachersMenu;
            }
            else if (collection is FacultiesCollection)
            {
                facultiesMenu = new FacultiesMenu();
                return (ICollectionMenu)facultiesMenu;
            }
            else
            {
                throw new Exception("No such menu!");
            }
        }
        public static void PrintOperations()
        {
            for (int i = 0; i < operations.Length; i++)
            {
                Console.Write(i + 1);
                Console.WriteLine(" - " + operations[i] + "\t");
            }
        }

        public static string InputString(string oldString)
        {
            string temp = "";
            temp = Console.ReadLine();
            if (temp != null && temp.Length != 0)
            {
                return temp;
            }
            else
            {
                return oldString;
            }
        }
        public static void HandleIndex(ref int chooseKey, int min, int max)
        {
            if (chooseKey < min)
            {
                chooseKey = min;
            }
            if (chooseKey >= max)
            {
                chooseKey = max;
            }
        }
    }
}
