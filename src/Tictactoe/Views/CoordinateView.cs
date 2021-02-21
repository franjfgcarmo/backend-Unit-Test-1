using System.Diagnostics;
using Tictactoe.Utils;

namespace Tictactoe.Views
{
    internal class CoordinateView
    {
        private string title;
        private Models.Coordinate coordinate;
        private IO io = IO.Instance();

        public CoordinateView(string title, Models.Coordinate coordinate)
        {
            Debug.Assert(title != null);
            Debug.Assert(coordinate != null);
            this.title = title;
            this.coordinate = coordinate;
        }

        public void Read()
        {
            io.Writeln(title + " qué casilla?");
            coordinate.SetRow(new LimitedIntDialog("Fila?", Models.Coordinate.DIMENSION)
                    .Read() - 1);
            coordinate.SetColumn(new LimitedIntDialog("Columna?",
                    Models.Coordinate.DIMENSION).Read() - 1);
        }

        public void Write()
        {
            io.Write(
                    title + "[" + (coordinate.GetRow() + 1) + ", "
                            + (coordinate.GetColumn() + 1) + "]");
        }
    }
}