using System;

namespace P04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isValid = false;

            bool lenghtResult = CheckPasswordLenght(password, isValid);
            bool charResult = CheckPasswordChars(password, isValid);
            bool digitsResult = CheckPasswordForDigits(password, isValid);
            if (lenghtResult == true && charResult == true && digitsResult == true)
            {
                Console.WriteLine("Password is valid");
            }

        }

        static bool CheckPasswordLenght(string password, bool isValid)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                return isValid = false;
            }
            else
            {
                return isValid = true;
            }
        }

        static bool CheckPasswordChars(string password, bool isValid)
        {
            string currentChar = password;

            for (int i = 0; i < password.Length; i++)
            {
                if (currentChar[i] < 48 ||
                    currentChar[i] > 57 && currentChar[i] < 65 ||
                    currentChar[i] > 90 && currentChar[i] < 97 ||
                    currentChar[i] > 122)
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    return isValid = false;
                }
            }
            return isValid = true;
        }

        static bool CheckPasswordForDigits(string password, bool isValid)
        {

            string currentChar = password;
            int digitCounter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (currentChar[i] >= 48 && currentChar[i] <= 57)
                {
                    digitCounter++;
                }
            }

            if (digitCounter < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                return isValid = false;
            }
            else
            {
                return isValid = true;
            }
        }
    }
}

