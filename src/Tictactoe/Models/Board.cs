namespace Tictactoe.Models
{
    public abstract class Board
    {
        public abstract Color GetColor(Coordinate coordinate);

        public abstract bool Complete();

        public abstract bool ExistTicTacToe(Color color);

        public abstract bool Empty(Coordinate coordinate);

        public abstract void Put(Coordinate coordinate, Color color);

        public abstract void Remove(Coordinate coordinate, Color color);

        public abstract bool Full(Coordinate coordinate, Color color);

        public abstract void Clear();
    }
}