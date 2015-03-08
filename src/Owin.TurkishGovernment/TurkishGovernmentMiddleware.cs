using System.Threading.Tasks;
using Microsoft.Owin;

namespace Owin.TurkishGovernment
{
    public class TurkishGovernmentMiddleware : OwinMiddleware
    {
        private readonly TurkishGovernmentOptions _options;

        public TurkishGovernmentMiddleware(OwinMiddleware next, TurkishGovernmentOptions options = null)
            : base(next)
        {
            _options = options;
        }

        public override async Task Invoke(IOwinContext context)
        {
            context.Response.StatusCode = TyypStatusCode.UnavailableForLegalReasons;

            if (_options != null)
            {
                foreach (var tyypHeader in _options.TyypHeaders)
                {
                    context.Response.Headers.Add(tyypHeader);
                }

                if (_options.Content != null)
                {
                    await context.Response.WriteAsync(_options.Content);
                }
            }
        }
    }
}
