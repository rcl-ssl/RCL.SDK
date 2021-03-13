using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RCL.SDK.AspnetSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICertificateService _certificateService;

        public IndexModel(ILogger<IndexModel> logger,
            ICertificateService certificateService)
        {
            _logger = logger;
            _certificateService = certificateService;
        }

        public CertificateResponse CertificateResponse { get; set; }
        public CertificateResponse CertificateResponseUpdate { get; set; }
        public List<CertificateResponse> LstCertificateResponse { get; set; }
        public List<CertificateResponse> LstCertificateResponseRenew { get; set; }

        public async Task OnGetAsync()
        {
            CertificateResponse = await GetCertificateAsync();
            LstCertificateResponse = await GetCertificateListAsync();
            LstCertificateResponseRenew = await PostCertificateRenewalAsync();
            CertificateResponseUpdate = await PostCertificateAsync();
        }


        private async Task<CertificateResponse> GetCertificateAsync()
        {
            return await _certificateService.GetCertificateAsync("shopeneur.com");
        }

        private async Task<List<CertificateResponse>> GetCertificateListAsync()
        {
            return await _certificateService.GetCertificatesListAsync();
        }

        private async Task<List<CertificateResponse>> PostCertificateRenewalAsync()
        {
            return await _certificateService.PostCertificateRenewalAsync(false);
        }

        private async Task<CertificateResponse> PostCertificateAsync()
        {
            CertificateResponse certificateResponse = new CertificateResponse
            {
                id = 123,
                name = "contoso.com",
                remoteCreateDate = DateTime.Now
            };

            return await _certificateService.PostCertificateAsync(certificateResponse);
        }
    }
}
