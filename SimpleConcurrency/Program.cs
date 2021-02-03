using SimpleConcurrency.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConcurrency
{
    class Program
    {
        public CustomerRepository customerRepository { get; set; }
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            customerRepository = new CustomerRepository();
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
            Console.WriteLine("Please enter the id of the customer you want to update!");
            var customer = customerRepository.GetById(ReadNumber());
            Console.WriteLine("Name: " + customer.FirstName + " " + customer.LastName);
            Console.WriteLine("Phone: " + customer.Phone);
            Console.WriteLine("Please enter a new birthdate.");
            customer.Birthday = DateTime.Parse(Console.ReadLine());
            customerRepository.UpdateCustomer(customer);
            Console.ReadLine();
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
