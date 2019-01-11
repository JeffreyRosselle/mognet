using System.Collections.Generic;

namespace Mognet.Sendgrid.Models
{
    internal class MailPersonalizations
    {
        public IEnumerable<Email> To { get; set; }
        public string Subject { get; set; }
        public IDictionary<string, string> Substitutions { get; set; }
        public IDictionary<string, string> Dynamic_Template_Data { get; set; }
    }
}
