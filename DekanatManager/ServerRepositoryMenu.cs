using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalRepository.LocalDatabase;
using LocalRepository.Entities;
using LocalRepository;
using Repository.Core;
using Repository.Concrete.Operations;
using Models.Entities;
using Models.Collections;
using System.Collections;
using System.Collections.ObjectModel;

namespace DekanatManager
{
    public class ServerRepositoryMenu
    {
        string[] tables = { "Students", "Teachers", "Faculties" };
        string[] mainMenuStrings = { "show Tables" };
        string[] operations = { "AddItem", "DeleteItem", "CloneItem", "Save" };
        public Dictionary<string, List<string>> TableDictionary { get; set; }

        TeachersCollections teachersCollections;
        FacultiesCollections facultiesCollections;
        StudentsCollections studentsCollections;
        List<IEntityCollection> collections;

        public ServerRepositoryMenu()
        {
            teachersCollections = new TeachersCollections();
            facultiesCollections = new FacultiesCollections();
            studentsCollections = new StudentsCollections();
            collections = new List<IEntityCollection>();

            collections.Add(studentsCollections);
            collections.Add(teachersCollections);
            collections.Add(facultiesCollections);

        }
        public void MainMenu()
        {
            ConsoleKey action;
            int chooseKey = 1;

            do
            {
                Console.Clear();
                
                printMainMenu(ref chooseKey);
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
                        //TableOperationsMenu(tableRepository.Tables[chooseKey]);
                        TableOperationsMenu(collections[chooseKey]);
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.Escape:
                        break;
                }

            } while (action != ConsoleKey.Escape);
        }
        public void TableOperationsMenu(IEntityCollection entityCollection)
        {
            ConsoleKey action;
            int chooseKey = 0;

            do
            {
                Console.Clear();
                PrintCollection(entityCollection, ref chooseKey);
                PrintOperations();
                action = Console.ReadKey(true).Key;

                switch (action)
                {
                    case ConsoleKey.UpArrow:
                        chooseKey -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        chooseKey += 1;
                        break;
                    case ConsoleKey.D1:
                        //AddItem(table);
                        break;
                    case ConsoleKey.D2:
                        //RemoveItem(table, chooseKey);
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.D4:
                        //SaveTable(table);
                        break;

                    case ConsoleKey.Escape:
                        break;
                }
            } while (action != ConsoleKey.Escape);
        }

        void printMainMenu(ref int chooseKey)
        {
            Console.WriteLine("Tables");
            HandleIndex(ref chooseKey, 0, tables.Length - 1);
            for (int i = 0; i < tables.Length; i++)
            {
                if (i == chooseKey)
                {
                    Console.Write("-->");
                }
                Console.WriteLine("\t" + tables[i]);
            }
            Console.WriteLine("Enter - choose table");
        }
        void PrintCollection(IEntityCollection entityCollection, ref int chooseKey)
        {

            ObservableCollection<IEntity> allCollection = entityCollection.GetAll();
                //Console.WriteLine(table.TableName);
            HandleIndex(ref chooseKey, 0, allCollection.Count - 1);

            for (int i = 0; i < allCollection.Count; i++)
            {
                if (i == chooseKey)
                {
                    Console.Write("-->");
                }
                for (int j = 0; j < entityCollection.TableCount; j++)
                {
                    Console.Write("\t" + allCollection[i].GetObjectList()[j]);
                    if (j != entityCollection.TableCount - 1)
                    {
                        Console.Write("\t|");
                    }
                }
                Console.WriteLine();
            }
        }
        void AddItem(Table table)
        {
            string insertValue;
            List<string> insertList = new List<string>();
            for (int i = 0; i < table.GetColumnsLength(); i++)
            {
                Console.Write(table.TableColumns[i] + ":");
                insertValue = Console.ReadLine();
                insertList.Add(insertValue);
            }
            table.AddToRepository(insertList);
        }
        void RemoveItem(Table table, int chooseKey)
        {
            table.RemoveFromTable(chooseKey);
            Console.WriteLine("Item " + chooseKey + " was removed!");
        }
        void SaveTable(Table table)
        {
            //dataBase.UpdateTable(table); 
            Console.WriteLine("Table is saved!");
        }
        void HandleIndex(ref int chooseKey, int min, int max)
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
        void PrintOperations()
        {
            for (int i = 0; i < operations.Length; i++)
            {
                Console.Write(i + 1);
                Console.WriteLine(" - " + operations[i] + "\t");
            }
        }
    }
}