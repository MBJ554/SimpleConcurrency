using SimpleConcurrency.DAL;
using SimpleConcurrency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConcurrency
{
    class Program
    {
        public static CustomerRepository customerRepository { get; set; }
        public static Customer customer { get; set; }

        static void Main(string[] args)
        {
            customerRepository = new CustomerRepository();
            MainMenu();
        }

        public static void MainMenu()
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
                Console.Clear();
                GetCustomerMenu();
            }
        }

        private static void GetCustomerMenu()
        {
            Console.WriteLine("Please enter the id of the customer you want to update!");
         
            customer = customerRepository.GetById(ReadNumber());

            if (customer == null)
            {
                Console.Clear();
                Console.WriteLine("No customer with that id.");
                Console.WriteLine("Please try again!\n\n");
                GetCustomerMenu();
            }
          
            Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Phone: {customer.Phone}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Birthday: {customer.Birthday.ToShortDateString()}");

            Console.WriteLine(
                "(1) Update Customer \n" +
                "(0) Back");

            var selectedOption = ReadNumber();
            while (selectedOption < 0 || selectedOption > 1)
            {
                Console.WriteLine("Please enter a valid number!");
                selectedOption = ReadNumber();
            }
            if (selectedOption == 1)
            {
                Console.Clear();
                UpdateCustomerMenu();
            }
            else
            {
                Console.Clear();
                MainMenu();
            }
        }

        private static void UpdateCustomerMenu()
        {
            Console.WriteLine("Please enter the new birthday!");
            DateTime date;

            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("You need to enter a date with the format dd-mm-yyyy!");
                Console.WriteLine("Please try again!");
            }

            customer.Birthday = date;

            try
            {
                customerRepository.UpdateCustomer(customer);
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($"ERROR: {e.Message}");
                Console.WriteLine("Please try again!\n\n");
                GetCustomerMenu();
            }

            Console.Clear();
            Console.WriteLine("Success!\n\n");
            MainMenu();
        }

        private static int ReadNumber()
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
