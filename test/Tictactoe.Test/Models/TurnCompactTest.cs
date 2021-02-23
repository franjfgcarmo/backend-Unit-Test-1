using System;
using System.Collections.Generic;
using System.Text;
using Tictactoe.Models;
using Xunit;

namespace Tictactoe.Test.Models
{
    public class TurnCompactTest
    {
        [Fact]
        public void TestTurn()
        {
            var turn= new Turn();
            Assert.Equal(Color.XS, turn.Take());
        }
        [Fact]
        public void TestChange()
        {
            var turn = new Turn();
            turn.Change();
            Assert.Equal(Color.OS, turn.Take());
            turn.Change();
            Assert.Equal(Color.XS, turn.Take());
            turn.Change();
            Assert.Equal(Color.OS, turn.Take());
        }
    }
}
