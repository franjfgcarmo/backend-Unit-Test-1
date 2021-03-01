using System;
using System.Collections.Generic;
using System.Text;
using Tictactoe.Utils;
using Xunit;

namespace Tictactoe.Test.Utils
{
    public class CoordinateParametrizedTest
    {
        [Theory]
        [InlineData(2, 8, 2, 5, true, false, false,Direction.HORIZONTAL)]
        [InlineData(1, 6, 6,6, false, true, false, Direction.VERTICAL)]

        public void TestInRow(int row, int colum, int rowCoordinate, int columCoordinate, bool expectedInRow, bool expectedInColumn, bool expectedInMainDiagonal, Direction direction)
        {
            var OUTCoordinate = new Coordinate(rowCoordinate, columCoordinate);
            var coordinate = new Coordinate(row, colum);
            Assert.Equal(expectedInRow, OUTCoordinate.InRow(coordinate));
        }
    }
}
