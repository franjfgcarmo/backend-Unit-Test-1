using Tictactoe.Models;

namespace Tictactoe.Controllers
{
    public interface IRandomCoordinateController : ICoordinateController
    {
        Coordinate GetTarget(Coordinate origin);
    }
}