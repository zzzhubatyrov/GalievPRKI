using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI.Composite
{
    public abstract class FileSystemComponent
    {
        public abstract void Display(string prefix);
    }
    public class File : FileSystemComponent
    {
        private string _name;

        public File(string name)
        {
            _name = name;
        }

        public override void Display(string prefix)
        {
            Console.WriteLine($"{prefix}File: {_name}");
        }
    }

    public class Directory : FileSystemComponent
    {
        private List<FileSystemComponent> _components = new List<FileSystemComponent>();
        private string _name;

        public Directory(string name)
        {
            _name = name;
        }

        public void Add(FileSystemComponent component)
        {
            _components.Add(component);
        }

        public void Remove(FileSystemComponent component)
        {
            _components.Remove(component);
        }

        public override void Display(string prefix)
        {
            Console.WriteLine($"{prefix}Directory: {_name}");

            foreach (var component in _components)
            {
                component.Display(prefix + "  ");
            }
        }
    }
}
