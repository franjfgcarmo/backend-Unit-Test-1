namespace Tictactoe.Controllers
{
    public interface IColocateControllerVisitor
    {
        void Visit(IPutController putController);

        void Visit(IMoveController moveController);
    }
}