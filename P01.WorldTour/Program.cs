using System;
using System.Linq;

namespace P01.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Travel")
            {
                string[] cmdArgs = cmd
                    .Split(':')
                    .ToArray();
                string action = cmdArgs[0];

                if (action == "Add Stop")
                {
                    stops = AddLocation(stops, cmdArgs);
                }

                else if (action == "Remove Stop")
                {
                    stops = RemoveLocation(stops, cmdArgs);
                }

                else if (action == "Switch")
                {
                    stops = SwitchLocation(stops, cmdArgs);
                }

                Console.WriteLine(stops);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }

        static string AddLocation(string stops, string[] cmdArgs)
        {
            int index = int.Parse(cmdArgs[1]);

            if (stops.Length > index && index >= 0)
            { 
                string locationToAdd = cmdArgs[2];
                stops = stops.Insert(index, locationToAdd);
            }

            return stops;
        }
        static string RemoveLocation(string stops, string[] cmdArgs)
        {
            int startIndex = int.Parse(cmdArgs[1]);
            int endIndex = int.Parse(cmdArgs[2]);
            int charsCountToRemove = endIndex - startIndex + 1;

            if (stops.Length > startIndex && startIndex >= 0 &&
                stops.Length > endIndex && endIndex >= 0)
            {
                stops = stops.Remove(startIndex, charsCountToRemove);
            }

            return stops;
        }
        static string SwitchLocation(string stops, string[] cmdArgs)
        {
            string oldSubstring = cmdArgs[1];
            string newString = cmdArgs[2];

            if (stops.Contains(oldSubstring))
            {
                stops = stops.Replace(oldSubstring, newString);
            }

            return stops;
        }
    }
}
