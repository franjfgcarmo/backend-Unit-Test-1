using System;
using System.Diagnostics;

namespace Auxiliar.XUnit.Reusability
{
    public class ExeuctionReusabilityFixture : IDisposable
    {
        public ExeuctionReusabilityFixture()
        {
            Debug.WriteLine($"before class: {nameof(ExeuctionReusabilityFixture)}");
        }

        public void Dispose()
        {
            Debug.WriteLine($"after: {nameof(ExeuctionReusabilityFixture)}");
        }
    }
}