using Tictactoe.Models;

namespace Tictactoe.Controllers
{
    public interface IColocateController : IOperationController, IPresenterController
    {
        Color Take();

        void Put(Coordinate target);

        bool ExistTicTacToe();

        ICoordinateController GetCoordinateController();

        Error ValidateTarget(Coordinate target);

        void Accept(IColocateControllerVisitor colocateControllerVisitor);
    }
}