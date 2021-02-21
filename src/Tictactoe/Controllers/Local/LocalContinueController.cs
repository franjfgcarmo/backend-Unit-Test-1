using System.Diagnostics;
using Tictactoe.Models;

namespace Tictactoe.Controllers.Local
{
    public class LocalContinueController : LocalOperationController, IContinueController
    {
        public LocalContinueController(Models.Game game) : base(game)
        {
        }

        public override void Accept(IOperationControllerVisitor operationControllerVisitor)
        {
            operationControllerVisitor.Visit(this);
        }

        public void Resume(bool another)
        {
            Debug.Assert(GetState() == State.FINAL);
            if (another)
            {
                Clear();
                SetState(State.INITIAL);
            }
            else
            {
                SetState(State.EXIT);
            }
        }
    }
}