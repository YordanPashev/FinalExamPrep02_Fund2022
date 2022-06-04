using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.Students2._0
{
    class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            List<Students> listOfStudents = new List<Students>();

            string input = Console.ReadLine();
            string[] data = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            string currentStudentFirstName = data[0];
            string currentStudentLastName = data[1];
            int currentStudentAge = int.Parse(data[2]);
            string currentStudentHomeTownName = data[3];

            Students currentStudenInformation = new Students()
            {
                FirstName = currentStudentFirstName,
                LastName = currentStudentLastName,
                Age = currentStudentAge,
                HomeTown = currentStudentHomeTownName
            };

            listOfStudents.Add(currentStudenInformation);

            while ((input = Console.ReadLine()) != "end")
            {
                data = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                currentStudentFirstName = data[0];
                currentStudentLastName = data[1];
                currentStudentAge = int.Parse(data[2]);
                currentStudentHomeTownName = data[3];

                currentStudenInformation = new Students()
                {
                    FirstName = currentStudentFirstName,
                    LastName = currentStudentLastName,
                    Age = currentStudentAge,
                    HomeTown = currentStudentHomeTownName
                };

                bool IsAlreadyInTheList = CheckIfCurrentNameAlreadyExistInTheList(listOfStudents, currentStudentFirstName, currentStudentLastName);

                if (!IsAlreadyInTheList)
                {
                    listOfStudents.Add(currentStudenInformation);
                }

                else
                {
                    ChangeCurrentStudentAge(listOfStudents, currentStudentAge,
                    currentStudentFirstName, currentStudentLastName);
                }

            }

            string nameOfTowToSearch = Console.ReadLine();

            List<Students> filteredStudentsByPlace = listOfStudents.FindAll(s => s.HomeTown == nameOfTowToSearch);

            foreach (Students student in filteredStudentsByPlace)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }

        }

        static bool CheckIfCurrentNameAlreadyExistInTheList(List<Students> listOfStudents,
                       string currentStudentFirstName, string currentStudentLastName)
        {
            bool isAlreadyExist = false;

            foreach (var student in listOfStudents)
            {
                if (student.FirstName == currentStudentFirstName
                    && student.LastName == currentStudentLastName)
                {
                    isAlreadyExist = true;
                }
            }

            return isAlreadyExist;
        }

        static void ChangeCurrentStudentAge(List<Students> listOfStudents, int currentStudentAge,
                       string currentStudentFirstName, string currentStudentLastName)
        {
            for (int i = 0; i < listOfStudents.Count; i++)
            {
                if (listOfStudents[i].FirstName == currentStudentFirstName &&
                    listOfStudents[i].LastName == currentStudentLastName)
                {
                    listOfStudents[i].Age = currentStudentAge;
                }
            }
        }
    }
}


