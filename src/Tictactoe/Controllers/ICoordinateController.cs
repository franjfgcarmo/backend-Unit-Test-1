using Tictactoe.Models;

namespace Tictactoe.Controllers
{
    public interface ICoordinateController
    {
        Coordinate GetOrigin();

        Coordinate GetTarget();

        void Accept(ICoordinateControllerVisitor coordinateControllerVisitor);
    }
}