using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.ThePianist
{
    class Piece
    {
        public Piece(string name, string composer, string key)
        {
            this.Name = name;
            this.Composer = composer;
            this.Key = key;
        }
        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPieces = int.Parse(Console.ReadLine());

            List<Piece> listOfPiece = GetAllPieces(numberOfPieces);

            string cmd;
            while ((cmd = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = cmd
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = cmdArgs[0];

                if (action == "Add")
                {
                    TryToAddNewPiece(listOfPiece, cmdArgs);
                }

                else if (action == "Remove")
                {
                    TryToRemove(listOfPiece, cmdArgs);
                }

                else if (action == "ChangeKey")
                {
                    TryToChangeKey(listOfPiece, cmdArgs);
                }
            }

            DisplayAllPieces(listOfPiece);
        }

        static List<Piece> GetAllPieces(int numberOfPieces)
        {
            List<Piece> listOfPiece = new List<Piece>();

            for (int i = 0; i < numberOfPieces; i++)
            {
                string[] newPieceInfo = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = newPieceInfo[0];
                string composer = newPieceInfo[1];
                string key = newPieceInfo[2];

                Piece pieceToAdd = new Piece(name, composer, key);
                listOfPiece.Add(pieceToAdd);
            }

            return listOfPiece;
        }

        static void TryToAddNewPiece(List<Piece> listOfPiece, string[] cmdArgs)
        {
            string piece = cmdArgs[1];
            string composer = cmdArgs[2];
            string key = cmdArgs[3];

            if (listOfPiece.Any(p => p.Name == piece))
            {
                Console.WriteLine($"{piece} is already in the collection!");
            }

            else
            {
                Piece newPieceToAdd = new Piece(piece, composer, key);
                listOfPiece.Add(newPieceToAdd);
                Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
            }

        }

        static void TryToRemove(List<Piece> listOfPiece, string[] cmdArgs)
        {
            string piece = cmdArgs[1];

            if (!listOfPiece.Any(p => p.Name == piece))
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }

            else
            {
                Piece pieceToRemove = listOfPiece.Find(p => p.Name == piece);
                listOfPiece.Remove(pieceToRemove);
                Console.WriteLine($"Successfully removed {piece}!");
            }

        }

        static void TryToChangeKey(List<Piece> listOfPiece, string[] cmdArgs)
        {
            string piece = cmdArgs[1];
            string newKey = cmdArgs[2];

            if (!listOfPiece.Any(p => p.Name == piece))
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }

            else
            {
                int intdex = listOfPiece.FindIndex(p => p.Name == piece);
                listOfPiece[intdex].Key = newKey;
                Console.WriteLine($"Changed the key of {piece} to {newKey}!");
            }
        }

        static void DisplayAllPieces(List<Piece> listOfPiece)
        {
            foreach (var piece in listOfPiece)
            {
                Console.WriteLine($"{piece.Name} -> Composer: {piece.Composer}, Key: {piece.Key}");
            }
        }
            
    }
}
