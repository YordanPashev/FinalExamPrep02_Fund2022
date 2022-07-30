using System;
using System.Linq;
using System.Collections.Generic;

namespace P06.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string cmd;

            while ((cmd = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = cmd
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string currCourseName = cmdArgs[0];
                string studentName = cmdArgs[1];

                if (courses.ContainsKey(currCourseName))
                {
                    courses[currCourseName].Add(studentName);
                }

                else
                {
                    courses.Add(currCourseName, new List<string>());
                    courses[currCourseName].Add(studentName);
                }
            }

            DisplayAllCoursesAndTheirStudents(courses);
        }

        static void DisplayAllCoursesAndTheirStudents(Dictionary<string, List<string>> courses)
        {

            foreach (var course in courses)
            {
                string currCourseName = course.Key;
                List<string> listOfStudentsInCurrCourse = course.Value;
                int numberOfStudents = course.Value.Count;

                Console.WriteLine($"{currCourseName}: {numberOfStudents}");

                foreach (var studentName in listOfStudentsInCurrCourse)
                {
                    Console.WriteLine($"-- {studentName}");
                }
            }
        }
    }
}
