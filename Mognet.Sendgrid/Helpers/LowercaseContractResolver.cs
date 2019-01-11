using Newtonsoft.Json.Serialization;

namespace Mognet.Sendgrid.Helpers
{
    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName) =>
            propertyName.ToLower();
    }
}
