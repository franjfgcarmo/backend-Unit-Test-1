using System.Diagnostics;
using System.Reflection;
using Xunit.Sdk;

namespace Auxiliar.XUnit.Reusability
{
    /// <summary>
    /// https://www.bricelam.net/2012/04/xunitnet-extensibility.html
    /// https://hamidmosalla.com/2018/08/30/xunit-beforeaftertestattribute-how-to-run-code-before-and-after-test/
    /// </summary>
    public class ExeuctionReusabilityAfterBeforeTest : BeforeAfterTestAttribute
    {
        public override void Before(MethodInfo methodUnderTest)
        {
            Debug.WriteLine($"before: {nameof(ExeuctionReusabilityAfterBeforeTest)}");
        }

        public override void After(MethodInfo methodUnderTest)
        {
            Debug.WriteLine($"After: {nameof(ExeuctionReusabilityAfterBeforeTest)}");
        }
    }
}