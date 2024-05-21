using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI.Interpreter
{
    public class ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }
    }

    public interface IExpression
    {
        ComplexNumber Interpret(Dictionary<string, ComplexNumber> context);
    }

    public class Constant : IExpression
    {
        private ComplexNumber _value;

        public Constant(ComplexNumber value)
        {
            _value = value;
        }

        public ComplexNumber Interpret(Dictionary<string, ComplexNumber> context)
        {
            return _value;
        }
    }

    public class Variable : IExpression
    {
        private string _name;

        public Variable(string name)
        {
            _name = name;
        }

        public ComplexNumber Interpret(Dictionary<string, ComplexNumber> context)
        {
            if (context.ContainsKey(_name))
            {
                return context[_name];
            }
            throw new Exception($"Variable {_name} not found in context");
        }
    }

    public class Add : IExpression
    {
        private IExpression _left;
        private IExpression _right;

        public Add(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public ComplexNumber Interpret(Dictionary<string, ComplexNumber> context)
        {
            var leftResult = _left.Interpret(context);
            var rightResult = _right.Interpret(context);
            return new ComplexNumber(leftResult.Real + rightResult.Real, leftResult.Imaginary + rightResult.Imaginary);
        }
    }

    public class Subtract : IExpression
    {
        private IExpression _left;
        private IExpression _right;

        public Subtract(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public ComplexNumber Interpret(Dictionary<string, ComplexNumber> context)
        {
            var leftResult = _left.Interpret(context);
            var rightResult = _right.Interpret(context);
            return new ComplexNumber(leftResult.Real - rightResult.Real, leftResult.Imaginary - rightResult.Imaginary);
        }
    }

    public class Multiply : IExpression
    {
        private IExpression _left;
        private IExpression _right;

        public Multiply(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public ComplexNumber Interpret(Dictionary<string, ComplexNumber> context)
        {
            var leftResult = _left.Interpret(context);
            var rightResult = _right.Interpret(context);
            double real = leftResult.Real * rightResult.Real - leftResult.Imaginary * rightResult.Imaginary;
            double imaginary = leftResult.Real * rightResult.Imaginary + leftResult.Imaginary * rightResult.Real;
            return new ComplexNumber(real, imaginary);
        }
    }

    public class Divide : IExpression
    {
        private IExpression _left;
        private IExpression _right;

        public Divide(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public ComplexNumber Interpret(Dictionary<string, ComplexNumber> context)
        {
            var leftResult = _left.Interpret(context);
            var rightResult = _right.Interpret(context);
            double denominator = rightResult.Real * rightResult.Real + rightResult.Imaginary * rightResult.Imaginary;
            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }
            double real = (leftResult.Real * rightResult.Real + leftResult.Imaginary * rightResult.Imaginary) / denominator;
            double imaginary = (leftResult.Imaginary * rightResult.Real - leftResult.Real * rightResult.Imaginary) / denominator;
            return new ComplexNumber(real, imaginary);
        }
    }

    // Битовые операции
    public class And : IExpression
    {
        private IExpression _left;
        private IExpression _right;

        public And(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public ComplexNumber Interpret(Dictionary<string, ComplexNumber> context)
        {
            var leftResult = _left.Interpret(context);
            var rightResult = _right.Interpret(context);
            int real = (int)leftResult.Real & (int)rightResult.Real;
            int imaginary = (int)leftResult.Imaginary & (int)rightResult.Imaginary;
            return new ComplexNumber(real, imaginary);
        }
    }

    public class Or : IExpression
    {
        private IExpression _left;
        private IExpression _right;

        public Or(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public ComplexNumber Interpret(Dictionary<string, ComplexNumber> context)
        {
            var leftResult = _left.Interpret(context);
            var rightResult = _right.Interpret(context);
            int real = (int)leftResult.Real | (int)rightResult.Real;
            int imaginary = (int)leftResult.Imaginary | (int)rightResult.Imaginary;
            return new ComplexNumber(real, imaginary);
        }
    }

    public class Xor : IExpression
    {
        private IExpression _left;
        private IExpression _right;

        public Xor(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public ComplexNumber Interpret(Dictionary<string, ComplexNumber> context)
        {
            var leftResult = _left.Interpret(context);
            var rightResult = _right.Interpret(context);
            int real = (int)leftResult.Real ^ (int)rightResult.Real;
            int imaginary = (int)leftResult.Imaginary ^ (int)rightResult.Imaginary;
            return new ComplexNumber(real, imaginary);
        }
    }
}
