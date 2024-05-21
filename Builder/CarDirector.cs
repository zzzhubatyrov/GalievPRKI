using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI
{
    using System;
    using System.Collections.Generic;

    public class Car
    {
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Color { get; set; }
        public List<string> Features { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"Model: {Model}, Engine: {Engine}, Color: {Color}, Features: {string.Join(", ", Features)}";
        }
    }

    public interface ICarBuilder
    {
        void SetModel();
        void SetEngine();
        void SetColor();
        void AddFeatures();
        Car GetCar();
    }

    public class StandardCarBuilder : ICarBuilder
    {
        private Car _car = new Car();

        public void SetModel()
        {
            _car.Model = "Standard Model";
        }

        public void SetEngine()
        {
            _car.Engine = "V4 Engine";
        }

        public void SetColor()
        {
            _car.Color = "White";
        }

        public void AddFeatures()
        {
            _car.Features.Add("Air Conditioning");
            _car.Features.Add("Power Windows");
        }

        public Car GetCar()
        {
            return _car;
        }
    }

    public class CustomCarBuilder : ICarBuilder
    {
        private Car _car = new Car();

        public void SetModel()
        {
            _car.Model = "Custom Model";
        }

        public void SetEngine()
        {
            _car.Engine = "V6 Engine";
        }

        public void SetColor()
        {
            _car.Color = "Black";
        }

        public void AddFeatures()
        {
            _car.Features.Add("Sunroof");
            _car.Features.Add("Leather Seats");
        }

        public Car GetCar()
        {
            return _car;
        }
    }

    public class CarDirector
    {
        public void Construct(ICarBuilder carBuilder)
        {
            carBuilder.SetModel();
            carBuilder.SetEngine();
            carBuilder.SetColor();
            carBuilder.AddFeatures();
        }
    }
}
