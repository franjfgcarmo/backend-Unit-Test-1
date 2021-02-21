namespace Tictactoe.Controllers
{
    public interface IOperationControllerVisitor
    {
        void Visit(IStartController startController);

        void Visit(IColocateController colocateController);

        void Visit(IContinueController continueController);
    }
}