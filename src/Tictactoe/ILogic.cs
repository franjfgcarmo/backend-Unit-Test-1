using Tictactoe.Controllers;

namespace Tictactoe
{
    public interface ILogic
    {
        IOperationController GetOperationController();
    }
}