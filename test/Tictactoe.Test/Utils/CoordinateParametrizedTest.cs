using Tictactoe.Utils;
using Xunit;

namespace Tictactoe.Test.Utils
{
    /// <summary>
    /// https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/
    /// https://andrewlock.net/creating-a-custom-xunit-theory-test-dataattribute-to-load-data-from-json-files/
    /// https://andrewlock.net/creating-strongly-typed-xunit-theory-test-data-with-theorydata/
    /// https://hamidmosalla.com/2017/02/25/xunit-theory-working-with-inlinedata-memberdata-classdata/
    /// </summary>
    public class CoordinateParametrizedTest
    {
        //only for constants
        [Theory]
        [InlineData(2, 8, 2, 5, true, false, false, Direction.HORIZONTAL)]
        [InlineData(1, 6, 6, 6, false, true, false, Direction.VERTICAL)]

        public void TestInRow(int row, int colum, int rowCoordinate, int columCoordinate, bool expectedInRow, bool expectedInColumn, bool expectedInMainDiagonal, Direction direction)
        {
            var OUTCoordinate = new Coordinate(rowCoordinate, columCoordinate);
            var coordinate = new Coordinate(row, colum);
            Assert.Equal(expectedInRow, OUTCoordinate.InRow(coordinate));
        }
        #region MyRegion
        /*
         * ClassData is another attribute that we can use with our theory, with ClassData we have more 
         * flexibility and less clutter.
         * This class must implement IEnumerable<object[]>, where each item returned is an array of objects 
         * to use as the method parameters. 
         */
        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void TestInRowWithClassData(int row, int colum, Coordinate coordinate, bool expectedInRow, bool expectedInColumn, bool expectedInMainDiagonal, Direction direction)
        {
            var OUTCoordinate = new Coordinate(row, colum);
            Assert.Equal(expectedInRow, OUTCoordinate.InRow(coordinate));
        }
        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void TestInColumnWithClassData(int row, int colum, Coordinate coordinate, bool expectedInRow, bool expectedInColumn, bool expectedInMainDiagonal, Direction direction)
        {
            var OUTCoordinate = new Coordinate(row, colum);
            Assert.Equal(expectedInColumn, OUTCoordinate.InColumn(coordinate));
        }
        #endregion

    }
}
