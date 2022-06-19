using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Articles_2._0
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

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            int numberOfCmds = int.Parse(Console.ReadLine());
            List<Article> articlesList = new List<Article>();

            for (int i = 0; i < numberOfCmds; i++)
            {
                string[] articleInformation = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();
                string title = articleInformation[0];
                string content = articleInformation[1];
                string author = articleInformation[2];

                Article currentArticleInfo = new Article(title, content, author);
                articlesList.Add(currentArticleInfo);
            }

            string sortType = Console.ReadLine();

            List<Article> orderedArticlesList = new List<Article>();

            if (sortType == "title")
            {
                orderedArticlesList = articlesList.OrderBy(title => title.Title).ToList();
            }

            else if (sortType == "content")
            {
                orderedArticlesList = articlesList.OrderBy(cont => cont.Content).ToList();
            }

            else if (sortType == "author")
            {
                orderedArticlesList = articlesList.OrderBy(author => author.Author).ToList();
            }

            foreach (Article article in orderedArticlesList)
            {
                Console.WriteLine(article);
            }
        }
    }
}

