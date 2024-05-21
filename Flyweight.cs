using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI
{
    public interface IBacteriaExternalState
    {
        void Display(int x, int y);
    }

    public class BacteriaType : IBacteriaExternalState
    {
        private string _type;

        public BacteriaType(string type)
        {
            _type = type;
        }

        public void Display(int x, int y)
        {
            Console.WriteLine($"Bacteria of type {_type} is located at ({x}, {y}).");
        }
    }

    public class BacteriaColor : IBacteriaExternalState
    {
        private string _color;

        public BacteriaColor(string color)
        {
            _color = color;
        }

        public void Display(int x, int y)
        {
            Console.WriteLine($"Bacteria with color {_color} is located at ({x}, {y}).");
        }
    }

    public class BacteriaInternalState
    {
        public int ReproductionRate { get; set; }
        public int Lifespan { get; set; }
    }

    public class BacteriaFactory
    {
        private Dictionary<string, IBacteriaExternalState> _bacteriaTypes = new Dictionary<string, IBacteriaExternalState>();

        public IBacteriaExternalState GetBacteriaType(string type)
        {
            if (!_bacteriaTypes.ContainsKey(type))
            {
                _bacteriaTypes[type] = new BacteriaType(type);
            }
            return _bacteriaTypes[type];
        }

        public IBacteriaExternalState GetBacteriaColor(string color)
        {
            return new BacteriaColor(color);
        }
    }

    // Контекст бактерии
    public class Bacteria
    {
        private int _x;
        private int _y;
        private IBacteriaExternalState _externalState;
        private BacteriaInternalState _internalState;

        public Bacteria(int x, int y, IBacteriaExternalState externalState, BacteriaInternalState internalState)
        {
            _x = x;
            _y = y;
            _externalState = externalState;
            _internalState = internalState;
        }

        public void Display()
        {
            _externalState.Display(_x, _y);
        }
    }
}
