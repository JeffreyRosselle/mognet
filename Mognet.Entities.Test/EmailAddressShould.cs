using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mognet.Entities.Test
{
    [TestClass]
    public class EmailAddressShould
    {
        [TestMethod]
        public void CheckEmail()
        {
            var output = new EmailAddress("mail@mail.com", "name");

            Assert.IsNotNull(output);
            Assert.AreEqual("name", output.Name);
            Assert.AreEqual("mail@mail.com", output.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckEmailEmpty()
        {
            var output = new EmailAddress("");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void CheckEmailWrong1()
        {
            var output = new EmailAddress("email");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void CheckEmailWrong2()
        {
            var output = new EmailAddress("#@%^%#$@#$@#.com");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void CheckEmailWrong3()
        {
            var output = new EmailAddress("あいうえお@example.com");
        }
    }
}
