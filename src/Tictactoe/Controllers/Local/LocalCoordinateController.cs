using Tictactoe.Models;

namespace Tictactoe.Controllers.Local
{
    public abstract class LocalCoordinateController : LocalController, ICoordinateController
    {
        protected LocalCoordinateController(Game game) : base(game)
        {
        }

        public abstract void Accept(ICoordinateControllerVisitor coordinateControllerVisitor);

        public abstract Coordinate GetOrigin();

        public abstract Coordinate GetTarget();
    }
}