using System;
using System.Linq;
using System.Collections.Generic;

namespace P05.TeamworkProjects
{
    internal class Program
    {
        class Team
        {
            public Team(string TeamName, string Founder)
            {
                this.TeamName = TeamName;
                this.Founder = Founder;
            }
            public Team()
            {
                this.TeamName = TeamName;
                this.Founder = Founder;
                this.Members = new List<string>();
            }
            public string TeamName { get; set; }
            public string Founder { get; set; }
            public List<string> Members { get; set; } = new List<string>();
        }
        static void Main(string[] args)
        {
            List<Team> listOfAllTeams = new List<Team>();
            Team team = new Team();

            CreateNewTeams(listOfAllTeams, team);

            AddNewMembers(listOfAllTeams);

            DisplayAllTeamAndMember(listOfAllTeams);
        }
        static void CreateNewTeams(List<Team> listOfAllTeams, Team team)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfTeams; i++)
            {
                string[] newTeamInfo = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string creator = newTeamInfo[0];
                string teamName = newTeamInfo[1];

                if (CheckIfTeamAlreadyExist(listOfAllTeams, teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (CheckIFUserIsAlreadyInATeam(listOfAllTeams, creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                team = new Team(teamName, creator);
                listOfAllTeams.Add(team);

                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }
        }
        static bool CheckIfTeamAlreadyExist(List<Team> listOfAllTeams, string newteamName)
        {
            bool isAlreadyExist = listOfAllTeams.Any(tname => tname.TeamName == newteamName);
            return isAlreadyExist;
        }
        static bool CheckIFUserIsAlreadyInATeam(List<Team> listOfAllTeams, string user)
        {
            bool isAlaedyFoundATeam = listOfAllTeams.Any(name => name.Founder == user) ||
                                      listOfAllTeams.Any(name => name.Members.Contains(user));
            return isAlaedyFoundATeam;
        }
        static void AddNewMembers(List<Team> listOfAllTeams)
        {
            string cmd = string.Empty;

            while ((cmd = Console.ReadLine()) != "end of assignment")
            {
                string[] cmdArgs = cmd
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currentStudentName = cmdArgs[0];
                string chosenTeamName = cmdArgs[1];

                if (!CheckIfTeamAlreadyExist(listOfAllTeams, chosenTeamName))
                {
                    Console.WriteLine($"Team {chosenTeamName} does not exist!");
                    continue;
                }

                if (CheckIFUserIsAlreadyInATeam(listOfAllTeams, currentStudentName))
                {
                    Console.WriteLine($"Member {currentStudentName} cannot join team {chosenTeamName}!");
                    continue;
                }

                int chosenTeamIndex = listOfAllTeams.FindIndex(teamName => teamName.TeamName == chosenTeamName);
                listOfAllTeams[chosenTeamIndex].Members.Add(currentStudentName);
            }
        }
        static void DisplayAllTeamAndMember(List<Team> listOfAllTeams)
        {
            IEnumerable<Team> disbanedTeamNames = listOfAllTeams
                                                  .FindAll(x => x.Members.Count == 0);
            disbanedTeamNames = disbanedTeamNames.OrderBy(x => x.TeamName).ToList();

            listOfAllTeams.RemoveAll(x => x.Members.Count == 0);
            listOfAllTeams = listOfAllTeams
                            .OrderByDescending(x => x.Members.Count)
                            .ThenBy(x => x.TeamName)
                            .ToList();

            foreach (Team curTeam in listOfAllTeams)
            {
                curTeam.Members.Sort();
                Console.WriteLine(curTeam.TeamName);
                Console.WriteLine($"- {curTeam.Founder}");
                foreach (var member in curTeam.Members)
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (Team curTeam in disbanedTeamNames)
            {
                Console.WriteLine(curTeam.TeamName);
            }
        }
    }
}

