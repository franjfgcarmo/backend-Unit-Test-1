using Tictactoe.Controllers;
using Tictactoe.Utils;

namespace Tictactoe.Views
{
    public class StartView
    {
        public void Interact(IStartController startController)
        {
            int users = new LimitedIntDialog("Cuántos usuarios?", 0, 2).Read();
            startController.Start(users);
            new BoardView(startController).Write();
        }
    }
}