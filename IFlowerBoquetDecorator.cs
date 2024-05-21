using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI
{
    public interface IFlowerBouquet
    {
        void Assemble();
    }

    public class FlowerBouquet : IFlowerBouquet
    {
        public void Assemble()
        {
            Console.WriteLine("Flowers assembled into a bouquet");
        }
    }

    public class RibbonDecorator : IFlowerBouquet
    {
        private readonly IFlowerBouquet _flowerBouquet;
        private readonly string _ribbonText;

        public RibbonDecorator(IFlowerBouquet flowerBouquet, string ribbonText)
        {
            _flowerBouquet = flowerBouquet;
            _ribbonText = ribbonText;
        }

        public void Assemble()
        {
            _flowerBouquet.Assemble();
            Console.WriteLine($"Added ribbon with text: '{_ribbonText}'");
        }
    }
}
