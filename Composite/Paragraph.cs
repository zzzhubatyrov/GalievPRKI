using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI.Composite
{
    public abstract class TextComponent
    {
        public abstract void Display();
    }

    public class Word : TextComponent
    {
        private string _word;

        public Word(string word)
        {
            _word = word;
        }

        public override void Display()
        {
            Console.Write(_word);
        }
    }

    public class Paragraph : TextComponent
    {
        private List<TextComponent> _components = new List<TextComponent>();

        public void Add(TextComponent component)
        {
            _components.Add(component);
        }

        public override void Display()
        {
            foreach (var component in _components)
            {
                component.Display();
            }
            Console.WriteLine();
        }
    }
}
