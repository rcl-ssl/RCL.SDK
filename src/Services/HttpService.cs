using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RCL.Authorization.Core;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RCL.SDK
{
    internal class HttpService : IHttpService
    {
        private static readonly HttpClient _httpClient;
        private readonly IAuthTokenService _authTokenService;
        private readonly IOptions<RCLSDKOptions> _options;
        
        static HttpService()
        {
            _httpClient = new HttpClient();
        }

        public HttpService(
            IAuthTokenService authTokenService,
            IOptions<RCLSDKOptions> options)
        {
            _authTokenService = authTokenService;
            _options = options;
        }

        public async Task<T> GetAsync<T>(string uri) where T:class
        {
            try
            {
                AuthToken authToken = await _authTokenService
                    .GetAuthTokenAsync(_options.Value.armResource);

                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Authorization =
                  new AuthenticationHeaderValue("Bearer", authToken.access_token);

                HttpResponseMessage response = await _httpClient
                    .GetAsync(uri);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                 T obj = JsonConvert.DeserializeObject<T>(responseBody);

                return obj;
            }
            catch(Exception ex)
            {
                throw new Exception($"Failure in RCL SDK GET request. {ex.Message}");
            }
        }

        public async Task<T> PostAsync<T>(string uri, object payload) where T : class
        {
            try
            {
                AuthToken authToken = await _authTokenService
                    .GetAuthTokenAsync(_options.Value.armResource);

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", authToken.access_token);

                string payloadStr = JsonConvert.SerializeObject(payload);
                StringContent content = new StringContent(payloadStr, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient
                  .PostAsync(uri, content);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                T obj = JsonConvert.DeserializeObject<T>(responseBody);

                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failure in RCL SDK POST request. {ex.Message}");
            }
        }

        public async Task<string> GetAccessToken(string resource)
        {
            try
            {
                AuthToken authToken = await _authTokenService.GetAuthTokenAsync(resource);
                return authToken.access_token;
            }
            catch(Exception ex)
            {
                throw new Exception($"Could not obtain access token. {ex.Message}");
            }
        }
    }
}
