using System;
using System.Diagnostics;
using Tictactoe.Controllers;
using Tictactoe.Utils;

namespace Tictactoe.Views
{
    public abstract class ColocateCoordinateView : ICoordinateControllerVisitor
    {
        private readonly ICoordinateController coordinateController;
        private readonly IO io = IO.Instance();

        protected ColocateCoordinateView(ICoordinateController coordinateController)
        {
            Debug.Assert(coordinateController != null);
            this.coordinateController = coordinateController;
        }

        public abstract Models.Coordinate GetCoordinate();

        public abstract void Visit(IUserCoordinateController userCoordinateController);

        public abstract void Visit(IRandomCoordinateController randomCoordinateController);

        protected void Show(String infix, Models.Coordinate coordinate)
        {
            new CoordinateView("La máquina " + infix + " ", coordinate).Write();
            io.ReadString(". Pulse enter para continuar");
        }

        protected ICoordinateController GetCoordinateController()
        {
            return coordinateController;
        }
    }
}