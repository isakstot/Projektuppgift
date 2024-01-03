using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektuppgift
{
    public class Utility
    {
        public void WaitForInput()
        {
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
        }
        public int? GetNumericInput(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            if (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return null;
            }

            return result;
        }

        public string GetStringInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                Console.Clear();
            }
        }
    }
}
