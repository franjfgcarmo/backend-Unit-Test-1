using System.Diagnostics;
using Tictactoe.Controllers;

namespace Tictactoe.Views
{
    public class ConsoleView : IView
    {
        private readonly StartView startView;

        private readonly GameView gameView;

        private readonly ContinueView continueView;

        public ConsoleView()
        {
            startView = new StartView();
            gameView = new GameView();
            continueView = new ContinueView();
        }

        public void Interact(IOperationController operationController)
        {
            Debug.Assert(operationController != null);
            operationController.Accept(this);
        }

        public void Visit(IStartController startController)
        {
            startView.Interact(startController);
        }

        public void Visit(IColocateController colocateController)
        {
            gameView.Interact(colocateController);
        }

        public void Visit(IContinueController continueController)
        {
            continueView.Interact(continueController);
        }
    }
}