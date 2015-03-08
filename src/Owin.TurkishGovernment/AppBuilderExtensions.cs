using Owin.TurkishGovernment;

namespace Owin
{
    public static class AppBuilderExtensions
    {
        public static IAppBuilder UseTurkishGovernment(this IAppBuilder builder, TurkishGovernmentOptions options = null)
        {
            return builder.Use(typeof(TurkishGovernmentMiddleware), options);
        }
    }
}
