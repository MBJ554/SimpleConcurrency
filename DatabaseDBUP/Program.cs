using System;
using System.Reflection;
using DbUp;

namespace DatabaseDBUP
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=simpleConcurrency; Integrated Security=true";

            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.WriteLine(result.Error);
                Console.ReadLine();
            }

            Console.WriteLine("Success!");
            Console.ReadLine();
        }
    }
}
