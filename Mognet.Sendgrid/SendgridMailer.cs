using Mognet.Entities;
using Mognet.Sendgrid.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Mognet.Sendgrid
{
    public static class SendgridMailer
    {
        public static async Task<string> Send(SendgridMail mail) =>
            await Client.Send(mail.ApiKey, Convert(mail));

        private static MailObject Convert(SendgridMail mail) =>
            new MailObject
            {
                From = Convert(mail.From),
                Template_id = mail.TemplateId,
                Content = new[] { new Content(mail.Body, mail.IsHtml) },
                Personalizations = Convert(mail.TemplateId, mail.To, mail.Subject, mail.TemplateData)
            };

        private static IEnumerable<MailPersonalizations> Convert(string templateId, EmailAddress to, string subject, IDictionary<string, string> templateData)
        {
            var mailPersonalizations = new MailPersonalizations { Subject = subject, To = new Collection<Email> { Convert(to) } };

            if (!string.IsNullOrWhiteSpace(templateId))
                if (templateId.StartsWith("d-"))
                    mailPersonalizations.Dynamic_Template_Data = templateData;
                else
                    mailPersonalizations.Substitutions = templateData;

            return new Collection<MailPersonalizations>
            {
                mailPersonalizations
            };
        }

        private static Email Convert(EmailAddress email) =>
            new Email
            {
                EmailAddress = email.Email,
                Name = email.Name
            };
    }
}
