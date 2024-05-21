using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI
{
    public abstract class Transport
    {
        public abstract double CalculateTime(double distance);
        public abstract double CalculateCost(double distance);
    }

    // Подклассы Транспортного средства: Автомобиль
    public class Cars : Transport
    {
        public override double CalculateTime(double distance)
        {
            return distance / 60;
        }

        public override double CalculateCost(double distance)
        {
            return distance * 0.5;
        }
    }

    public class Bicycle : Transport
    {
        public override double CalculateTime(double distance)
        {
            return distance / 15; 
        }

        public override double CalculateCost(double distance)
        {
            return 0; 
        }
    }

    public class Cart : Transport
    {
        public override double CalculateTime(double distance)
        {
            return distance / 10;
        }

        public override double CalculateCost(double distance)
        {
            return distance * 0.3; 
        }
    }

    public abstract class PassengerCarrier
    {
        public abstract Transport CreateTransport(double distance);
    }

    public class AirplaneCarrier : PassengerCarrier
    {
        public override Transport CreateTransport(double distance)
        {
            return new Cars(); 
        }
    }

    public class TrainCarrier : PassengerCarrier
    {
        public override Transport CreateTransport(double distance)
        {
            return new Cars(); 
        }
    }

    public class CarCarrier : PassengerCarrier
    {
        public override Transport CreateTransport(double distance)
        {
            return new Cars();
        }
    }
}
