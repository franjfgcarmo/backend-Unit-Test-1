namespace Tictactoe.Controllers.Local
{
    public abstract class LocalOperationController : LocalController, IOperationController
    {
        protected LocalOperationController(Models.Game game) : base(game)
        {
        }

        public abstract void Accept(IOperationControllerVisitor operationControllerVisitor);
    }
}