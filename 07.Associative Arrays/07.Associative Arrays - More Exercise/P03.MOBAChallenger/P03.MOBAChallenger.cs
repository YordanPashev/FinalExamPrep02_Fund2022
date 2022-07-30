using System;
using System.Linq;
using System.Collections.Generic;

namespace MOBAChallenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> pool = new Dictionary<string, Dictionary<string, int>>();
            string input;

            while ((input = Console.ReadLine()) != "Season end")
            {
                string[] cmdArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (cmdArgs.Length == 5)
                {
                    AddNewData(pool, cmdArgs);
                }

                else
                {
                    TryMakeADuel(pool, cmdArgs);
                }
            }

            DisplayAllPlayersInThePool(pool);
        }

        static void AddNewData(Dictionary<string, Dictionary<string, int>> pool, string[] cmdArgs)
        {
            string playerName = cmdArgs[0];
            string position = cmdArgs[2];
            int skill = int.Parse(cmdArgs[4]);

            if (!pool.ContainsKey(playerName))
            {
                Dictionary<string, int> curPlayerPositionAndSkill = new Dictionary<string, int>()
                {
                    {position, skill }
                };
                pool.Add(playerName, curPlayerPositionAndSkill);
            }

            else
            {
                if (!pool[playerName].ContainsKey(position))
                {
                    pool[playerName].Add(position, skill);
                }

                else if (pool[playerName][position] < skill)
                {
                    pool[playerName][position] = skill;
                }
            }
        }

        static void TryMakeADuel(Dictionary<string, Dictionary<string, int>> pool, string[] cmdArgs)
        {
            string firstPlayerName = cmdArgs[0];
            string secondPlayerName = cmdArgs[2];
            bool hasCommonPosition = false;

            if (pool.ContainsKey(firstPlayerName) && pool.ContainsKey(secondPlayerName))
            {
                foreach (var firstPlayerPosition in pool[firstPlayerName])
                {
                    string firstplayerPossition = firstPlayerPosition.Key;

                    if (pool[secondPlayerName].ContainsKey(firstplayerPossition))
                    {
                        hasCommonPosition = true;
                    }
                }

                if (hasCommonPosition)
                {
                    Fight(pool, firstPlayerName, secondPlayerName);
                }
            }
        }

        static void Fight(Dictionary<string, Dictionary<string, int>> pool, string firstPlayerName, string secondPLayerName)
        {
            int playerOneTotalSkillPoints = CalculateTotalPoints(pool, firstPlayerName);
            int playerTwoTotalSkillPoints = CalculateTotalPoints(pool, secondPLayerName);

            if (playerTwoTotalSkillPoints > playerOneTotalSkillPoints)
            {
                pool.Remove(firstPlayerName);
            }

            else if (playerOneTotalSkillPoints > playerTwoTotalSkillPoints)
            {
                pool.Remove(secondPLayerName);
            }

            else if (playerOneTotalSkillPoints == playerTwoTotalSkillPoints)
            {
                return;
            }
        }

        static int CalculateTotalPoints(Dictionary<string, Dictionary<string, int>> pool, string playerName)
        {
            int totalSkillPoints = 0;

            foreach (var position in pool[playerName])
            {
                int currPossitionPoints = position.Value;
                totalSkillPoints += currPossitionPoints;
            }

            return totalSkillPoints;
        }

        static void DisplayAllPlayersInThePool(Dictionary<string, Dictionary<string, int>> pool)
        {
            Dictionary<string, int> totalPointsOfAllPlayers = new Dictionary<string, int>();

            foreach (var playerData in pool)
            {
                string playerName = playerData.Key;
                int currPlayerTotalPoints = CalculateTotalPoints(pool, playerName);
                totalPointsOfAllPlayers.Add(playerName, currPlayerTotalPoints);
            }

            foreach (var playerTotalPoints in totalPointsOfAllPlayers.OrderByDescending(p => p.Value))
            {
                string playerName = playerTotalPoints.Key;
                int totalPoints = playerTotalPoints.Value;
                Console.WriteLine($"{playerName}: {totalPoints} skill");

                foreach (var position in pool[playerName].OrderByDescending(p => p.Value).ThenBy(p => p.Key))
                {
                    string playerPostion = position.Key;
                    int positionSkill = position.Value;
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }
    }
}

