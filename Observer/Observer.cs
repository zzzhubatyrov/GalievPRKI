using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI.Observer
{
    public interface IPublisher
    {
        void Subscribe(ISubscriber subscriber);
        void Unsubscribe(ISubscriber subscriber);
        void Notify(string publication);
    }

    public interface ISubscriber
    {
        void Update(string publication);
        string Name { get; }
    }

    public class Publisher : IPublisher
    {
        private List<ISubscriber> _subscribers = new List<ISubscriber>();
        private string _name;

        public Publisher(string name)
        {
            _name = name;
        }

        public void Subscribe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
            Console.WriteLine($"{subscriber.Name} подписан на {_name}.");
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
            Console.WriteLine($"{subscriber.Name} отписался от {_name}.");
        }

        public void Notify(string publication)
        {
            Console.WriteLine($"{_name} издает: {publication}");
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(publication);
            }
        }
    }

    public class PostOffice : ISubscriber
    {
        private string _name;
        private List<ISubscriber> _subscribers = new List<ISubscriber>();

        public PostOffice(string name)
        {
            _name = name;
        }

        public string Name => _name;

        public void Subscribe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
            Console.WriteLine($"{subscriber.Name} подписан на {_name}.");
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
            Console.WriteLine($"{subscriber.Name} отписался от {_name}.");
        }

        public void Update(string publication)
        {
            Console.WriteLine($"{_name} получил: {publication}");
            NotifySubscribers(publication);
        }

        private void NotifySubscribers(string publication)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(publication);
            }
        }
    }

    public class Subscriber : ISubscriber
    {
        private string _name;

        public Subscriber(string name)
        {
            _name = name;
        }

        public string Name => _name;

        public void Update(string publication)
        {
            Console.WriteLine($"{_name} получил: {publication}");
        }
    }
}
