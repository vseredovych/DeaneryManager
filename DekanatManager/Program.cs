using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu.Concrete.MainMenu;

namespace DekanatManager
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            menu.StartMenu();
            Console.WriteLine("Hello World!");
        }
    }
}
