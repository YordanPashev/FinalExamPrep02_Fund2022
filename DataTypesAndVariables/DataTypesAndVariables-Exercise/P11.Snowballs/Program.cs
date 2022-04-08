using System;
using System.Numerics;

namespace P11.Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int snowBallsAmount = int.Parse(Console.ReadLine());
            BigInteger highestScore = -1;
            int highestScoreOFSnowBallSnow = 0;
            int highestScoreOFSnowBallTime = 0;
            BigInteger highestScoreOfSnowBallQuality = 0;

            for (int i = 0; i < snowBallsAmount; i++)
            {
                int snowBallSnow = int.Parse(Console.ReadLine());
                int snowBallTime = int.Parse(Console.ReadLine());
                int snowBallQuality = int.Parse(Console.ReadLine());
                BigInteger score = BigInteger.Pow((snowBallSnow / snowBallTime), snowBallQuality);

                if (highestScore < score)
                {
                    highestScore = score;
                    highestScoreOFSnowBallSnow = snowBallSnow;
                    highestScoreOFSnowBallTime = snowBallTime;
                    highestScoreOfSnowBallQuality = snowBallQuality;
                }
            }
            Console.WriteLine($"{highestScoreOFSnowBallSnow} : {highestScoreOFSnowBallTime} = {highestScore} ({highestScoreOfSnowBallQuality})");
        }
    }
}
