namespace Tictactoe.Models
{
    public class Game
    {
        private State state;

        private readonly Turn turn;

        private readonly Board board;

        private const int NUM_PLAYERS = 2;

        public Game()
        {
            state = State.INITIAL;
            turn = new Turn();
            board = new SetBoard();
        }

        public State GetState()
        {
            return state;
        }

        public void SetState(State state)
        {
            this.state = state;
        }

        public Color Take()
        {
            return turn.Take();
        }

        public void Change()
        {
            turn.Change();
        }

        public bool Full(Coordinate origin)
        {
            return board.Full(origin, turn.Take());
        }

        public bool Empty(Coordinate target)
        {
            return board.Empty(target);
        }

        public int GetNumPlayers()
        {
            return NUM_PLAYERS;
        }

        public void Put(Coordinate target)
        {
            board.Put(target, turn.Take());
        }

        public void Remove(Coordinate origin)
        {
            board.Remove(origin, turn.Take());
        }

        public void Clear()
        {
            board.Clear();
        }

        public bool Complete()
        {
            return board.Complete();
        }

        public bool ExistTicTacToe()
        {
            return board.ExistTicTacToe(turn.Take());
        }

        public Color GetColor(Coordinate coordinate)
        {
            return board.GetColor(coordinate);
        }
    }
}