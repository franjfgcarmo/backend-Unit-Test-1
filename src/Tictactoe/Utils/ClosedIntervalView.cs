using System.Diagnostics;

namespace Tictactoe.Utils
{
    internal class ClosedIntervalView
    {
        private readonly string title;

        private readonly ClosedInterval closedInterval;

        public ClosedIntervalView(string title, ClosedInterval closedInterval)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(title));
            Debug.Assert(closedInterval != null);
            this.title = title;
            this.closedInterval = closedInterval;
        }

        public virtual void Writeln() => IO.Instance().Writeln(title + " " + ToString());

        public override string ToString() => $"[{closedInterval.GetMin()}, {closedInterval.GetMax()}]";
    }
}