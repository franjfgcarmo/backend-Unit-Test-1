using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Tictactoe.Utils;
using Xunit;

namespace Tictactoe.Test.Utils
{

    public class TestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]    { 2, 8, new Coordinate(2, 5), true, false, false, Direction.HORIZONTAL },
            new object[] { 1, 6, new Coordinate(6, 6), false, true, false, Direction.VERTICAL }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
