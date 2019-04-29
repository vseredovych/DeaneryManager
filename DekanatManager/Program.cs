using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekanatManager
{
    class LocalDatabase
    {
        static void Main(string[] args)
        {

            //LocalRepositoryMenu menu = new LocalRepositoryMenu();
            ServerRepositoryMenu menu = new ServerRepositoryMenu();

            menu.MainMenu();
            Console.WriteLine("Hello World!");
        }
    }
}
