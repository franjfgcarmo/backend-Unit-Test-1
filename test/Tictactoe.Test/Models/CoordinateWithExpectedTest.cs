using Tictactoe.Models;
using Xunit;

namespace Tictactoe.Test.Models
{
    /// <summary>
    /// The Assert does not working well, Maybe I may have to use the guard
    /// </summary>
    public class CoordinateWithExpectedTest
    {
        private Coordinate OUTCoordinate;

        [Fact]
        public void TestCoordinate()
        {
            OUTCoordinate = new Coordinate();
            Assert.Equal(0, OUTCoordinate.GetRow());
            Assert.Equal(0, OUTCoordinate.GetColumn());
        }

        [Fact]
        public void TestCoordinateIntInt()
        {
            OUTCoordinate = new Coordinate(1, 2);
            Assert.Equal(1, OUTCoordinate.GetRow());
            Assert.Equal(2, OUTCoordinate.GetColumn());
            OUTCoordinate = new Coordinate(0, 2);
            Assert.Equal(0, OUTCoordinate.GetRow());
            Assert.Equal(2, OUTCoordinate.GetColumn());
        }

        //[Fact]
        //public void TestCoordinateIntIntWithException()
        //{

        //    Assert.Throws<Exception>(() => OUTCoordinate = new Coordinate(-1, 3));           
        //}

        [Fact]
        public void TestCoordinateCoordinate()
        {
            OUTCoordinate = new Coordinate(new Coordinate(1, 2));
            Assert.Equal(1, OUTCoordinate.GetRow());
            Assert.Equal(2, OUTCoordinate.GetColumn());
            OUTCoordinate = new Coordinate(new Coordinate(0, 0));
            Assert.Equal(0, OUTCoordinate.GetRow());
            Assert.Equal(0, OUTCoordinate.GetColumn());
        }

        [Fact]
        public void TestSetRow()
        {
            OUTCoordinate = new Coordinate(1, 2);
            OUTCoordinate.SetRow(2);
            Assert.Equal(2, OUTCoordinate.GetRow());
            Assert.Equal(2, OUTCoordinate.GetColumn());
            OUTCoordinate = new Coordinate(2, 2);
            OUTCoordinate.SetRow(0);
            Assert.Equal(0, OUTCoordinate.GetRow());
            Assert.Equal(2, OUTCoordinate.GetColumn());
        }

        //[Fact]
        //public void testSetRowWithExceptions()
        //{

        //    OUTCoordinate = new Coordinate(1, 2);
        //    Assert.Throws<Microsoft.VisualStudio.TestPlatform.TestHost.DebugAssertException>(() => OUTCoordinate.SetRow(-1));
        //}

        [Fact]
        public void testSetColumn()
        {
            OUTCoordinate = new Coordinate(1, 2);
            OUTCoordinate.SetColumn(0);
            Assert.Equal(1, OUTCoordinate.GetRow());
            Assert.Equal(0, OUTCoordinate.GetColumn());
            OUTCoordinate = new Coordinate(2, 2);
            OUTCoordinate.SetColumn(1);
            Assert.Equal(2, OUTCoordinate.GetRow());
            Assert.Equal(1, OUTCoordinate.GetColumn());
        }

        //[Fact]
        //public void testSetColumnWithException()
        //{
      
        //    OUTCoordinate = new Tictactoe.Models.Coordinate(1, 2);
        //    OUTCoordinate.SetColumn(3);
        //    Assert.Throws<Exception>(() => OUTCoordinate.SetColumn(3));          
        //}

        [Fact]
        public void testDirection()
        {
            Assert.Equal(Tictactoe.Utils.Direction.INVERSE_DIAGONAL,
                    new Coordinate(1, 1).Direction(new Coordinate(2, 0)));
            Assert.Equal(Tictactoe.Utils.Direction.HORIZONTAL,
                    new Coordinate(1, 2).Direction(new Coordinate(1, 1)));
            Assert.Equal(Tictactoe.Utils.Direction.INVERSE_DIAGONAL,
                    new Coordinate(2, 0).Direction(new Coordinate(0, 2)));
            Assert.Equal(Tictactoe.Utils.Direction.VERTICAL,
                    new Coordinate(2, 2).Direction(new Coordinate(0, 2)));
            Assert.Equal(Tictactoe.Utils.Direction.VERTICAL,
                    new Coordinate(1, 2).Direction(new Coordinate(2, 2)));
            Assert.Equal(Tictactoe.Utils.Direction.HORIZONTAL,
                    new Coordinate(0, 1).Direction(new Coordinate(0, 2)));
            Assert.Equal(Tictactoe.Utils.Direction.MAIN_DIAGONAL,
                    new Tictactoe.Models.Coordinate(0, 0).Direction(new Tictactoe.Models.Coordinate(2, 2)));
        }
    }
}