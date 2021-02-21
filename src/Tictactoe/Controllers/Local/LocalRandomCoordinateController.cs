using System.Diagnostics;
using Tictactoe.Models;

namespace Tictactoe.Controllers.Local
{
    public class LocalRandomCoordinateController : LocalCoordinateController, IRandomCoordinateController
    {
        public LocalRandomCoordinateController(Game game) : base(game)
        {
        }

        public override void Accept(ICoordinateControllerVisitor coordinateControllerVisitor)
        {
            coordinateControllerVisitor.Visit(this);
        }

        public override Coordinate GetOrigin()
        {
            Coordinate origin = new Coordinate();
            bool ok;
            do
            {
                origin.Random();
                ok = this.Full(origin);
            } while (!ok);
            Coordinate result = origin;
            return result;
        }

        public Coordinate GetTarget(Coordinate origin)
        {
            Debug.Assert(origin != null);
            bool ok;
            Coordinate target;
            do
            {
                target = this.GetTarget();
                ok = !origin.Equals(target);
            } while (!ok);
            return target;
        }

        public override Coordinate GetTarget()
        {
            Coordinate target = new Coordinate();
            bool ok;
            do
            {
                target.Random();
                ok = this.Empty(target);
            } while (!ok);
            Coordinate result = target;
            target = null;
            return result;
        }
    }
}