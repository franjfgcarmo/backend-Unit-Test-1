using System;
using System.Diagnostics;

namespace Tictactoe.Utils
{
    public class ClosedInterval
    {
        private int min;

        private int max;

        public ClosedInterval(int min, int max)
        {
            Debug.Assert(min <= max);
            this.min = min;
            this.max = max;
        }

        public int Length()
        {
            return max - min;
        }

        public void Shift(int value)
        {
            min += value;
            max += value;
        }

        public bool Includes(int value)
        {
            return min <= value && value <= max;
        }

        public bool Includes(ClosedInterval closedInterval)
        {
            Debug.Assert(closedInterval != null);
            return this.Includes(closedInterval.min)
                    && this.Includes(closedInterval.max);
        }

        public bool Intersected(ClosedInterval closedInterval)
        {
            Debug.Assert(closedInterval != null);
            return this.Includes(closedInterval.min)
                    || this.Includes(closedInterval.max)
                    || closedInterval.Includes(this);
        }

        public ClosedInterval Intersection(ClosedInterval closedInterval)
        {
            Debug.Assert(closedInterval != null);
            Debug.Assert(this.Intersected(closedInterval));
            return new ClosedInterval(
                    Math.Max(min, closedInterval.min),
                    Math.Min(max, closedInterval.max));
        }

        public ClosedInterval Union(ClosedInterval closedInterval)
        {
            Debug.Assert(closedInterval != null);
            Debug.Assert(this.Intersected(closedInterval));
            return new ClosedInterval(
                    Math.Min(min, closedInterval.min),
                    Math.Max(max, closedInterval.max));
        }

        public int GetMin()
        {
            return min;
        }

        public int GetMax()
        {
            return max;
        }

        public override string ToString()
        {
            return "[" + min + ", " + max + "]";
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            result = prime * result + max;
            result = prime * result + min;
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
            ClosedInterval other = (ClosedInterval)obj;
            if (max != other.max)
                return false;
            if (min != other.min)
                return false;
            return true;
        }
    }
}