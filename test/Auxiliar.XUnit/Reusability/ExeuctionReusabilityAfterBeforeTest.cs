using System.Diagnostics;
using System.Reflection;
using Xunit.Sdk;

namespace Auxiliar.XUnit.Reusability
{
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