using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mognet.Entities;
using Mognet.Sendgrid.Models;
using System;

namespace Mognet.Sendgrid.Test
{
    [TestClass]
    public class SendgridMailShould
    {
        [TestMethod]
        public void Constructor()
        {
            var output = new SendgridMail("api", new EmailAddress("bugs@mail.com", "Bugs"), new EmailAddress("noreply@mail.com", "Test"));

            Assert.IsNotNull(output);
            Assert.AreEqual("api", output.ApiKey);
            Assert.AreEqual("bugs@mail.com", output.To.Email);
            Assert.AreEqual("noreply@mail.com", output.From.Email);
            Assert.AreEqual("Bugs", output.To.Name);
            Assert.AreEqual("Test", output.From.Name);
            Assert.AreEqual(" ", output.Subject);
            Assert.AreEqual(" ", output.Body);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorNoApiKey()
        {
            var output = new SendgridMail("", new EmailAddress("bugs@mail.com", "Bugs"), new EmailAddress("noreply@mail.com", "Test"));
        }
    }
}
