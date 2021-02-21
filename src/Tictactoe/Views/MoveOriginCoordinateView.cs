using Tictactoe.Controllers;
using Tictactoe.Models;

namespace Tictactoe.Views
{
    public class MoveOriginCoordinateView : ColocateCoordinateView
    {
        private Models.Coordinate origin;

        protected MoveOriginCoordinateView(ICoordinateController coordinateController) : base(coordinateController)
        {
        }

        public override Coordinate GetCoordinate()
        {
            origin = this.GetCoordinateController().GetOrigin();
            this.GetCoordinateController().Accept(this);
            return origin;
        }

        public override void Visit(IUserCoordinateController userCoordinateController)
        {
            new CoordinateView("De", origin).Read();
        }

        public override void Visit(IRandomCoordinateController randomCoordinateController)
        {
            this.Show("quita de", origin);
        }
    }
}