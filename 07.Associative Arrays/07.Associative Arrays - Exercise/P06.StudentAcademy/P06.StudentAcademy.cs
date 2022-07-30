using System;
using System.Linq;
using System.Collections.Generic;

namespace P07.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int numberOfStudents = int.Parse(Console.ReadLine());

            for (int st = 1; st <= numberOfStudents; st++)
            {
                string currStudentName = Console.ReadLine();
                double currSutdentGrade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(currStudentName))
                {
                    students[currStudentName].Add(currSutdentGrade);
                }

                else
                {
                    students.Add(currStudentName, new List<double>());
                    students[currStudentName].Add(currSutdentGrade);
                }
            }

            double minAverageGrade = 4.5;
            PrintAllStudentsAboveTheAverageGrade(students, minAverageGrade);
        }

        static void PrintAllStudentsAboveTheAverageGrade(Dictionary<string, List<double>> students, double minAverageGrade)
        {
            foreach (var student in students)
            {
                string studentName = student.Key;
                double gradesCount = student.Value.Count;
                double sumOfAllGrades = student.Value.Sum();
                double averageStudentGrade = sumOfAllGrades / gradesCount;

                if (averageStudentGrade >= minAverageGrade)
                {
                    Console.WriteLine($"{studentName} -> {averageStudentGrade:F2}");
                }
            }
        }
    }
}
