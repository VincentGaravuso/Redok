using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTokBot.enums;
using TikTokBot.Interfaces;
using TikTokBot.ResponseObjects;

namespace TikTokBot.Clients
{
    public class RedditClient : IRedditClient, IDisposable
    {
        private readonly RestClient _client;
        private readonly string _clientId, _clientSecret;
        private string? _token;

        public RedditClient(string clientId, string clientSecret)
        {
            var options = new RestClientOptions("https://oauth.reddit.com");

            _client = new RestClient(options);
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        public async Task<RedditPosts?> GetTopPosts()
        {
            RestRequest request = await BuildRequest("r/livestreamfail/top", Method.Get);
            var response = await _client.ExecuteAsync(request);
            var posts = JsonConvert.DeserializeObject<RedditPosts?>(response.Content);
            return posts;
        }

        
        protected async Task<RestRequest> BuildRequest(string endpoint, Method method)
        {
            _token = string.IsNullOrEmpty(_token) ? await GetToken() : _token;

            RestRequest request = new RestRequest(endpoint) { Method = method };
            request.AddHeader("Authorization", $"Bearer {_token}");
            return request;
        }

        private async Task<string> GetToken()
        {
            var options = new RestClientOptions("https://www.reddit.com");
            using var client = new RestClient(options)
            {
                Authenticator = new HttpBasicAuthenticator(_clientId, _clientSecret),
            };

            var request = new RestRequest("api/v1/access_token")
                .AddParameter("grant_type", "client_credentials");
            var response = await client.PostAsync<TokenResponse>(request);
            return response!.AccessToken;
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
