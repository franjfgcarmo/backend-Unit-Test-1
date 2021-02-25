using Tictactoe.Models;
using Xunit;

namespace Tictactoe.Test.Models
{
    public class TurnWithConstructorTest
    {
        private readonly Turn _turn;

        public TurnWithConstructorTest()
        {
            _turn = new Turn();
        }

        [Fact]
        public void TestTurn()
        {
            Assert.Equal(Color.XS, _turn.Take());
        }
        [Fact]
        public void TestChange()
        {
            _turn.Change();
            Assert.Equal(Color.OS, _turn.Take());
            _turn.Change();
            Assert.Equal(Color.XS, _turn.Take());
            _turn.Change();
            Assert.Equal(Color.OS, _turn.Take());
        }
    }
}
