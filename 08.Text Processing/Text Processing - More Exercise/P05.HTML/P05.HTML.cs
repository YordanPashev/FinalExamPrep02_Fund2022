using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();

            Console.WriteLine($"<h1> {Environment.NewLine} " +
                $"    {title} {Environment.NewLine}" +
                $"</h1>");

            string content = Console.ReadLine();

            Console.WriteLine($"<article> {Environment.NewLine} " +
                $"    {content} {Environment.NewLine}" +
                $"</article>");

            string comment;

            while ((comment = Console.ReadLine()) != "end of comments")
            {
                Console.WriteLine($"<div> {Environment.NewLine} " +
                $"    {comment} {Environment.NewLine}" +
                $"</div>");
            }
        }
    }
}