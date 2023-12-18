using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektuppgift
{
    public class Menu
    {
        private readonly MenuItem[] menuItems;

        public Menu(params MenuItem[] menuItems)
        {
            this.menuItems = menuItems;
        }

        public void Display()
        {
            for (int i = 0; i < menuItems.Length; i++) 
            {
                Console.WriteLine($"{i + 1}. {menuItems[i].Title}");
            }

            Console.WriteLine("0. Exit");
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
