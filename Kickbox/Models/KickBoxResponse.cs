using Newtonsoft.Json;

namespace Kickbox.Models
{
    public class KickBoxResponse
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("role")]
        public bool Role { get; set; }

        [JsonProperty("free")]
        public bool Free { get; set; }

        [JsonProperty("disposable")]
        public bool Disposable { get; set; }

        [JsonProperty("accept_all")]
        public bool AcceptAll { get; set; }

        [JsonProperty("did_you_mean")]
        public string DidYouMean { get; set; }

        [JsonProperty("sendex")]
        public double Sendex { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        public override string ToString()
        {
            return $"{nameof(KickBoxResponse)}{{" +
                   $"{nameof(this.Result)}='{this.Result}', " +
                   $"{nameof(this.Reason)}='{this.Reason}', " +
                   $"{nameof(this.Role)}='{this.Role}', " +
                   $"{nameof(this.Free)}='{this.Free}', " +
                   $"{nameof(this.Disposable)}='{this.Disposable}', " +
                   $"{nameof(this.AcceptAll)}='{this.AcceptAll}', " +
                   $"{nameof(this.DidYouMean)}='{this.DidYouMean}', " +
                   $"{nameof(this.Sendex)}='{this.Sendex}', " +
                   $"{nameof(this.Email)}='{this.Email}', " +
                   $"{nameof(this.User)}='{this.User}', " +
                   $"{nameof(this.Domain)}='{this.Domain}', " +
                   $"{nameof(this.Success)}='{this.Success}'}}";
        }
    }
}
