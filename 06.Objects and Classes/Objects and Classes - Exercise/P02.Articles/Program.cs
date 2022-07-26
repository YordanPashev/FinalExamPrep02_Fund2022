using System;
using System.Linq;

namespace P02.Articles
{
    class Article
    {
        public Article(string Title, string Content, string Author)
        {
            this.Title = Title;
            this.Content = Content;
            this.Author = Author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            string[] articleInformation = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();
            string title = articleInformation[0];
            string content = articleInformation[1];
            string author = articleInformation[2];

            Article article = new Article(title, content, author);
            int numberOfCmds = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCmds; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string cmdType = cmdArgs[0];

                if (cmdType == "Edit")
                {
                    string newContent = cmdArgs[1];
                    article.Content = newContent;
                }

                else if (cmdType == "ChangeAuthor")
                {
                    string newAuthor = cmdArgs[1];
                    article.Author = newAuthor;
                }

                else if (cmdType == "Rename")
                {
                    string newTitle = cmdArgs[1];
                    article.Title = newTitle;
                }
            }

            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }
    }
}
