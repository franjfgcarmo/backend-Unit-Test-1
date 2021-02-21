using Tictactoe.Controllers;

namespace Tictactoe
{
    public interface IView : IOperationControllerVisitor
    {
        public void Interact(IOperationController operationController);
    }
}