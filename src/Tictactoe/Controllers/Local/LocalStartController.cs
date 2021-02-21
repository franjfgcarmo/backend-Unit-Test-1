using System.Diagnostics;
using Tictactoe.Models;
using Tictactoe.Utils;

namespace Tictactoe.Controllers.Local
{
    public class LocalStartController : LocalOperationController, IStartController
    {
        private readonly LocalColocateControllerBuilder colocateControllerBuilder;

        public LocalStartController(Game game, LocalColocateControllerBuilder colocateControllerBuilder) : base(game)
        {
            Debug.Assert(colocateControllerBuilder != null);
            this.colocateControllerBuilder = colocateControllerBuilder;
        }

        public override void Accept(IOperationControllerVisitor operationControllerVisitor)
        {
            operationControllerVisitor.Visit(this);
        }

        public void Start(int users)
        {
            Debug.Assert(new ClosedInterval(0, this.NumPlayers()).Includes(users));
            Debug.Assert(this.GetState() == State.INITIAL);
            colocateControllerBuilder.Build(users);
            this.SetState(State.IN_GAME);
        }
    }
}