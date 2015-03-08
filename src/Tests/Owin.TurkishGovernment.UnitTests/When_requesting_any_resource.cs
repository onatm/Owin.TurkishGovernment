using FluentAssertions;
using Microsoft.Owin.Testing;
using NUnit.Framework;

namespace Owin.TurkishGovernment.UnitTests
{
    [TestFixture]
    public class When_requesting_any_resource
    {
        private int _statusCode;

        [TestFixtureSetUp]
        public void Setup()
        {
            using (var server = TestServer.Create(app =>
            {
                app.UseTurkishGovernment();
                app.Run(context => context.Response.WriteAsync("Unit Testing"));
            }))
            {
                var response = server.HttpClient.GetAsync("/").Result;
                _statusCode = ((int) response.StatusCode);
            }
        }

        [Test]
        public void it_should_return_451_unavailable_for_legal_reasons()
        {
            _statusCode.Should().Be(TyypStatusCode.UnavailableForLegalReasons);
        }
    }
}
