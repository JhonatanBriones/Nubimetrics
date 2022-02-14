using Challenge.Tests.TestSupport;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
#nullable disable
namespace Challenge.Tests.UnitTest
{
    public class SearchServiceTests
    {
        public class Given_A_URL_WITH_PARAM_ipone : FunctionalTest
        {
            private string _url;
            private HttpResponseMessage _result;
            protected override Task Given()
            {
                _url = "api/busqueda/ipone";
                return Task.CompletedTask;
            }
            protected override async Task When() => _result = await httpClient.GetAsync(_url);

            [Fact]
            public void Then_It_Should_Return_200_Ok() =>
                _result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        public class Given_A_URL_WITHOUT_PARAMS : FunctionalTest
        {
            private string _url;
            private HttpResponseMessage _result;
            protected override Task Given()
            {
                _url = "api/busqueda/";
                return Task.CompletedTask;
            }
            protected override async Task When() => _result = await httpClient.GetAsync(_url);

            [Fact]
            public void Then_It_Should_Return_404_NotFound() =>
                _result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
