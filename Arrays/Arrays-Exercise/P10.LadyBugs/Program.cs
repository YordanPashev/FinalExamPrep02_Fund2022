using System;
using System.Linq;

namespace P10.LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {

            {
                int fieldSize = int.Parse(Console.ReadLine());
                int[] indexLedybug = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int[] ladybugOnFiejd = new int[fieldSize];

                for (int i = 0; i < indexLedybug.Length; i++)
                {
                    if (indexLedybug[i] >= fieldSize || indexLedybug[i] < 0)
                    {
                        continue;
                    }
                    else
                    {
                        for (int j = 0; j < fieldSize; j++)
                        {
                            if (indexLedybug[i] == j)
                            {
                                ladybugOnFiejd[j] = 1;
                            }
                        }
                    }

                }

                string command = Console.ReadLine();

                while (command != "end")
                {
                    string[] input = command
                    .Split(' ');
                    int ladybugOnMove = int.Parse(input[0]);
                    string direction = input[1];
                    int move = int.Parse(input[2]);

                    if (ladybugOnMove < 0 ||
                        ladybugOnMove > fieldSize - 1 ||
                        ladybugOnFiejd[ladybugOnMove] == 0 ||
                        move == 0)
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    else
                    {
                        if ((direction == "left" && move > 0) || (move < 0 && input[1] == "right"))
                        {
                            int movingPosition = ladybugOnMove - move;
                            ladybugOnFiejd[ladybugOnMove] = 0;
                            if (movingPosition < 0)
                            {
                                command = Console.ReadLine();
                                continue;

                            }
                            for (int i = movingPosition; i >= 0; i -= move)
                            {
                                if (i < 0 || i > fieldSize - 1)
                                {
                                    break;

                                }
                                else if (ladybugOnFiejd[i] == 0)
                                {

                                    ladybugOnFiejd[i] = 1;
                                    break;
                                }
                            }
                        }
                        else if ((direction == "right" && move > 0) || (move < 0 && input[1] == "left"))
                        {
                            int movingPosition = move + ladybugOnMove;
                            ladybugOnFiejd[ladybugOnMove] = 0;

                            if (movingPosition > fieldSize - 1)
                            {
                                command = Console.ReadLine();
                                continue;
                            }
                            else
                            {
                                for (int j = movingPosition; j <= fieldSize; j += move)
                                {
                                    if (j > fieldSize - 1 || j < 0)
                                    {
                                        break;
                                    }
                                    else if (ladybugOnFiejd[j] == 0)
                                    {
                                        ladybugOnFiejd[j] = 1;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    command = Console.ReadLine();
                }

                Console.WriteLine(String.Join(" ", ladybugOnFiejd));
            }
        }
    }
}




