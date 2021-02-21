using System.Diagnostics;
using Tictactoe.Models;

namespace Tictactoe.Controllers.Local
{
    public abstract class LocalController
    {
        private readonly Game game;

        protected LocalController(Game game)
        {
            Debug.Assert(game != null);
            this.game = game;
        }

        protected int NumPlayers()
        {
            return game.GetNumPlayers();
        }

        protected State GetState()
        {
            return game.GetState();
        }

        public void SetState(State state)
        {
            Debug.Assert(state != null);
            game.SetState(state);
        }

        public virtual Color Take()
        {
            return game.Take();
        }

        public virtual void Put(Coordinate target)
        {
            Debug.Assert(target != null);
            game.Put(target);
            if (game.ExistTicTacToe())
            {
                game.SetState(State.FINAL);
            }
            else
            {
                game.Change();
            }
        }

        public virtual void Remove(Coordinate origin)
        {
            Debug.Assert(origin != null);
            game.Remove(origin);
        }

        public virtual void Clear()
        {
            game.Clear();
        }

        public virtual bool Empty(Coordinate coordinate)
        {
            Debug.Assert(coordinate != null);
            return game.Empty(coordinate);
        }

        public virtual bool Full(Coordinate coordinate)
        {
            Debug.Assert(coordinate != null);
            return game.Full(coordinate);
        }

        public virtual bool ExistTicTacToe()
        {
            return game.ExistTicTacToe();
        }

        public virtual Color GetColor(Coordinate coordinate)
        {
            Debug.Assert(coordinate != null);
            return game.GetColor(coordinate);
        }
    }
}