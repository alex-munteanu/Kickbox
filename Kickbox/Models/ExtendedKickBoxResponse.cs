using Newtonsoft.Json;

namespace Kickbox.Models
{
    public sealed class ExtendedKickBoxResponse : KickBoxResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        public override string ToString()
        {
            return $"{nameof(ExtendedKickBoxResponse)} {{" +
                   $"{nameof(this.Message)}='{this.Message}', " +
                   $"{nameof(this.Code)}='{this.Code}'}} " +
                   $"{base.ToString()}";
        }
    }
}
