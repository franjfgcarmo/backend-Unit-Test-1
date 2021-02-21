using System.Diagnostics;
using Tictactoe.Models;

namespace Tictactoe.Controllers.Local
{
    public abstract class LocalColocateController : LocalOperationController, IColocateController
    {
        private readonly LocalCoordinateController coordinateController;

        protected LocalColocateController(Game game, LocalCoordinateController coordinateController) : base(game)
        {
            Debug.Assert(coordinateController != null);
            this.coordinateController = coordinateController;
        }

        public abstract void Accept(IColocateControllerVisitor colocateControllerVisitor);

        public ICoordinateController GetCoordinateController()
        {
            return coordinateController;
        }

        public virtual Error ValidateTarget(Coordinate target)
        {
            if (!Empty(target))
            {
                Debug.WriteLine("Error no libre");
                return Error.NOT_EMPTY;
            }
            return Error.NOT_ERROR;
        }
    }
}