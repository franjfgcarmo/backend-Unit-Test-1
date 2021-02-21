using System.Diagnostics;
using Tictactoe.Models;

namespace Tictactoe.Controllers.Local
{
    internal class LocalMoveController : LocalColocateController, IMoveController
    {
        private Coordinate origin;

        public LocalMoveController(Game game, LocalCoordinateController coordinateController) : base(game, coordinateController)
        {
        }

        public override void Remove(Coordinate origin)
        {
            Debug.Assert(origin != null);
            Debug.Assert(this.ValidateOrigin(origin) == null);
            this.origin = origin;
            base.Remove(origin);
        }

        public Error ValidateOrigin(Coordinate origin)
        {
            Debug.Assert(origin != null);
            if (!this.Full(origin))
            {
                return Error.NOT_PROPERTY;
            }
            return Error.NOT_ERROR;
        }

        public void put(Coordinate target)
        {
            Debug.Assert(target != null);
            Debug.Assert(origin != null);
            Debug.Assert(this.ValidateTarget(origin, target) == null);
            base.Put(target);
            origin = null;
        }

        public Error ValidateTarget(Coordinate origin, Coordinate target)
        {
            Error error = base.ValidateTarget(target);
            if (error != Error.NOT_ERROR)
            {
                return error;
            }
            if (origin.Equals(target))
            {
                return Error.REPEATED_COORDINATE;
            }
            return Error.NOT_ERROR;
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