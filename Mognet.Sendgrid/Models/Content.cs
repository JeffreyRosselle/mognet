namespace Mognet.Sendgrid.Models
{
    internal class Content
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public Content(string body, bool isHtml)
        {
            Type = isHtml ? "text/html" : "text/plain";
            Value = body;
        }
    }
}
