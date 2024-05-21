using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI
{
    public interface IPaymentHandler
    {
        void HandlePayment(Payment payment);
    }

    public class RegularPaymentHandler : IPaymentHandler
    {
        private IPaymentHandler _nextHandler;

        public void SetNextHandler(IPaymentHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void HandlePayment(Payment payment)
        {
            if (payment.Type == PaymentType.Regular)
            {
                Console.WriteLine("Processing regular payment...");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandlePayment(payment);
            }
        }
    }

    public class DiscountedPaymentHandler : IPaymentHandler
    {
        private IPaymentHandler _nextHandler;

        public void SetNextHandler(IPaymentHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void HandlePayment(Payment payment)
        {
            if (payment.Type == PaymentType.Discounted)
            {
                Console.WriteLine("Processing discounted payment...");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandlePayment(payment);
            }
        }
    }

    public class GovernmentPaymentHandler : IPaymentHandler
    {
        private IPaymentHandler _nextHandler;

        public void SetNextHandler(IPaymentHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void HandlePayment(Payment payment)
        {
            if (payment.Type == PaymentType.Government)
            {
                Console.WriteLine("Processing government payment...");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandlePayment(payment);
            }
        }
    }

    public class InternalPaymentHandler : IPaymentHandler
    {
        public void HandlePayment(Payment payment)
        {
            if (payment.Type == PaymentType.Internal)
            {
                Console.WriteLine("Processing internal payment...");
            }
        }
    }

    public enum PaymentType
    {
        Regular,
        Discounted,
        Government,
        Internal
    }

    public class Payment
    {
        public PaymentType Type { get; set; }
    }
}
