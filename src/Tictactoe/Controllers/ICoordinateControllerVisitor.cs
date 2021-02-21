namespace Tictactoe.Controllers
{
    public interface ICoordinateControllerVisitor
    {
        void Visit(IUserCoordinateController userCoordinateController);

        void Visit(IRandomCoordinateController randomCoordinateController);
    }
}