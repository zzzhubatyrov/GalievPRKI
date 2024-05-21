using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI.Prototype
{
    public class ArticleWiki : ICloneable
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime LastModified { get; set; }

        public ArticleWiki(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
            LastModified = DateTime.Now;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, LastModified: {LastModified}, Content: {Content}";
        }
    }

    public class ArticleManager
    {
        private Dictionary<string, ArticleWiki> _originalArticles = new Dictionary<string, ArticleWiki>();
        private Dictionary<string, ArticleWiki> _currentArticles = new Dictionary<string, ArticleWiki>();

        public void AddArticle(ArticleWiki article)
        {
            _originalArticles[article.Title] = article;
            _currentArticles[article.Title] = (ArticleWiki)article.Clone();
        }

        public ArticleWiki GetEditableArticle(string title)
        {
            if (_currentArticles.ContainsKey(title))
            {
                return _currentArticles[title];
            }
            else
            {
                throw new Exception("Article not found");
            }
        }

        public void RestoreArticle(string title)
        {
            if (_originalArticles.ContainsKey(title))
            {
                _currentArticles[title] = (ArticleWiki)_originalArticles[title].Clone();
            }
            else
            {
                throw new Exception("Original article not found");
            }
        }

        public void DisplayArticles()
        {
            Console.WriteLine("Current Articles:");
            foreach (var article in _currentArticles.Values)
            {
                Console.WriteLine(article);
            }
        }
    }
}
