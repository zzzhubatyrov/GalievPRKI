using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI.Composite
{
    public abstract class ArmyComponent
    {
        public abstract void Display();
    }

    public class Warrior : ArmyComponent
    {
        private string _name;

        public Warrior(string name)
        {
            _name = name;
        }

        public override void Display()
        {
            Console.WriteLine(_name);
        }
    }

    public class Army : ArmyComponent
    {
        private List<ArmyComponent> _components = new List<ArmyComponent>();

        public void Add(ArmyComponent component)
        {
            _components.Add(component);
        }

        public void Remove(ArmyComponent component)
        {
            _components.Remove(component);
        }

        public override void Display()
        {
            foreach (var component in _components)
            {
                component.Display();
            }
        }
    }
}
