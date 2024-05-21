using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI.State
{
    public interface IAssignmentState
    {
        void HandleAssignment(Assignment assignment);
        string StateName { get; }
    }

    public class IssuedState : IAssignmentState
    {
        public void HandleAssignment(Assignment assignment)
        {
            Console.WriteLine("Задание выдано.");
            assignment.SetState(new CompletedState());
        }

        public string StateName => "Выдано";
    }

    public class CompletedState : IAssignmentState
    {
        public void HandleAssignment(Assignment assignment)
        {
            Console.WriteLine("Задание выполнено.");
            assignment.SetState(new SubmittedForReviewState());
        }

        public string StateName => "Выполнено";
    }

    public class SubmittedForReviewState : IAssignmentState
    {
        public void HandleAssignment(Assignment assignment)
        {
            Console.WriteLine("Задание сдано на проверку.");
            assignment.SetState(new ReviewedState());
        }

        public string StateName => "Сдано на проверку";
    }

    public class ReviewedState : IAssignmentState
    {
        public void HandleAssignment(Assignment assignment)
        {
            Console.WriteLine("Задание проверено.");
            assignment.SetState(new ResubmittedForReviewState());
        }

        public string StateName => "Проверено";
    }

    public class ResubmittedForReviewState : IAssignmentState
    {
        public void HandleAssignment(Assignment assignment)
        {
            Console.WriteLine("Задание пересдано на проверку.");
            assignment.SetState(new NotCompletedState());
        }

        public string StateName => "Пересдано на проверку";
    }

    public class NotCompletedState : IAssignmentState
    {
        public void HandleAssignment(Assignment assignment)
        {
            Console.WriteLine("Задание не выполнено.");
        }

        public string StateName => "Не выполнено";
    }

    public class Assignment
    {
        private IAssignmentState _state;

        public Assignment()
        {
            _state = new IssuedState();
        }

        public void SetState(IAssignmentState state)
        {
            _state = state;
        }

        public void HandleAssignment()
        {
            _state.HandleAssignment(this);
        }

        public string GetStateName()
        {
            return _state.StateName;
        }
    }
}
