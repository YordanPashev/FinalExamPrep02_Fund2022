using System;
using System.Linq;
using System.Collections.Generic;

namespace P05.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int usersCount = int.Parse(Console.ReadLine());
            Dictionary<string, string> users = new Dictionary<string, string>();

            for (int us = 1; us <= usersCount; us++)
            {
                string[] cmdArg = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string action = cmdArg[0];

                if (action == "register")
                {
                    TryToResgisterateCurrCar(users, cmdArg);
                }

                else if (action == "unregister")
                {
                    TryToUnresgisterateCurrCar(users, cmdArg);
                }
            }

            DisplayAllResitratedUsers(users);
        }

        static void TryToResgisterateCurrCar(Dictionary<string, string> users, string[] cmdArg)
        {
            string userName = cmdArg[1];
            string licensePlateNumber = cmdArg[2];

            if (users.ContainsKey(userName))
            {
                Console.WriteLine($"ERROR: already registered with plate number {users[userName]}");
            }

            else
            {
                Console.WriteLine($"{userName} registered {licensePlateNumber} successfully");
                users.Add(userName, licensePlateNumber);
            }
        }

        static void TryToUnresgisterateCurrCar(Dictionary<string, string> users, string[] cmdArg)
        {
            string userName = cmdArg[1];

            if (!users.ContainsKey(userName))
            {
                Console.WriteLine($"ERROR: user {userName} not found");
            }

            else
            {
                Console.WriteLine($"{userName} unregistered successfully");
                users.Remove(userName);
            }
        }

        static void DisplayAllResitratedUsers(Dictionary<string, string> users)
        {
            foreach (var user in users)
            {
                string userName = user.Key;
                string licensePlateNumber = user.Value;
                Console.WriteLine($"{userName} => {licensePlateNumber}");
            }
        }
    }
}
