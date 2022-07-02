using System;
using System.Linq;

namespace P02.Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] racingTrack = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int finishIndex = racingTrack.Length / 2;

            double leftRacerTime = CalculateLeftRaceTime(racingTrack, finishIndex);
            double rightRacerTime = CalculateRightRaceTime(racingTrack, finishIndex);


            if (leftRacerTime < rightRacerTime)
            {
                Console.WriteLine($"The winner is left with total time: {leftRacerTime.ToString("0.####")}");
            }

            else
            {
                Console.WriteLine($"The winner is right with total time: {rightRacerTime.ToString("0.####")}");
            }
        }

        static double CalculateLeftRaceTime(int[] racingTrack, int finishIndex)
        {
            double leftRacerTime = 0;

            for (int i = 0; i < finishIndex; i++)
            {
                if (racingTrack[i] == 0)
                {
                    leftRacerTime *= 0.8;
                    continue;
                }

                leftRacerTime += racingTrack[i];
            }

            return leftRacerTime;
        }

        static double CalculateRightRaceTime(int[] racingTrack, int finifshIndex)
        {
            double rightRacerTime = 0;

            for (int i = racingTrack.Length - 1; i > finifshIndex; i--)
            {
                if (racingTrack[i] == 0)
                {
                    rightRacerTime *= 0.8;
                    continue;
                }

                rightRacerTime += racingTrack[i];
            }

            return rightRacerTime;
        }
    }
}