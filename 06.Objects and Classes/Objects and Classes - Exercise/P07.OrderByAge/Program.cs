using System;
using System.Linq;
using System.Collections.Generic;

namespace P07.OrderByAge
{
    internal class Program
    {
        class Person
        {
            public Person(string name, int id, int age)
            {
                this.Name = name;
                this.ID = id;
                this.Age = age;
            }

            public string Name { get; set; }

            public int ID { get; set; }

            public int Age { get; set; }
            public override string ToString()
            {
                return $"{this.Name} with ID: {this.ID} is {this.Age} years old.";
            }
        }
        static void Main(string[] args)
        {
            List<Person> listOfPersons = new List<Person>();


            AddEndOverridePeople(listOfPersons);
            DisplayAllPersonsData(listOfPersons);
        }

        static void AddEndOverridePeople(List<Person> listOfPersons)
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] currPersonData = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string nameToAdd = currPersonData[0];
                int idToAdd = int.Parse(currPersonData[1]);
                int ageToAdd = int.Parse(currPersonData[2]);

                if (listOfPersons.Any(p => p.ID == idToAdd))
                {
                    Person changePersonData = listOfPersons.Find(id => id.ID == idToAdd);

                    changePersonData.Name = nameToAdd;
                    changePersonData.Age = ageToAdd;
                    continue;
                }

                Person personToAdd = new Person(nameToAdd, idToAdd, ageToAdd);
                listOfPersons.Add(personToAdd);
            }
        }
        static void DisplayAllPersonsData(List<Person> listOfPersons)
        {
            foreach (Person person in listOfPersons.OrderBy(p => p.Age))
            {
                Console.WriteLine(person);
            }
        }
    }
}
