using System;
using System.Linq;
using System.Collections.Generic;

namespace P04.Students
{
    class Student
    {
        public Student(string FirstName, string LastName, double Grade)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Grade = Grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> listOfAllStudents = new List<Student>();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] currentStudentInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string firstName = currentStudentInfo[0];
                string lastName = currentStudentInfo[1];
                double grade = double.Parse(currentStudentInfo[2]);

                Student student = new Student(firstName, lastName, grade);

                listOfAllStudents.Add(student);
            }

            List<Student> orderByGrade = listOfAllStudents.OrderByDescending(grade => grade.Grade).ToList();

            foreach (Student stud in orderByGrade)
            {
                Console.WriteLine(stud);
            }
        }
    }
}
