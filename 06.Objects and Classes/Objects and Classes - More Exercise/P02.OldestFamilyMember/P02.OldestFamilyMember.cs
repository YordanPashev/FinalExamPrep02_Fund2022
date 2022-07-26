using System;
using System.Linq;
using System.Collections.Generic;


namespace ConsoleApp5
{

    class Family
    {
        public Family()
        {
            FamilyMembers = new List<Person>();
        }
        public List<Person> FamilyMembers  { get; set; }
        public void AddMember(Person person)
        {
            FamilyMembers.Add(person);
        }

        public Person GetOldestMemberOFTheFamily()
        {
            Person oldestMember = FamilyMembers.OrderByDescending(p => p.Age).FirstOrDefault();
            return oldestMember;
        }
    }
    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int familyMembers = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 1; i <= familyMembers; i++)
            {
                string[] memberInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = memberInfo[0];
                int age = int.Parse(memberInfo[1]);
                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Person oldestMember = family.GetOldestMemberOFTheFamily();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");

        }
    }
}
