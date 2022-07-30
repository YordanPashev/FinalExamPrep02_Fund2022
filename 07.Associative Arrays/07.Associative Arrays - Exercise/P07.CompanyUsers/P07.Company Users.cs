using System;
using System.Linq;
using System.Collections.Generic;

namespace P08.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string cmd;

            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currCommpanyName = cmdArgs[0];
                string currEmployeeId = cmdArgs[1];

                if (companies.ContainsKey(currCommpanyName))
                {
                    if (!companies[currCommpanyName].Contains(currEmployeeId))
                    {
                        companies[currCommpanyName].Add(currEmployeeId);
                    }
                }

                else
                {
                    companies[currCommpanyName] = new List<string>();
                    companies[currCommpanyName].Add(currEmployeeId);
                }
            }

            DisplayAllCompaniesAndTheirEmployees(companies);
        }

        static void DisplayAllCompaniesAndTheirEmployees(Dictionary<string, List<string>> companies)
        {

            foreach (var course in companies)
            {
                string companyName = course.Key;
                List<string> listOfAllEmployeesId = course.Value;

                Console.WriteLine($"{companyName}");

                foreach (var emplyeeId in listOfAllEmployeesId)
                {
                    Console.WriteLine($"-- {emplyeeId}");
                }
            }
        }
    }
}
