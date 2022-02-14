using System.Threading.Tasks;
using Xunit;

namespace Challenge.Tests.TestSupport
{
    public abstract class Given_When_Then_Test_Async : IAsyncLifetime
    {
        public async Task DisposeAsync()
        {
            await Cleanup();
        }

        public async Task InitializeAsync()
        {
            await Given();
            await When();
        }
        protected abstract Task Given();
        protected abstract Task When();
        protected virtual Task Cleanup()
        {
            return Task.CompletedTask;
        }
    }
}
