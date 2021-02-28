using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace Auxiliar.XUnit.Reusability
{
    public class ExeuctionReusabilityTest : IClassFixture<ExeuctionReusabilityFixture>
    {
        private static int staticMember = 0;
        private readonly ITestOutputHelper output;

        static ExeuctionReusabilityTest()
        {
            staticMember++;
            Debug.WriteLine("static code: " + staticMember);           
        }

        public ExeuctionReusabilityTest()
        {
            staticMember++;
            instanceMember++;
            Debug.WriteLine("constructor: " + staticMember + " and " + instanceMember);
        }

        private int instanceMember;

        [Fact]
        [ExeuctionReusabilityAfterBeforeTest]
        public void Test1()
        {
            staticMember++;
            instanceMember++;
            Debug.WriteLine("test 1: " + staticMember + " and " + instanceMember);
        }

        [Fact]
        [ExeuctionReusabilityAfterBeforeTest]
        public void Test2()
        {
            staticMember++;
            instanceMember++;
            Debug.WriteLine("test 2: " + staticMember + " and " + instanceMember);
        }

        [Fact]
        [ExeuctionReusabilityAfterBeforeTest]
        public void Test3()
        {
            staticMember++;
            instanceMember++;
            Debug.WriteLine("test 3: " + staticMember + " and " + instanceMember);
        }
    }
}