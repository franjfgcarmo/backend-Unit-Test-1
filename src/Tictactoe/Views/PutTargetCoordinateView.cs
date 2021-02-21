using Tictactoe.Controllers;
using Tictactoe.Models;

namespace Tictactoe.Views
{
    public class PutTargetCoordinateView : ColocateCoordinateView
    {
        private Models.Coordinate target;

        public PutTargetCoordinateView(ICoordinateController coordinateController) : base(coordinateController)
        {
        }

        public override Coordinate GetCoordinate()
        {
            target = this.GetCoordinateController().GetTarget();
            this.GetCoordinateController().Accept(this);
            return target;
        }

        public override void Visit(IUserCoordinateController userCoordinateController)
        {
            new CoordinateView("En", target).Read();
        }

        public override void Visit(IRandomCoordinateController randomCoordinateController)
        {
            this.Show("pone en", target);
        }
    }
}