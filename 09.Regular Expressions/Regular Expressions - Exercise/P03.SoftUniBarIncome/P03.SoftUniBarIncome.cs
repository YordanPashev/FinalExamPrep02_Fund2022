using System;
using System.Text.RegularExpressions;

namespace P03.SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<user>[A-z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$.]*\|(?<quantity>\d+)\|[^|$.]*?(?<price>\d+(\.\d+)?)\$";

            Regex orderValidator = new Regex(pattern);
            decimal totalIncome = 0;

            string cmdLine;
            while ((cmdLine = Console.ReadLine()) != "end of shift")
            {
                if (orderValidator.IsMatch(cmdLine))
                {
                    Match orderInfo = orderValidator.Match(cmdLine);

                    string customerName = orderInfo.Groups["user"].Value;
                    string product = orderInfo.Groups["product"].Value;
                    int quantity = int.Parse(orderInfo.Groups["quantity"].Value);
                    decimal price = decimal.Parse(orderInfo.Groups["price"].Value);

                    decimal customerOrderPrice = price * quantity;

                    Console.WriteLine($"{customerName}: {product} - {customerOrderPrice:F2}");

                    totalIncome += customerOrderPrice;

                }
            }

            Console.WriteLine($"Total income: { totalIncome:F2}");
        }
    }
}
