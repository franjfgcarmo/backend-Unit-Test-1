using System.Diagnostics;

namespace Tictactoe.Utils
{
    public class LimitedIntDialog
    {
        private string title;

        private readonly ClosedInterval limits;

        private readonly ClosedIntervalView limitsView;

        public LimitedIntDialog(string title, int min, int max)
        {
            Debug.Assert(title != null);
            limits = new ClosedInterval(min, max);
            limitsView = new ClosedIntervalView("El valor debe estar entre ", limits);
            LimitedIntDialog limitedIntDialog = this;
            limitedIntDialog.title = title + " " + limitsView + ": ";
        }

        public LimitedIntDialog(string title, int max) : this(title, 1, max)
        {
        }

        public virtual int Read()
        {
            IO io = IO.Instance();
            int value;
            bool ok;
            do
            {
                value = io.ReadInt(title);
                ok = limits.Includes(value);
                if (!ok)
                {
                    limitsView.Writeln();
                }
            } while (!ok);
            return value;
        }
    }
}