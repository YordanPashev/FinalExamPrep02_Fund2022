using System;
using System.Text.RegularExpressions;

namespace P06.ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string emailPattern = @"(\s)(?<user>[A-Za-z0-9]+[-._]?[\w+]+[-._]?)@(?<host>[A-za-z]+[-]?[A-Za-z]+([\.]+[A-Za-z]+([-]?[A-Za-z])?)+)(\b|\s)";
            string input = Console.ReadLine();

            Regex emailValidator = new Regex(@emailPattern);
            if (emailValidator.IsMatch(input))
            {
                MatchCollection validEmailAdresses = emailValidator.Matches(input);

                foreach (Match email in validEmailAdresses)
                {
                    Console.WriteLine(email.Groups["user"].Value + "@" + email.Groups["host"].Value);
                }
            }      
        }
    }
}
=