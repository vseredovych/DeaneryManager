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
        string[] databaseNames = { "Database", "File" }; 
        string[] collectionNames = { "Students", "Teachers", "Faculties" };
        string[] mainMenuStrings = { "show Tables" };

        IRepository studentsRepo;
        IRepository teachersRepo;
        IRepository facultiesRepo;
        List<IRepository> repositories;
        List<object> collections = new List<object>();

        private void ChooseDatabase(string database)
        {
            IFactory factory = FactoryProvider.GetFactory(database);

            repositories = new List<IRepository>();
            repositories.Clear();
            collections.Clear();
            studentsRepo = factory.GetRepository("Students");
            teachersRepo = factory.GetRepository("Teachers");
            facultiesRepo = factory.GetRepository("Faculties");
            repositories.Add(studentsRepo);
            repositories.Add(teachersRepo);
            repositories.Add(facultiesRepo);

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
            int databaseChoise = 1;

            do
            {
                Console.Clear();

                PrintDatabases(ref databaseChoise);
                action = Console.ReadKey(true).Key;

                switch (action)
                {
                    case ConsoleKey.UpArrow:
                        databaseChoise -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        databaseChoise += 1;
                        break;
                    case ConsoleKey.Enter:
                        ChooseDatabase(databaseNames[databaseChoise]);
                        ChooseRepositoryMenu();
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.Escape:
                        break;
                }

            } while (action != ConsoleKey.Escape);
        }
        public void ChooseRepositoryMenu()
        {
            ConsoleKey action;
            int repositoryChoise = 0;

            do
            {
                Console.Clear();

                PrintMainMenu(ref repositoryChoise);
                action = Console.ReadKey(true).Key;

                switch (action)
                {
                    case ConsoleKey.UpArrow:
                        repositoryChoise -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        repositoryChoise += 1;
                        break;
                    case ConsoleKey.Enter:
                        CollectionsOerationsMenu(repositoryChoise);
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.Escape:
                        break;
                }
            } while (action != ConsoleKey.Escape);
        }
        public void CollectionsOerationsMenu(int repositoryChoise)
        {
            ConsoleKey action;
            int entityChoise = 0;
            do
            {
                Console.Clear();
                PrintCollection(repositoryChoise, entityChoise);
                MenuHelper.PrintOperations();

                action = Console.ReadKey(true).Key;

                switch (action)
                {
                    case ConsoleKey.UpArrow:
                        entityChoise -= 1;
                        MenuHelper.HandleIndex(ref entityChoise, 0, MenuHelper.DetermineCollection(collections[repositoryChoise]).Length(collections[repositoryChoise]) - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        entityChoise += 1;
                        MenuHelper.HandleIndex(ref entityChoise, 0, MenuHelper.DetermineCollection(collections[repositoryChoise]).Length(collections[repositoryChoise]) - 1);
                        break;
                    case ConsoleKey.D1:
                        MenuHelper.DetermineCollection(collections[repositoryChoise]).Add(repositories[repositoryChoise], collections[repositoryChoise]);
                        break;
                    case ConsoleKey.D2:
                        MenuHelper.DetermineCollection(collections[repositoryChoise]).Delete(repositories[repositoryChoise], collections[repositoryChoise], entityChoise);
                        break;
                    case ConsoleKey.D3:
                        MenuHelper.DetermineCollection(collections[repositoryChoise]).Update(repositories[repositoryChoise], collections[repositoryChoise], entityChoise);
                        break;
                    case ConsoleKey.D4:
                        break;
                    case ConsoleKey.Escape:
                        break;
                }
            } while (action != ConsoleKey.Escape);
        }

        private void PrintMainMenu(ref int entityChoise)
        {
            Console.WriteLine("Tables");
            MenuHelper.HandleIndex(ref entityChoise, 0, collectionNames.Length - 1);
            for (int i = 0; i < collectionNames.Length; i++)
            {
                if (i == entityChoise)
                {
                    Console.Write("-->");
                }
                Console.WriteLine("\t" + collectionNames[i]);
            }
            Console.WriteLine("Enter - choose table");
        }
        private void PrintDatabases(ref int entityChoise)
        {
            Console.WriteLine("Databases");
            MenuHelper.HandleIndex(ref entityChoise, 0, databaseNames.Length - 1);
            for (int i = 0; i < databaseNames.Length; i++)
            {
                if (i == entityChoise)
                {
                    Console.Write("-->");
                }
                Console.WriteLine("\t" + databaseNames[i]);
            }
            Console.WriteLine("Enter - choose database");
        }
        private void PrintCollection(int repositoryChoise, int entityChoise)
        {
            MenuHelper.DetermineCollection(collections[repositoryChoise]).Print(collections[repositoryChoise], entityChoise);
        }

    }
}
