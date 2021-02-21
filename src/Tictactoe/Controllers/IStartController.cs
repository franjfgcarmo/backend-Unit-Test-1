namespace Tictactoe.Controllers
{
    public interface IStartController : IOperationController, IPresenterController
    {
        void Start(int users);
    }
}