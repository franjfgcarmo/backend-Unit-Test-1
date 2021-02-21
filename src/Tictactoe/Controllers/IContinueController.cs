namespace Tictactoe.Controllers
{
    public interface IContinueController : IOperationController
    {
        void Resume(bool another);
    }
}