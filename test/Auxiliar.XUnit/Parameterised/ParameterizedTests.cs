using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Auxiliar.XUnit.Parameterised
{

    public class ParameterizedTests
    {
        //todo: Fran
        //https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/
        public bool IsOddNumber(int number)
        {
            return number % 2 != 0;
        }

        public bool IsAboveFourteen(Person person)
        {
            return person.Age > 14;
        }

        public static IEnumerable<object[]> GetNumbers()
        {
            yield return new object[] { 5, 1, 3, 9 };
            yield return new object[] { 7, 1, 5, 3 };
        }
        #region MyRegion

        #endregion
        [Theory]
        [MemberData(nameof(GetNumbers))]
        public void AllNumbers_AreOdd_WithMemberData(int a, int b, int c, int d)
        {
            Assert.True(IsOddNumber(a));
            Assert.True(IsOddNumber(b));
            Assert.True(IsOddNumber(c));
            Assert.True(IsOddNumber(d));
        }
        #region Loading data from a property or method on a different class
        /*
         * Loading data from a property or method on a different class
         *  This option is sort of a hybrid between the [ClassData] attribute and the [MemberData] 
         *  attribute usage you've seen so far. Instead of loading data from a property or method on the test 
         *  class, you load data from a property or method on some other specified type:
         */
        [Theory]
        [MemberData(nameof(TestDataGenerator.GetNumbersFromDataGenerator), MemberType = typeof(TestDataGenerator))]
        public void AllNumbers_AreOdd_WithMemberData_FromDataGenerator(int a, int b, int c, int d)
        {
            Assert.True(IsOddNumber(a));
            Assert.True(IsOddNumber(b));
            Assert.True(IsOddNumber(c));
            Assert.True(IsOddNumber(d));
        }

        [Theory]
        [MemberData(nameof(TestDataGenerator.GetPersonFromDataGenerator), MemberType = typeof(TestDataGenerator))]
        public void AllPersons_AreAbove14_WithMemberData_FromDataGenerator(Person a, Person b, Person c, Person d)
        {
            Assert.True(IsAboveFourteen(a));
            Assert.True(IsAboveFourteen(b));
            Assert.True(IsAboveFourteen(c));
            Assert.True(IsAboveFourteen(d));
        }
        #endregion

    }
}
