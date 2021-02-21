using System.Diagnostics;
using Tictactoe.Models;

namespace Tictactoe.Controllers.Local
{
    internal class LocalPutController : LocalColocateController, IPutController
    {
        public LocalPutController(Game game, LocalCoordinateController coordinateController) : base(game, coordinateController)
        {
        }

        public override void Put(Coordinate target)
        {
            Debug.Assert(this.ValidateTarget(target) == null);
            base.Put(target);
        }

        public override Error ValidateTarget(Coordinate target)
        {
            return base.ValidateTarget(target);
        }

        public override void Accept(IColocateControllerVisitor colocateControllerVisitor)
        {
            colocateControllerVisitor.Visit(this);
        }

        public override void Accept(IOperationControllerVisitor operationControllerVisitor)
        {
            operationControllerVisitor.Visit(this);
        }
    }
}