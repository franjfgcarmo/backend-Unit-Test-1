using Tictactoe.Controllers;
using Tictactoe.Models;
using Tictactoe.Utils;

namespace Tictactoe.Views
{
    public class GameView : IColocateControllerVisitor
    {
        private IO io = IO.Instance();

        private ColorView colorView;

        private Models.Coordinate origin;

        public void Interact(IColocateController colocateController)
        {
            colorView = new ColorView(colocateController.Take());
            colocateController.Accept(this);
        }

        public void Visit(IPutController putController)
        {
            this.ShowTitle("Pone", putController.Take());
            PutTargetCoordinateView putCoordinateView = new PutTargetCoordinateView(
                    putController.GetCoordinateController());
            this.Put(putController, putCoordinateView);
            this.ShowGame(putController);
        }

        public void Visit(IMoveController moveController)
        {
            throw new System.NotImplementedException();
        }

        private void ShowTitle(string title, Color color)
        {
            colorView.Writeln(title + " el jugador ");
        }

        private void Put(IPutController putController,
            ColocateCoordinateView colocateCoordinateView)
        {
            Models.Coordinate target;
            var error = Error.NOT_ERROR;
            do
            {
                target = colocateCoordinateView.GetCoordinate();
                error = putController.ValidateTarget(target);
                if (error != Error.NOT_ERROR)
                {
                    io.Writeln("" + error);
                }
            } while (error != Error.NOT_ERROR);
            putController.Put(target);
        }

        private void Remove(IMoveController moveController,
            ColocateCoordinateView colocateCoordinateView)
        {
            Error error = Error.NOT_ERROR;
            do
            {
                origin = colocateCoordinateView.GetCoordinate();
                error = moveController.ValidateOrigin(origin);
                if (error != Error.NOT_ERROR)
                {
                    io.Writeln("" + error);
                }
            } while (error != Error.NOT_ERROR);
            moveController.Remove(origin);
        }

        private void Put(IMoveController moveController,
                ColocateCoordinateView colocateCoordinateView)
        {
            Models.Coordinate target;
            Error error = Error.NOT_ERROR;
            do
            {
                target = colocateCoordinateView.GetCoordinate();
                error = moveController.ValidateTarget(origin, target);
                if (error != Error.NOT_ERROR)
                {
                    io.Writeln("" + error);
                }
            } while (error != Error.NOT_ERROR);
            moveController.Put(target);
        }

        private void ShowGame(IColocateController colocateController)
        {
            new BoardView(colocateController).Write();
            if (colocateController.ExistTicTacToe())
            {
                colorView.WriteWinner();
            }
        }
    }
}