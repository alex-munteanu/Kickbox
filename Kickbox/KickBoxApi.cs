using System.Net.Http;
using System.Threading.Tasks;
using Kickbox.Helpers;
using Kickbox.Models;
using Newtonsoft.Json;

namespace Kickbox
{
    public sealed class KickBoxApi
    {
        private readonly string apiKey;

        private readonly string apiUrl;

        public KickBoxApi(string apiKey)
        {
            this.apiKey = apiKey;

            this.apiUrl = "https://api.kickbox.io/v2/verify";
        }

        public async Task<bool> VerifyAsync(string emailAddress, int? timeout = null)
        {
            var responseObject = await this.VerifyWithResponse(emailAddress, timeout);

            return responseObject.Result == Result.Deliverable;
        }

        public async Task<ExtendedKickBoxResponse> VerifyWithResponse(string emailAddress, int? timeout = null)
        {
            var httpClient = new HttpClient();

            var requestObject = new KickBoxRequest
            {
                ApiKey = this.apiKey,
                Email = emailAddress,
                Timeout = timeout ?? 30
            };

            var response = await httpClient.GetAsync($"{this.apiUrl}?{requestObject.ToQueryString()}");

            var responseString = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<ExtendedKickBoxResponse>(responseString);

            return responseObject;
        }
    }
}
