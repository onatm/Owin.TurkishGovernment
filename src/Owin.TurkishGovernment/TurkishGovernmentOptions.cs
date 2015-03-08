using System.Collections.Generic;

namespace Owin.TurkishGovernment
{
    public class TurkishGovernmentOptions
    {
        public IDictionary<string, string[]> TyypHeaders { get; private set; }

        public string Content { get; private set; }

        public TurkishGovernmentOptions(IDictionary<string, string[]> tyypHeaders, string content = null)
        {
            TyypHeaders = tyypHeaders;
            Content = content;
        }
    }
}
