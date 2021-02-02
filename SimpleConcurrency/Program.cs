using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConcurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            Console.WriteLine("Welcome to optimistic concurrency control when updating a customer");
            Console.WriteLine("Please select an option from the menu");
            Console.WriteLine(
                "(1) Update Customer \n" +
                "(0) Exit");

            var selectedOption = ReadNumber();
            while (selectedOption < 0 || selectedOption > 1)
            {
                Console.WriteLine("Please enter a valid number!");
                selectedOption = ReadNumber();
            }
            if (selectedOption == 1)
            {
                updateCustomer();
            }

        }

        private void updateCustomer()
        {
            
        }

        private int ReadNumber()
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("You need to enter a number!");
                Console.WriteLine("Please try again!");
            }

            return number;
        }
    }
}
