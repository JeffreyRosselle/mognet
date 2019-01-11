using System;

namespace Mognet.Entities
{
    public abstract class Mail
    {
        private EmailAddress _to;
        private EmailAddress _from;

        public EmailAddress To
        {
            get
            {
                return _to;
            }
            set
            {
                _to = value ?? throw new ArgumentNullException("To send a mail, you need an address to send it to");
            }
        }
        public EmailAddress From
        {
            get
            {
                return _from;
            }
            set
            {
                _from = value ?? throw new ArgumentNullException("Emails cannot be send anonymously");
            }
        }
        public virtual string Subject { get; set; }
        public virtual string Body { get; set; }
        public bool IsHtml { get; set; }

        protected Mail(EmailAddress to, EmailAddress from)
        {
            To = to;
            From = from;
        }
    }
}
