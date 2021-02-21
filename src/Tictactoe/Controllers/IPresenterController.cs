using Tictactoe.Models;

namespace Tictactoe.Controllers
{
    public interface IPresenterController
    {
        Color GetColor(Coordinate coordinate);
    }
}