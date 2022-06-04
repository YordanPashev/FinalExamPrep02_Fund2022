using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Songs
{
    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

    }
    internal class Program
    {

        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> listOfSongs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                List<string> input = Console.ReadLine()
                    .Split('_')
                    .ToList();

                Song currentSong = new Song()
                {
                    TypeList = input[0],
                    Name = input[1],
                    Time = input[2]
                };

                listOfSongs.Add(currentSong);
            }


            string printCmd = Console.ReadLine();

            if (printCmd == "all")
            {
                foreach (var song in listOfSongs)
                {
                    Console.WriteLine(song.Name);
                }
            }

            else
            {
                string typeListTosearch = printCmd;

                List<Song> filteredSong = listOfSongs.FindAll(song => song.TypeList == typeListTosearch).ToList();

                foreach (var song in filteredSong)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}



