using Mognet.Sendgrid.Helpers;
using Mognet.Sendgrid.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mognet.Sendgrid
{
    internal static class Client
    {
        internal static async Task<string> Send(string apiKey, MailObject mailObject)
        {
            using (var client = new HttpClient())
            {
                var jsonMail = JsonConvert.SerializeObject(mailObject, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new LowercaseContractResolver()
                });

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                var response = await client.PostAsync("https://api.sendgrid.com/v3/mail/send", new StringContent(jsonMail, Encoding.UTF8, "application/json"));
                return response.IsSuccessStatusCode ? "success" : await response.Content.ReadAsStringAsync();
            }
        }
    }
}
