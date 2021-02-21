using System.Diagnostics;
using Tictactoe.Controllers;
using Tictactoe.Utils;

namespace Tictactoe.Views
{
    public class BoardView
    {
        private readonly IPresenterController controller;

        public BoardView(IPresenterController controller)
        {
            Debug.Assert(controller != null);
            this.controller = controller;
        }

        public void Write()
        {
            var io = IO.Instance();
            for (int i = 0; i < Models.Coordinate.DIMENSION; i++)
            {
                for (int j = 0; j < Models.Coordinate.DIMENSION; j++)
                {
                    new ColorView(controller.GetColor(new Models.Coordinate(i, j)))
                            .Write(" ");
                }
                io.Writeln();
            }
        }
    }
}