using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P02.FancyBarcodes
{
    internal class Program
    {
        private static object stringBuilder;

        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            string validBarcodePattern = @"^(@[#]+)([A-Z][a-zA-Z0-9]{4,}[A-Z])(@[#]+)$";
            Regex regexBarcodeValidation = new Regex(validBarcodePattern);

            string digitPattern = @"[0-9]+";
            Regex regexForDigits = new Regex(digitPattern);

            for (int i = 1; i <= numberOfLines; i++)
            {
                string currBarcode = Console.ReadLine();

                if (regexBarcodeValidation.IsMatch(currBarcode))
                {
                    DisplayProductGroup(currBarcode, regexForDigits);
                }

                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }

        static void DisplayProductGroup(string currBarcode, Regex regexForDigits)
        {
            MatchCollection matchForDigits = regexForDigits.Matches(currBarcode);
            StringBuilder concatDigits = new StringBuilder();

            if (matchForDigits.Count != 0)
            {
                foreach (Match digit in matchForDigits)
                {
                    concatDigits.Append(digit.Value.ToString());
                }

                Console.WriteLine($"Product group: {concatDigits}");
            }

            else
            {
                Console.WriteLine("Product group: 00");
            }
        }
    }
}
