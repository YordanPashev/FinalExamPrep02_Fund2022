using System;
using System.Linq;
using System.Collections.Generic;

namespace Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> studentResults = new Dictionary<string, Dictionary<string, int>>();

            string input;

            while ((input = Console.ReadLine()) != "no more time")
            {
                ProccessInputLine(studentResults, input);
            }

            DisplayContestResults(studentResults);

            DisplayIndividualResults(studentResults);
        }

        static void ProccessInputLine(Dictionary<string, Dictionary<string, int>> studentResults, string input)
        {
            string[] currResult = input
                        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
            string userName = currResult[0];
            string currContestName = currResult[1];
            int currPointFotTHeContest = int.Parse(currResult[2]);

            if (!studentResults.ContainsKey(currContestName))
            {
                Dictionary<string, int> currStudentContestResult = new Dictionary<string, int>();
                currStudentContestResult.Add(userName, currPointFotTHeContest);
                studentResults.Add(currContestName, currStudentContestResult);
            }

            else
            {
                if (!studentResults[currContestName].ContainsKey(userName))
                {
                    studentResults[currContestName].Add(userName, currPointFotTHeContest);
                }

                else
                {
                    if (studentResults[currContestName][userName] < currPointFotTHeContest)
                    {
                        studentResults[currContestName][userName] = currPointFotTHeContest;
                    }
                }
            }
        }

        static void DisplayContestResults(Dictionary<string, Dictionary<string, int>> studentResults)
        {
            foreach (var student in studentResults)
            {
                string currContestName = student.Key;
                var contestResults = student.Value;

                Console.WriteLine($"{currContestName}: {contestResults.Count} participants");

                int position = 1;

                foreach (var user in contestResults.OrderByDescending(p => p.Value).ThenBy(n => n.Key))
                {
                    string userName = user.Key;
                    int points = user.Value;

                    Console.WriteLine($"{position}. {userName} <::> {points}");
                    position++;
                }
            }
        }

        static void DisplayIndividualResults(Dictionary<string, Dictionary<string, int>> studentResults)
        {
            Dictionary<string, int> individualResults = new Dictionary<string, int>();

            CalculateEachStudentResult(studentResults, individualResults);

            Console.WriteLine("Individual standings:");

            int position = 1;

            foreach (var student in individualResults.OrderByDescending(p => p.Value).ThenBy(n => n.Key))
            {
                string studentName = student.Key;
                int totalPoints = student.Value;
                Console.WriteLine($"{position}. {studentName} -> {totalPoints}");
                position++;
            }
        }

        static void CalculateEachStudentResult(Dictionary<string, Dictionary<string, int>> studentResults, Dictionary<string, int> individualResults)
        {
            foreach (var contest in studentResults)
            {
                foreach (var student in contest.Value)
                {
                    string currStudentName = student.Key;
                    int currStudentPoints = student.Value;

                    if (!individualResults.ContainsKey(currStudentName))
                    {
                        individualResults.Add(currStudentName, currStudentPoints);
                    }

                    else
                    {
                        individualResults[currStudentName] += currStudentPoints;
                    }
                }
            }
        }
    }
}
