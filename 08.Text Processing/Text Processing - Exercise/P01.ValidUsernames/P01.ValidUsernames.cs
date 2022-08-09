using System;
using System.Linq;
using System.Collections.Generic;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] userNamesList = input
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for(int i = 0; i < userNamesList.Length; i++)
            {
                bool isUserNameValid = true;

                string currUserName = userNamesList[i];

                if (currUserName.Length >= 3 && currUserName.Length <= 16)
                {
                    foreach (char ch in currUserName)
                    {
                        if (!char.IsLetterOrDigit(ch) && ch != '-' && ch != '_')
                        {
                            isUserNameValid = false;
                            break;
                        }
                    }
                }

                else
                {
                    isUserNameValid = false;
                }

                if (isUserNameValid)
                {
                    Console.WriteLine(currUserName);
                }
            }
        }
    }
}