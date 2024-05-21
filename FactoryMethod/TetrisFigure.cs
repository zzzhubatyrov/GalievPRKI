using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI.FactoryMethod
{
    public abstract class TetrisFigure
    {
        public abstract string Name { get; }
        public abstract int[,] Shape { get; }
    }
    public class IShape : TetrisFigure
    {
        public override string Name => "I-Shape";
        public override int[,] Shape => new int[,] {
        { 1, 1, 1, 1 }
    };
    }

    public class OShape : TetrisFigure
    {
        public override string Name => "O-Shape";
        public override int[,] Shape => new int[,] {
        { 1, 1 },
        { 1, 1 }
    };
    }

    public class TShape : TetrisFigure
    {
        public override string Name => "T-Shape";
        public override int[,] Shape => new int[,] {
        { 0, 1, 0 },
        { 1, 1, 1 }
    };
    }

    // Супер-фигуры
    public class SuperLShape : TetrisFigure
    {
        public override string Name => "Super L-Shape";
        public override int[,] Shape => new int[,] {
        { 1, 0, 0 },
        { 1, 1, 1 },
        { 0, 1, 0 }
    };
    }

    public class SuperSquare : TetrisFigure
    {
        public override string Name => "Super Square";
        public override int[,] Shape => new int[,] {
        { 1, 1, 1 },
        { 1, 0, 1 },
        { 1, 1, 1 }
    };
    }

    public abstract class TetrisFigureFactory
    {
        public abstract TetrisFigure CreateFigure();
    }

    public class RandomTetrisFigureFactory : TetrisFigureFactory
    {
        private static Random random = new Random();
        private static List<Type> figures = new List<Type>
    {
        typeof(IShape),
        typeof(OShape),
        typeof(TShape),
        typeof(SuperLShape),
        typeof(SuperSquare)
    };

        public override TetrisFigure CreateFigure()
        {
            int index = random.Next(figures.Count);
            return (TetrisFigure)Activator.CreateInstance(figures[index]);
        }
    }
}
