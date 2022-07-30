using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> candidateResults = new Dictionary<string, Dictionary<string, int>>();

            RegistrateAllContests(contests);

            GetAllResultsFromSubmission(contests, candidateResults);

            string[] bestCandidatenAndHisResult = FindBestCandidate(candidateResults);

            DisplayOtherCandidateResults(candidateResults, bestCandidatenAndHisResult);
        }

        static void RegistrateAllContests(Dictionary<string, string> contests)
        {
            string input;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] contestARgs = input
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string contestName = contestARgs[0];
                string contestPassword = contestARgs[1];

                contests.Add(contestName, contestPassword);
            }
        }
        static void GetAllResultsFromSubmission(Dictionary<string, string> contests,
                                                Dictionary<string, Dictionary<string, int>> candidateResults)
        {
            string input;

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] submissionArgs = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string contestName = submissionArgs[0];
                string userPassword = submissionArgs[1];
                string candidatename = submissionArgs[2];
                int candidatePoints = int.Parse(submissionArgs[3]);

                if (contests.ContainsKey(contestName))
                {
                    if (IsPasswordValid(contests, submissionArgs))
                    {
                        if (!candidateResults.ContainsKey(candidatename))
                        {
                            AddNewUserData(candidateResults, contestName, candidatename, candidatePoints);
                        }

                        else
                        {
                            AddThePointsToCurrUser(candidateResults, contestName, candidatename, candidatePoints);
                        }
                    }
                }
            }
        }

        static bool IsPasswordValid(Dictionary<string, string> contests, string[] submissionArgs)
        {
            string contestName = submissionArgs[0];
            string candidatePassword = submissionArgs[1];

            foreach (var contest in contests.Where(c => c.Key == contestName))
            {
                string contestPassword = contest.Value;
                if (contestPassword == candidatePassword)
                {
                    return true;
                }
            }

            return false;
        }

        static void AddNewUserData(Dictionary<string, Dictionary<string, int>> candidateResults,
                                   string contestName, string candidateName, int candidatePoints)
        {
            Dictionary<string, int> userInfo = new Dictionary<string, int>()
            {
                 {contestName, candidatePoints}
            };

            candidateResults.Add(candidateName, userInfo);
        }

        static void AddThePointsToCurrUser(Dictionary<string, Dictionary<string, int>> candidateResults,
                                           string contestName, string candidateName, int candidatePoints)
        {
            if (candidateResults[candidateName].ContainsKey(contestName))
            {
                if (candidateResults[candidateName][contestName] < candidatePoints)
                {
                    candidateResults[candidateName][contestName] = candidatePoints;
                }
            }

            else
            {
                candidateResults[candidateName].Add(contestName, candidatePoints);
            }
        }

        static string[] FindBestCandidate(Dictionary<string, Dictionary<string, int>> candidateResults)
        {
            int bestResult = 0;
            string candidateName = string.Empty;
            string[] bestCandidatenAndHisResult = new string[2];

            foreach (var candidate in candidateResults)
            {
                candidateName = candidate.Key;
                int currCandidatePoints = 0;

                foreach (var personalResult in candidate.Value)
                {
                    currCandidatePoints += personalResult.Value;
                }

                if (currCandidatePoints > bestResult)
                {
                    bestCandidatenAndHisResult[0] = candidateName;
                    bestCandidatenAndHisResult[1] = currCandidatePoints.ToString();
                    bestResult = currCandidatePoints;
                }
            }

            return bestCandidatenAndHisResult;
        }

        static void DisplayOtherCandidateResults(Dictionary<string, Dictionary<string, int>> candidateResults, string[] bestCandidatenAndHisResult)
        {
            string bestCandidateName = bestCandidatenAndHisResult[0];
            int bestCandidatePoints = int.Parse(bestCandidatenAndHisResult[1]);
            Console.WriteLine($"Best candidate is {bestCandidateName} with total {bestCandidatePoints} points.");

            Console.WriteLine("Ranking:");

            foreach (var candidate in candidateResults.OrderBy(n => n.Key))
            {
                Console.WriteLine(candidate.Key);

                foreach (var contestPoint in candidate.Value.OrderByDescending(g => g.Value))
                {
                    string contestName = contestPoint.Key;
                    int contestPointPoints = contestPoint.Value;
                    Console.WriteLine($"#  {contestName} -> {contestPointPoints}");
                }
            }
        }
    }
}


