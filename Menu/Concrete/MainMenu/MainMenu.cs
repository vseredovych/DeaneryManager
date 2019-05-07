using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Collections.Concrete;
using Factory.Concrete;
using Factory.Abstract;
using Repository.Abstract;
using Repository.Concrete.Database.Repositories;
using Models.Entities.Abstract;
using Models.Entities.Concrete;


namespace Menu.Concrete.MainMenu
{
    public class MainMenu
    {
        string[] collectionNames = { "Students", "Teachers", "Faculties" };
        string[] mainMenuStrings = { "show Tables" };

        public static StudentsCollections students;
        IRepository studentsRepo;
        IRepository teachersRepo;
        IRepository facultiesRepo;
        List<IRepository> repositories;
        List<object> collections = new List<object>();
        public MainMenu()
        {
            IFactory factory = FactoryProvider.GetFactory("Database");
            repositories = new List<IRepository>();
            studentsRepo = factory.GetRepository("Students");
            teachersRepo = factory.GetRepository("Teachers");
            facultiesRepo = factory.GetRepository("Faculties");
            repositories.Add(studentsRepo);
            repositories.Add(teachersRepo);
            repositories.Add(facultiesRepo);

            studentsRepo.GetAll();
            StudentsCollections studentsCollections = new StudentsCollections(studentsRepo.GetAll());
            TeachersCollections teachersCollections = new TeachersCollections(teachersRepo.GetAll());
            FacultiesCollection facultiesCollection = new FacultiesCollection(facultiesRepo.GetAll());
            collections.Add(studentsCollections);
            collections.Add(teachersCollections);
            collections.Add(facultiesCollection);

            //MenuHelper.
        }
 
        public void StartMenu()
        {
            ConsoleKey action;
            int chooseKey = 1;

            do
            {
                Console.Clear();

                PrintMainMenu(ref chooseKey);
                action = Console.ReadKey(true).Key;

                switch (action)
                {
                    case ConsoleKey.UpArrow:
                        chooseKey -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        chooseKey += 1;
                        break;
                    case ConsoleKey.Enter:
                        CollectionsOerationsMenu(chooseKey);
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.Escape:
                        break;
                }

            } while (action != ConsoleKey.Escape);
        }
        public void CollectionsOerationsMenu(int choosenKey)
        {
            ConsoleKey action;
            int chooseKey = 0;
            do
            {
                Console.Clear();
                PrintCollection(choosenKey);
                MenuHelper.PrintOperations();

                action = Console.ReadKey(true).Key;

                switch (action)
                {
                    case ConsoleKey.UpArrow:
                        chooseKey -= 1;
                        MenuHelper.HandleIndex(ref chooseKey, 0, MenuHelper.DetermineCollection(collections[choosenKey]).Length(collections[chooseKey]) - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        chooseKey += 1;
                        MenuHelper.HandleIndex(ref chooseKey, 0, MenuHelper.DetermineCollection(collections[choosenKey]).Length(collections[chooseKey]) - 1);
                        break;
                    case ConsoleKey.D1:
                        MenuHelper.DetermineCollection(collections[choosenKey]).Add(repositories[choosenKey], collections[chooseKey]);
                        break;
                    case ConsoleKey.D2:
                        MenuHelper.DetermineCollection(collections[choosenKey]).Delete(repositories[choosenKey], collections[chooseKey], chooseKey);
                        break;
                    case ConsoleKey.D3:
                        MenuHelper.DetermineCollection(collections[choosenKey]).Update(repositories[choosenKey], collections[chooseKey], chooseKey);
                        break;
                    case ConsoleKey.D4:
                        //SaveTable(table);
                        break;
                    case ConsoleKey.Escape:
                        break;
                }
            } while (action != ConsoleKey.Escape);
        }

        private void PrintMainMenu(ref int chooseKey)
        {
            Console.WriteLine("Tables");
            MenuHelper.HandleIndex(ref chooseKey, 0, collectionNames.Length - 1);
            for (int i = 0; i < collectionNames.Length; i++)
            {
                if (i == chooseKey)
                {
                    Console.Write("-->");
                }
                Console.WriteLine("\t" + collectionNames[i]);
            }
            Console.WriteLine("Enter - choose table");

        }
        private void PrintCollection(int chooseKey)
        {
            //for (MenuHelper.DetermineCollection(collections[chooseKey]))
            if (chooseKey == 0)
            {
                foreach (Student el in ((StudentsCollections)collections[chooseKey]).GetAll())
                {
                    Console.WriteLine(el);
                }
            }
            else if (chooseKey == 1)
            {
                foreach (Teacher el in ((TeachersCollections)collections[chooseKey]).GetAll())
                {
                    Console.WriteLine(el);
                }
            }
            else if (chooseKey == 2)
            {
                foreach (Faculty el in ((FacultiesCollection)collections[chooseKey]).GetAll())
                {
                    Console.WriteLine(el);
                }
            }
        }

    }
}
