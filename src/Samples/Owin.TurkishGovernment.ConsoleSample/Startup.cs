using System.Collections.Generic;

namespace Owin.TurkishGovernment.ConsoleSample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var tyypHeaders =
                new Dictionary<string, string[]>
                {
                    { TyypHeader.XTyypTallman, new[] { "HULOG" } }
                };

            app.UseTurkishGovernment(new TurkishGovernmentOptions(tyypHeaders));
            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hulog Basgan!");
            });
        }
    }
}
