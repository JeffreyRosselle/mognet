using System.Collections.Generic;

namespace Mognet.Sendgrid.Models
{
    internal class MailObject
    {
        public IEnumerable<MailPersonalizations> Personalizations { get; set; }
        public Email From { get; set; }
        public string Template_id { get; set; }
        public IEnumerable<Content> Content { get; set; }
    }
}
