using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI.Composite
{
    public abstract class CountryComponent
    {
        protected string _name;

        public CountryComponent(string name)
        {
            _name = name;
        }

        public abstract void Display(int depth);
    }

    public class City : CountryComponent
    {
        public City(string name) : base(name) { }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + _name);
        }
    }

    public class Region : CountryComponent
    {
        private List<CountryComponent> _components = new List<CountryComponent>();

        public Region(string name) : base(name) { }

        public void Add(CountryComponent component)
        {
            _components.Add(component);
        }

        public void Remove(CountryComponent component)
        {
            _components.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + "+ " + _name);

            foreach (var component in _components)
            {
                component.Display(depth + 2);
            }
        }
    }
}
