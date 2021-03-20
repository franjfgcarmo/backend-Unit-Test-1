using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Auxiliar.XUnit.Reusability
{
    public class ReusabilityAsyncLifetime : IAsyncLifetime
    {
        //https://mderriey.com/2017/09/04/async-lifetime-with-xunit/
        //https://dev.to/tswiftma/initialize-asynchronous-data-in-xunit-collections-for-sharing-data-between-tests-39hc
        private readonly ITestOutputHelper output;

        public ReusabilityAsyncLifetime(ITestOutputHelper output)
        {
            this.output = output;
        }

        public async Task DisposeAsync()
        {
            output.WriteLine($"{nameof(DisposeAsync)}");
            await Task.CompletedTask;
        }

        public async Task InitializeAsync()
        {
            output.WriteLine($"{nameof(InitializeAsync)}");
            await Task.CompletedTask;
        }
        [Fact]
        public void Test1() {
            output.WriteLine($"{nameof(Test1)}");
        }
        [Fact]
        public void Test2() {
            output.WriteLine($"{nameof(Test2)}");
        }
    }
}
