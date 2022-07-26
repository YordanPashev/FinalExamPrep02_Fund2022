using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp41
{
    class DepartmentSalaries
    {
        public DepartmentSalaries(string department)
        {
            DepartmentName = department;
            Salary = new List<double>();
        }
        public string DepartmentName { get; set; }
        public List<double> Salary { get; set; } = new List<double>();
    }
    class Employee
    {
        public Employee(string name, double salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }

        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
        public override string ToString()
        {
            return $"{this.Name} {this.Salary:F2}";
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            List<Employee> listOfAllEmployee = new List<Employee>();
            List<DepartmentSalaries> departments = new List<DepartmentSalaries>();
            RegisterAllDepartments(listOfAllEmployee, departments);
            FindDepartmentWithTheHighestAverageSalary(listOfAllEmployee, departments);


        }

        static void RegisterAllDepartments(List<Employee> listOfAllEmployee, List<DepartmentSalaries> departments)
        {

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] employeeData = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .ToArray();
                string name = employeeData[0];
                double salary = double.Parse(employeeData[1]);
                string department = employeeData[2];

                Employee employee = new Employee(name, salary, department);
                listOfAllEmployee.Add(employee);
                GroupEmployesBydepartment(listOfAllEmployee, departments, name, salary, department);
            }
        }

        static void GroupEmployesBydepartment(List<Employee> listOfAllEmployee, List<DepartmentSalaries> departments,
                                              string name, double salary, string department)
        {
            if (departments.Any(d => d.DepartmentName == department))
            {
                DepartmentSalaries departmentToAddSalary = departments.Find(d => d.DepartmentName == department);
                departmentToAddSalary.Salary.Add(salary);
            }

            else
            {
                DepartmentSalaries newDeparmtnet = new DepartmentSalaries(department);
                newDeparmtnet.Salary.Add(salary);
                departments.Add(newDeparmtnet);
            }
        }

        static void FindDepartmentWithTheHighestAverageSalary(List<Employee> listOfAllEmployee, List<DepartmentSalaries> departments)
        {
            double highestAverageSalaryDepartmentSum = 0.00;
            string highestAverageSalaryDepartmentName = string.Empty;

            foreach (DepartmentSalaries department in departments)
            {
                if (department.Salary.Sum() > highestAverageSalaryDepartmentSum)
                {
                    highestAverageSalaryDepartmentSum = department.Salary.Sum();
                    highestAverageSalaryDepartmentName = department.DepartmentName;
                }
            }

            Console.WriteLine($"Highest Average Salary: {highestAverageSalaryDepartmentName}");
            foreach (Employee employee in listOfAllEmployee
                                          .FindAll(e => e.Department == highestAverageSalaryDepartmentName)
                                          .OrderByDescending(e => e.Salary))

            {
                Console.WriteLine(employee);
            }
        }
    }
}
