using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalMarks.Models;
using JournalMarks.DataAccess;

namespace JournalMarks.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using(Repository repository = new Repository())
            {
                Person person = new Person()
                {
                    LastName = "Rudenko",
                    FirstName = "Sergey",
                    MiddleName = "Dmitrievich",
                    GenderId = 1
                };
                //repository.SavePerson(person);
                var result = repository.GetPersonById(1);
                Console.WriteLine($"Id: {result.Id}\n" +
                    $"LastName: {result.LastName}\n" +
                    $"FirstName: {result.FirstName}");
            }
            Console.ReadLine();
        }
    }
}
