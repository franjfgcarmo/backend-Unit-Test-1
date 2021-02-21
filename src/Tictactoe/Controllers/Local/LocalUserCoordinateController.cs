using Tictactoe.Models;

namespace Tictactoe.Controllers.Local
{
    public class LocalUserCoordinateController : LocalCoordinateController, IUserCoordinateController
    {
        public LocalUserCoordinateController(Game game) : base(game)
        {
        }

        public override void Accept(ICoordinateControllerVisitor coordinateControllerVisitor)
        {
            coordinateControllerVisitor.Visit(this);
        }

        public override Coordinate GetOrigin()
        {
            return new Coordinate();
        }

        public override Coordinate GetTarget()
        {
            return new Coordinate();
        }
    }
}