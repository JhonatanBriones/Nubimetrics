using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace Challenge.Tests.TestSupport
{
    public abstract class FunctionalTest : Given_When_Then_Test_Async
    {
        protected HttpClient httpClient { get; }
        protected FunctionalTest()
        {
            var application = new WebApplicationFactory<Program>()
                 .WithWebHostBuilder(builder =>
                 {
                     builder.UseCommonConfiguration();
                     builder.UseEnvironment("Test");
                     builder.ConfigureServices(ConfigureTestServices);
                 });
            httpClient = application.CreateClient();
        }
        protected virtual void ConfigureTestServices(IServiceCollection services)
        {

        }
    }
}
