using System;

namespace Tictactoe.Models
{
    public class Turn
    {
        private int value;

        public Turn()
        {
            value = 0;
        }

        public Color Take() => (Color)value;

        public void Change() => value = (value + 1) % (Enum.GetNames(typeof(Color)).Length - 1);

        public string AString() => "Turn [value=" + value + "]";

        public override string ToString() => "Turn [value=" + value + "]";
    }
}