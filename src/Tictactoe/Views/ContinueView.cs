using Tictactoe.Controllers;
using Tictactoe.Utils;

namespace Tictactoe.Views
{
    public class ContinueView
    {
        public void Interact(IContinueController continueController)
        {
            continueController.Resume(new YesNoDialog("Desea continuar")
            .Read());
        }
    }
}