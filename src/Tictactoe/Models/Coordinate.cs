using System;
using System.Diagnostics;
using Tictactoe.Utils;

namespace Tictactoe.Models
{
    public class Coordinate
    {
        private readonly Utils.Coordinate coordinate;

        public const int DIMENSION = 3;

        private readonly ClosedInterval LIMITS = new ClosedInterval(0, Coordinate.DIMENSION - 1);

        public Coordinate()
        {
            coordinate = new Utils.Coordinate();
        }

        public Coordinate(int row, int column) : this()
        {
            SetRow(row);
            SetColumn(column);
        }

        public Coordinate(Coordinate coordinate) : this(coordinate.coordinate.GetRow(), coordinate.coordinate.GetColumn())
        {
        }

        public void SetRow(int row)
        {
            Debug.Assert(LIMITS.Includes(row));
            coordinate.SetRow(row);
        }

        public void SetColumn(int column)
        {
            Debug.Assert(LIMITS.Includes(column));
            coordinate.SetColumn(column);
        }

        public void Random()
        {
            Random random = new Random((int)Helpers.Helpers.CurrentTimeMillis());
            SetRow(random.Next(Coordinate.DIMENSION));
            SetColumn(random.Next(Coordinate.DIMENSION));
        }

        public Direction Direction(Coordinate coordinate)
        {
            Direction direction = this.coordinate.Direction(coordinate.coordinate);
            if (direction == Utils.Direction.NON_EXISTENT)
            {
                if (InInverse() && coordinate.InInverse())
                    return Utils.Direction.INVERSE_DIAGONAL;
            }
            return direction;
        }

        private bool InInverse()
        {
            return coordinate.GetRow() + coordinate.GetColumn() == Coordinate.DIMENSION - 1;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            result = prime * result
                    + ((coordinate == null) ? 0 : coordinate.GetHashCode());
            return result;
        }

        public override bool Equals(Object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            Coordinate other = (Coordinate)obj;
            if (coordinate == null)
            {
                if (other.coordinate != null)
                    return false;
            }
            else if (!coordinate.Equals(other.coordinate))
                return false;
            return true;
        }

        public Coordinate Clone()
        {
            return new Coordinate(this);
        }

        public override string ToString()
        {
            return "Coordinate " + coordinate;
        }

        public int GetRow()
        {
            return coordinate.GetRow();
        }

        public int GetColumn()
        {
            return coordinate.GetColumn();
        }
    }
}