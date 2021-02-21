using Tictactoe.Models;

namespace Tictactoe.Controllers
{
    public interface IPutController : IColocateController
    {
        Error ValidateTarget(Coordinate target);
    }
}