using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PRKI.AbstractFactory
{
    using System;
    using System.Collections.Generic;

    //public class DAO { }
    public class Movie
    {
        public string Title { get; set; }
        public string AudioLanguage { get; set; }
        public string SubtitleLanguage { get; set; }
    }
    public class PhoneCall
    {
        public string Caller { get; set; }
        public string Receiver { get; set; }
        public DateTime CallTime { get; set; }
        public int Duration { get; set; }
    }
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public Dictionary<string, string> AdditionalData { get; set; } = new Dictionary<string, string>();
    }


    public interface DAO
    {
        void SaveMovie(Movie movie);
        List<Movie> GetAllMovies();
        void SaveCall(PhoneCall call);
        List<PhoneCall> GetAllCalls();
        void SaveUser(User user);
        List<User> GetAllUsers();
    }



    public class AFDatabaseDAO : DAO
    {
        private List<Movie> database = new List<Movie>();
        public void SaveMovie(Movie movie)
        {
            database.Add(movie);
        }
        public List<Movie> GetAllMovies()
        {
            return database;
        }

        private List<PhoneCall> databasePhone = new List<PhoneCall>();
        public void SaveCall(PhoneCall call)
        {
            databasePhone.Add(call);
        }
        public List<PhoneCall> GetAllCalls()
        {
            return databasePhone;
        }

        private List<User> databaseUser = new List<User>();
        public void SaveUser(User user)
        {
            databaseUser.Add(user);
        }
        public List<User> GetAllUsers()
        {
            return databaseUser;
        }
    }
    public class AFXMLDAO : DAO
    {
        private string filePath = "movies.xml";

        public void SaveMovie(Movie movie)
        {
            XDocument doc;
            if (System.IO.File.Exists(filePath))
            {
                doc = XDocument.Load(filePath);
            }
            else
            {
                doc = new XDocument(new XElement("Movies"));
            }

            XElement movieElement = new XElement("Movie",
                new XElement("Title", movie.Title),
                new XElement("AudioLanguage", movie.AudioLanguage),
                new XElement("SubtitleLanguage", movie.SubtitleLanguage));

            doc.Root.Add(movieElement);
            doc.Save(filePath);
        }
        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();
            if (!System.IO.File.Exists(filePath))
            {
                return movies;
            }

            XDocument doc = XDocument.Load(filePath);
            foreach (var element in doc.Root.Elements("Movie"))
            {
                Movie movie = new Movie
                {
                    Title = element.Element("Title").Value,
                    AudioLanguage = element.Element("AudioLanguage").Value,
                    SubtitleLanguage = element.Element("SubtitleLanguage").Value
                };
                movies.Add(movie);
            }
            return movies;
        }

        private string filePathPhone = "calls.xml";
        public void SaveCall(PhoneCall call)
        {
            XDocument doc;
            if (System.IO.File.Exists(filePathPhone))
            {
                doc = XDocument.Load(filePathPhone);
            }
            else
            {
                doc = new XDocument(new XElement("Calls"));
            }

            XElement callElement = new XElement("Call",
                new XElement("Caller", call.Caller),
                new XElement("Receiver", call.Receiver),
                new XElement("CallTime", call.CallTime),
                new XElement("Duration", call.Duration));

            doc.Root.Add(callElement);
            doc.Save(filePathPhone);
        }
        public List<PhoneCall> GetAllCalls()
        {
            List<PhoneCall> calls = new List<PhoneCall>();
            if (!System.IO.File.Exists(filePathPhone))
            {
                return calls;
            }

            XDocument doc = XDocument.Load(filePathPhone);
            foreach (var element in doc.Root.Elements("Call"))
            {
                PhoneCall call = new PhoneCall
                {
                    Caller = element.Element("Caller").Value,
                    Receiver = element.Element("Receiver").Value,
                    CallTime = DateTime.Parse(element.Element("CallTime").Value),
                    Duration = int.Parse(element.Element("Duration").Value)
                };
                calls.Add(call);
            }
            return calls;
        }

        private string filePathUser = "users.xml";
        public void SaveUser(User user)
        {
            XDocument doc;
            if (System.IO.File.Exists(filePathUser))
            {
                doc = XDocument.Load(filePathUser);
            }
            else
            {
                doc = new XDocument(new XElement("Users"));
            }

            XElement userElement = new XElement("User",
                new XElement("Username", user.Username),
                new XElement("Email", user.Email));

            foreach (var data in user.AdditionalData)
            {
                userElement.Add(new XElement(data.Key, data.Value));
            }

            doc.Root.Add(userElement);
            doc.Save(filePathUser);
        }
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            if (!System.IO.File.Exists(filePathUser))
            {
                return users;
            }

            XDocument doc = XDocument.Load(filePathUser);
            foreach (var element in doc.Root.Elements("User"))
            {
                User user = new User
                {
                    Username = element.Element("Username").Value,
                    Email = element.Element("Email").Value
                };

                foreach (var data in element.Elements())
                {
                    if (data.Name != "Username" && data.Name != "Email")
                    {
                        user.AdditionalData[data.Name.ToString()] = data.Value;
                    }
                }

                users.Add(user);
            }
            return users;
        }
    }

    public interface IAFDAOFactory
    {
        DAO CreateDAO();
    }
    public class DatabaseDAOFactory : IAFDAOFactory
    {
        public DAO CreateDAO()
        {
            return new AFDatabaseDAO();
        }
    }
    public class XMLDAOFactory : IAFDAOFactory
    {
        public DAO CreateDAO()
        {
            return new AFXMLDAO();
        }
    }
}
