using Tictactoe.Models;
using Tictactoe.Utils;

namespace Tictactoe.Views
{
    internal class ColorView
    {
        private readonly Color color;
        private static readonly char[] COLORS = { 'x', 'o', '_' };

        private readonly IO io = IO.Instance();

        public ColorView(Color color)
        {
            this.color = color;
        }

        public void Write(string title)
        {
            io.Write(title + this.ToChar());
        }

        public void Writeln(string title)
        {
            this.Write(title);
            io.Writeln();
        }

        public void WriteWinner()
        {
            io.Writeln("Victoria!!!! " + this.ToChar() + "! " + this.ToChar()
                    + "! " + this.ToChar() + "! Victoria!!!!");
        }

        private char ToChar()
        {
            return COLORS[(int)color];
        }
    }
}