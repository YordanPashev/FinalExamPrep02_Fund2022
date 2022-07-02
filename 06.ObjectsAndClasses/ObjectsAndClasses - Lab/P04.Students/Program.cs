using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Students
{
    class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }


    }
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Students> listOfStudents = new List<Students>();

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] data = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string studentsFirstName = data[0];
                string studentsLastName = data[1];
                int studentsAge = int.Parse(data[2]);
                string homeTownName = data[3];

                Students currentStudenInformation = new Students()
                {
                    FirstName = studentsFirstName,
                    LastName = studentsLastName,
                    Age = studentsAge,
                    HomeTown = homeTownName
                };

                listOfStudents.Add(currentStudenInformation);
            }

            string nameOfTowToSearch = Console.ReadLine();

            List<Students> filteredStudentsByPlace = listOfStudents.FindAll(s => s.HomeTown == nameOfTowToSearch);

            foreach (Students student in filteredStudentsByPlace)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
}
