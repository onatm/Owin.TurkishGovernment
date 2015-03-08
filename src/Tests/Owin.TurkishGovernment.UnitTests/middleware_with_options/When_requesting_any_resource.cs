using System.Collections.Generic;
using System.Net.Http;
using FluentAssertions;
using Microsoft.Owin.Testing;
using NUnit.Framework;

namespace Owin.TurkishGovernment.UnitTests.middleware_with_options
{
    [TestFixture]
    public class When_requesting_any_resource
    {
        private IEnumerable<string> _responseHeaders;
        private string _responseMessage;
        private const string XTyypTallmanValue = "HULOG";
        private const string TestContent = "BASGAN";

        [TestFixtureSetUp]
        public void Setup()
        {
            using (var server = TestServer.Create(app =>
            {
                var tyypHeaders =
                    new Dictionary<string, string[]>
                    {
                        { TyypHeader.XTyypTallman, new[] { XTyypTallmanValue } }
                    };

                app.UseTurkishGovernment(new TurkishGovernmentOptions(tyypHeaders, TestContent));
                app.Run(context => context.Response.WriteAsync("Unit Testing"));
            }))
            {
                var response = server.HttpClient.GetAsync("/").Result;
                _responseHeaders = response.Headers.GetValues(TyypHeader.XTyypTallman);
                _responseMessage = response.Content.ReadAsStringAsync().Result;
            }
        }

        [Test]
        public void it_should_return_tyyp_headers()
        {
            _responseHeaders.Should().Contain(XTyypTallmanValue);
        }

        [Test]
        public void it_should_return_correct_content()
        {
            _responseMessage.Should().Be(TestContent);
        }
    }
}
