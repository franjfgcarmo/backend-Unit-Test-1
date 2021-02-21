using Tictactoe.Models;

namespace Tictactoe.Controllers.Local
{
    public class LocalLogic : ILogic
    {
        private readonly Game game;

        private readonly LocalColocateControllerBuilder colocateControllerBuilder;

        private readonly LocalStartController startController;

        private readonly LocalContinueController continueController;

        public LocalLogic()
        {
            game = new Game();
            colocateControllerBuilder = new LocalColocateControllerBuilder(game);
            startController = new LocalStartController(game, colocateControllerBuilder);
            continueController = new LocalContinueController(game);
        }

        public IOperationController GetOperationController()
        {
            return (game.GetState()) switch
            {
                State.INITIAL => startController,
                State.IN_GAME => colocateControllerBuilder.GetColocateController(),
                State.FINAL => continueController,
                _ => null,
            };
        }
    }
}