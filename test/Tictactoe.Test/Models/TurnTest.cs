using System;
using System.Collections.Generic;
using System.Text;
using Tictactoe.Models;
using Xunit;

namespace Tictactoe.Test.Models
{
    public class TurnTest
    {
        [Fact]
        public void TurnTset()
        {
            //arrage
            Turn turn;
            //act
            turn = new Turn();
            var resultColor = turn.Take();
            //assert
            Color colorExpected = Color.XS;
            Assert.Equal(colorExpected, resultColor);
        }
        #region [test is coupled to the code]
        /*This test is coupled to the code, if tomorrow someone change the code of the test,
         and doesn`t change the test name, can make us go crazy.
        The TestChange method of the TurnCompactTest class does this three tests in one
         */
        [Fact]
        public void TestOneChange()
        {
            //arrage
            Turn turn = new Turn();
            //act
            turn.Change();
            var resultColor = turn.Take();
            //assert
            Color colorExpected = Color.OS;
            Assert.Equal(colorExpected, resultColor);
        }
        [Fact]
        public void TestTwoChange()
        {
            //arrage
            Turn turn = new Turn();
            //act
            turn.Change();
            turn.Change();
            var resultColor = turn.Take();
            //assert
            Color colorExpected = Color.XS;
            Assert.Equal(colorExpected, resultColor);
        }
        [Fact]
        public void TestThreeChange()
        {
            //arrage
            Turn turn = new Turn();
            //act
            turn.Change();
            turn.Change();
            turn.Change();
            var resultColor = turn.Take();
            //assert
            Color colorExpected = Color.OS;
            Assert.Equal(colorExpected, resultColor);
        }
        #endregion


    }
}
