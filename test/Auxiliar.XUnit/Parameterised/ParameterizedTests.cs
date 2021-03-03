using System.Collections.Generic;
using System.Linq;
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

        public static IEnumerable<object[]> Numbers => new List<object[]>
        {
            new object[] { 5, 1, 3, 9 },
            new object[] { 7, 1, 5, 3 }
        };

        public static IEnumerable<object[]> GetData(int numTests)
        {
            var allData = new List<object[]>
            {
                new object[] { 5, 1, 3, 9 },
                new object[] { 7, 1, 5, 3 }
            };
            return allData.Take(numTests);
        }

        #region loading-data-from-a-method-on-the-test-class

        [Theory]
        [MemberData(nameof(GetNumbers))]
        public void Method_AllNumbers_AreOdd_WithMemberData(int a, int b, int c, int d)
        {
            Assert.True(IsOddNumber(a));
            Assert.True(IsOddNumber(b));
            Assert.True(IsOddNumber(c));
            Assert.True(IsOddNumber(d));
        }

        #endregion loading-data-from-a-method-on-the-test-class

        #region loading-data-from-a-property-on-the-test-class

        [Theory]
        [MemberData(nameof(Numbers))]
        public void Property_AllNumbers_AreOdd_WithMemberData(int a, int b, int c, int d)
        {
            Assert.True(IsOddNumber(a));
            Assert.True(IsOddNumber(b));
            Assert.True(IsOddNumber(c));
            Assert.True(IsOddNumber(d));
        }

        #endregion loading-data-from-a-property-on-the-test-class

        #region loading-data-from-a-method-with-parameter-on-the-test-class

        [Theory]
        [MemberData(nameof(GetData), parameters: 1)]
        public void Method_With_Parameter_AllNumbers_AreOdd_WithMemberData(int a, int b, int c, int d)
        {
            Assert.True(IsOddNumber(a));
            Assert.True(IsOddNumber(b));
            Assert.True(IsOddNumber(c));
            Assert.True(IsOddNumber(d));
        }

        #endregion loading-data-from-a-method-with-parameter-on-the-test-class

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

        #endregion Loading data from a property or method on a different class
    }
}