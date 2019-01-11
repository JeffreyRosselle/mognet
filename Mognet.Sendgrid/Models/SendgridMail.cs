using Mognet.Entities;
using System;
using System.Collections.Generic;

namespace Mognet.Sendgrid.Models
{
    public class SendgridMail : Mail
    {
        private string _apiKey;

        public string TemplateId { get; set; }
        public string ApiKey
        {
            get
            {
                return _apiKey;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Api Key is required to for sending messages to sendgrid");
                _apiKey = value;
            }
        }
        [Obsolete("With the new Dynamic templates, substitution tags are no longer used. Use TemplateData instead.")]
        public IDictionary<string, string> SubstitutionTags
        {
            get
            {
                return TemplateData;
            }
            set
            {
                TemplateData = value;
            }
        }
        /// <summary>
        /// Dynamic template data or SubstitutionTags
        /// </summary>
        public IDictionary<string, string> TemplateData { get; set; }
        public override string Subject
        {
            get
            {
                if (string.IsNullOrEmpty(base.Subject))
                    return " ";
                return base.Subject;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    base.Subject = " ";
                else
                    base.Subject = value;
            }
        }
        public override string Body
        {
            get
            {
                if (string.IsNullOrEmpty(base.Body))
                    return " ";
                return base.Body;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    base.Body = " ";
                else
                    base.Body = value;
            }
        }

        public SendgridMail(string apiKey, EmailAddress to, EmailAddress from) : base(to, from)
        {
            ApiKey = apiKey.Trim();
            TemplateData = new Dictionary<string, string>();
        }
    }
}
