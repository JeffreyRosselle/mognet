using Mognet.Entities.Helpers;
using System;

namespace Mognet.Entities
{
    public class EmailAddress
    {
        private string _email;

        public string Name { get; set; }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Email addres is required");
                if (!Validation.IsValidEmail(value))
                    throw new FormatException("Not a correct email address");
                _email = value;
            }
        }

        public EmailAddress(string email, string name = null)
        {
            Name = name?.Trim();
            Email = email.Trim();
        }
    }
}
