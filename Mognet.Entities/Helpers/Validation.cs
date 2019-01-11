using System.Text.RegularExpressions;

namespace Mognet.Entities.Helpers
{
    internal static class Validation
    {
        internal static bool IsValidEmail(string email)
        {
            try
            {
                return Regex.IsMatch(email,
                       @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                       RegexOptions.IgnoreCase);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}