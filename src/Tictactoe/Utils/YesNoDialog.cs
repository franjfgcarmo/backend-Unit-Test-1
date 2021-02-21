using System.Diagnostics;

namespace Tictactoe.Utils
{
    public class YesNoDialog
    {
        private readonly string title;

        public YesNoDialog(string title)
        {
            Debug.Assert(!string.ReferenceEquals(title, null));
            this.title = title;
        }

        public virtual bool Read()
        {
            char answer;
            var io = IO.Instance();
            bool ok;
            do
            {
                answer = io.ReadChar(title + "? (s/n): ");
                ok = answer == 's' || answer == 'S' || answer == 'n' || answer == 'N';
                if (!ok)
                {
                    io.Writeln("El valor debe ser 's' ó 'n'");
                }
            } while (!ok);
            return answer == 's' || answer == 'S';
        }
    }
}