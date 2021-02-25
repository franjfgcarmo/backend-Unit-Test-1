using System;
using System.Collections.Generic;
using System.Text;
using Tictactoe.Models;
using Xunit;

namespace Tictactoe.Test.Models
{
    public class TurnWithAttributesTest
    {
        private Turn _turn;

        private void Arrange() {
            _turn = new Turn();
        }

        [Fact]
        public void TestTurn()
        {
            Arrange();
            Assert.Equal(Color.XS, _turn.Take());
        }
        [Fact]
        public void TestChange()
        {
            Arrange();
            _turn.Change();
            Assert.Equal(Color.OS, _turn.Take());
            _turn.Change();
            Assert.Equal(Color.XS, _turn.Take());
            _turn.Change();
            Assert.Equal(Color.OS, _turn.Take());
        }
    }
}
