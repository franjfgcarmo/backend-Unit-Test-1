using Tictactoe.Controllers;
using Tictactoe.Controllers.Local;
using Tictactoe.Views;

namespace Tictactoe
{
    internal class TicTacToe
    {
        private ILogic logic;

        private IView view;

        public TicTacToe(IView view, ILogic logic)
        {
            this.view = view;
            this.logic = logic;
        }

        public void play()
        {
            IOperationController controller;
            do
            {
                controller = logic.GetOperationController();
                if (controller != null)
                {
                    view.Interact(controller);
                }
            } while (controller != null);
        }

        public static void Main(string[] args)
        {
            new TicTacToe(new ConsoleView(), new LocalLogic()).play();
        }
    }
}