using System.Diagnostics;
using Tictactoe.Models;
using Tictactoe.Utils;

namespace Tictactoe.Controllers.Local
{
    public class LocalColocateControllerBuilder
    {
        private readonly LocalColocateController[,] colocateControllerArray;

        private readonly Game game;

        public LocalColocateControllerBuilder(Game game)
        {
            this.game = game;
            colocateControllerArray = new LocalColocateController[game.GetNumPlayers(), 2];
        }

        public void Build(int users)
        {
            Debug.Assert(new ClosedInterval(0, game.GetNumPlayers()).Includes(users));
            LocalCoordinateController[,] coordinateController = new LocalCoordinateController[2, 2];
            for (int i = 0; i < game.GetNumPlayers(); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (i < users)
                    {
                        coordinateController[i, j] = new LocalUserCoordinateController(
                                game);
                    }
                    else
                    {
                        coordinateController[i, j] = new LocalRandomCoordinateController(
                                game);
                    }
                }
            }
            for (int i = 0; i < game.GetNumPlayers(); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        colocateControllerArray[i, j] = new LocalPutController(game,
                                coordinateController[i, j]);
                    }
                    else
                    {
                        colocateControllerArray[i, j] = new LocalMoveController(game,
                                coordinateController[i, j]);
                    }
                }
            }
        }

        public LocalColocateController GetColocateController()
        {
            int player = (int)game.Take();
            if (!game.Complete())
            {
                return colocateControllerArray[player, 0];
            }
            else
            {
                return colocateControllerArray[player, 1];
            }
        }
    }
}