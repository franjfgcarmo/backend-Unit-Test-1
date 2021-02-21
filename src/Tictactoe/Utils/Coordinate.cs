using System.Diagnostics;

namespace Tictactoe.Utils
{
    public class Coordinate
    {
        private int row;

        private int column;

        public Coordinate()
        {
        }

        public Coordinate(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public Direction Direction(Coordinate coordinate)
        {
            Debug.Assert(coordinate != null);
            Debug.Assert(!this.Equals(coordinate));
            if (this.InRow(coordinate))
            {
                return Utils.Direction.HORIZONTAL;
            }
            if (this.InColumn(coordinate))
            {
                return Utils.Direction.VERTICAL;
            }
            if (this.InMainDiagonal() && coordinate.InMainDiagonal())
            {
                return Utils.Direction.MAIN_DIAGONAL;
            }
            return Utils.Direction.NON_EXISTENT;
        }

        public bool InRow(Coordinate coordinate)
        {
            return row == coordinate.row;
        }

        public bool InColumn(Coordinate coordinate)
        {
            return column == coordinate.column;
        }

        public bool InMainDiagonal()
        {
            return row - column == 0;
        }

        public int GetRow()
        {
            return row;
        }

        public int GetColumn()
        {
            return column;
        }

        public void SetRow(int row)
        {
            this.row = row;
        }

        public void SetColumn(int column)
        {
            this.column = column;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            result = (prime * result) + column;
            result = (prime * result) + row;
            return result;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (GetType() != obj.GetType())
            {
                return false;
            }
            Coordinate other = (Coordinate)obj;
            if (column != other.column)
            {
                return false;
            }
            if (row != other.row)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return "(" + row + ", " + column + ")";
        }
    }
}