using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI.State
{
    public interface IGrantState
    {
        void HandleRequest(GrantRequest request);
        string StateName { get; }
    }

    public class CreatedState : IGrantState
    {
        public void HandleRequest(GrantRequest request)
        {
            Console.WriteLine("Грант создан.");
            request.SetState(new UnderReviewState());
        }

        public string StateName => "Создан";
    }

    public class UnderReviewState : IGrantState
    {
        public void HandleRequest(GrantRequest request)
        {
            Console.WriteLine("Грант рассматривается.");
            request.SetState(new DeferredState());
        }

        public string StateName => "Рассматривается";
    }

    public class DeferredState : IGrantState
    {
        public void HandleRequest(GrantRequest request)
        {
            Console.WriteLine("Грант отложен.");
            request.SetState(new ApprovedState());
        }

        public string StateName => "Отложен";
    }

    public class ApprovedState : IGrantState
    {
        public void HandleRequest(GrantRequest request)
        {
            Console.WriteLine("Грант подтвержден.");
        }

        public string StateName => "Подтвержден";
    }

    public class RejectedState : IGrantState
    {
        public void HandleRequest(GrantRequest request)
        {
            Console.WriteLine("Грант отклонен.");
        }

        public string StateName => "Отклонен";
    }

    public class RevokedState : IGrantState
    {
        public void HandleRequest(GrantRequest request)
        {
            Console.WriteLine("Грант отозван.");
        }

        public string StateName => "Отозван";
    }

    public class GrantRequest
    {
        private IGrantState _state;

        public GrantRequest()
        {
            _state = new CreatedState();
        }

        public void SetState(IGrantState state)
        {
            _state = state;
        }

        public void HandleRequest()
        {
            _state.HandleRequest(this);
        }

        public string GetStateName()
        {
            return _state.StateName;
        }
    }
}
