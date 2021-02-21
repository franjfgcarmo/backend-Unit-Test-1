using Tictactoe.Models;

namespace Tictactoe.Controllers
{
    public interface IMoveController : IColocateController
    {
        Error ValidateOrigin(Coordinate origin);

        void Remove(Coordinate origin);

        Error ValidateTarget(Coordinate origin, Coordinate target);
    }
}