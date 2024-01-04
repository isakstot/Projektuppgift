using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projektuppgift
{
    public class Menu
    {
        private readonly MenuItem[] menuItems;

        private readonly string title;

        public Menu(string title, params MenuItem[] menuItems)
        {
            this.title = title;
            this.menuItems = menuItems;
        }

        public void Display()
        {
            Console.Clear();
            for (int i = 0; i < menuItems.Length; i++) 
            {
                Console.WriteLine($"{i + 1}. {menuItems[i].Title}");
            }
            if (title == "Main menu")
            { 
                Console.WriteLine("0. Exit");
            }
            else
            {
                Console.WriteLine("0. Back to main menu");
            }
        }

        public void Run() 
        {
            while (true)
            {
                Display();

                Console.Write("Pick an option: ");

                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input == 0) 
                    {
                        break;
                    }
                    else if (input <= menuItems.Length && input > 0)
                    {
                        menuItems[input - 1].Action.Invoke();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please try again.");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            }
        }
    }
}
