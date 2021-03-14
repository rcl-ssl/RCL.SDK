using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RCL.SDK
{
    internal class CertificateService : ICertificateService
    {
        private readonly IHttpService _httpService;
        private readonly IOptions<RCLSDKOptions> _options;

        public CertificateService(
            IHttpService httpService,
            IOptions<RCLSDKOptions> options)
        {
            _httpService = httpService;
            _options = options;
        }

        public async Task<CertificateResponse> GetCertificateAsync(string certificateName)
        {
            CertificateResponse certificateResponse = await _httpService
                .GetAsync<CertificateResponse>($"{_options.Value.apiEndPoint}/api/v2/Certificate?name={certificateName}");

            return certificateResponse;
        }

        public async Task<CertificateResponse> PostCertificateAsync(CertificateResponse certificateResponse)
        {
            CertificateResponse _certificateResponse = await _httpService
                .PostAsync<CertificateResponse>($"{_options.Value.apiEndPoint}/api/v2/Certificate",certificateResponse);

            return certificateResponse;
        }

        public async Task<List<CertificateResponse>> GetCertificatesListAsync()
        {
            List<CertificateResponse> certificateResponses = await _httpService
                .GetAsync<List<CertificateResponse>>($"{_options.Value.apiEndPoint}/api/v2/CertificateList");

            return certificateResponses;
        }

        public async Task<List<CertificateResponse>> PostCertificateRenewalAsync(bool includeKeyVaultAccessToken = false)
        {
            AccessTokenPayload accessTokenPayload = new AccessTokenPayload
            {
                keyVaultAccessToken = string.Empty
            };

            if(includeKeyVaultAccessToken)
            {
                string keyVaultAccessToken = await _httpService
                    .GetAccessToken(_options.Value.keyVaultResource);

                accessTokenPayload.keyVaultAccessToken = keyVaultAccessToken;
            }

            List<CertificateResponse> certificateResponses = await _httpService
                .PostAsync<List<CertificateResponse>>($"{_options.Value.apiEndPoint}/api/v2/CertificateRenewal",accessTokenPayload);

            return certificateResponses;
        }
    }
}
