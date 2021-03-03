using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tictactoe.Models;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Tictactoe.Test.Models
{
    /*
     * Sut shared. This technique isn´t recommended because it´s dificult to maintein as each test modifies the state of the SUT, affecting
     * the result of the test.
     */
    public class AlphabeticalOrderer : ITestCaseOrderer
    {
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(
            IEnumerable<TTestCase> testCases) where TTestCase : ITestCase =>
            testCases.OrderBy(testCase => testCase.TestMethod.Method.Name);
    }
    [TestCaseOrderer("Tictactoe.Test.Models.AlphabeticalOrderer", "Tictactoe.Test.Models")]
    public class TurnSharedTest
    {
        #region Sut Shared
        private static Turn OUTTurn;

        static TurnSharedTest()
        {
            OUTTurn = new Turn();
        }

        #endregion

        [Fact, ]
        
        public void TestTurn()
        {
            Assert.Equal(Color.XS, OUTTurn.Take());
        }

        [Fact]
        public void TestChange()
        {
            OUTTurn.Change();
            Assert.Equal(Color.OS, OUTTurn.Take());
            OUTTurn.Change();
            Assert.Equal(Color.XS, OUTTurn.Take());
            OUTTurn.Change();
            Assert.Equal(Color.OS, OUTTurn.Take());
            //OUTTurn.Change();
            //Assert.Equal(Color.XS, OUTTurn.Take());
        }

    }
}
