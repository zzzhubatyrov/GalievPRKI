using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Xml.Linq;

    public class Article
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Content { get; set; }
        public string Hash { get; set; }
    }

    public class ArticleBuilder
    {
        private Article _article = new Article();

        public void SetTitle(string title)
        {
            _article.Title = title;
        }

        public void SetAuthors(string authors)
        {
            _article.Authors = authors;
        }

        public void SetContent(string content)
        {
            _article.Content = content;
        }

        public void SetHash(string hash)
        {
            _article.Hash = hash;
        }

        public Article GetArticle()
        {
            return _article;
        }
    }

    public class ArticleDirector
    {
        public void Construct(ArticleBuilder builder, string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            builder.SetTitle(lines[0]);
            builder.SetAuthors(lines[1]);
            builder.SetContent(lines[2]);
            builder.SetHash(lines[3]);
        }
    }

    public class ArticleConverter
    {
        public static bool ValidateHash(Article article)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] contentBytes = Encoding.UTF8.GetBytes(article.Content);
                byte[] hashBytes = sha256.ComputeHash(contentBytes);
                string computedHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                return computedHash == article.Hash.ToLowerInvariant();
            }
        }

        public static XDocument ConvertToXml(Article article)
        {
            XDocument doc = new XDocument(
                new XElement("article",
                    new XElement("title", article.Title),
                    new XElement("authors", article.Authors),
                    new XElement("content", article.Content),
                    new XElement("hash", article.Hash)
                )
            );

            return doc;
        }
    }
}
