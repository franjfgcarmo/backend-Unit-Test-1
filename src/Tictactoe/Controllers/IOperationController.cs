namespace Tictactoe.Controllers
{
    public interface IOperationController
    {
        void Accept(IOperationControllerVisitor operationControllerVisitor);
    }
}