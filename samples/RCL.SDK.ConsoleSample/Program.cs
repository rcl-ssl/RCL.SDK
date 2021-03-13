using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RCL.SDK.ConsoleSample
{
    class Program
    {
        private static readonly ICertificateService _certificateService;

        static Program()
        {
            _certificateService = (ICertificateService)Startup
                .ServiceProvider().GetService(typeof(ICertificateService));
        }

        static async Task Main(string[] args)
        {
            CertificateResponse certificateResponse = await GetCertificateAsync();
            Console.WriteLine($"GetCertificate returned : {JsonConvert.SerializeObject(certificateResponse)} \r\n");

            List<CertificateResponse> lstCertificateResponse = await GetCertificateListAsync();
            Console.WriteLine($"GetCertificateList returned : {JsonConvert.SerializeObject(lstCertificateResponse)} \r\n");

            List<CertificateResponse> lstCertificateResponse1 = await PostCertificateRenewalAsync();
            Console.WriteLine($"PostCertificateRenewal returned : {JsonConvert.SerializeObject(lstCertificateResponse1)} \r\n");

            CertificateResponse certificateResponse1 = await PostCertificateAsync();
            Console.WriteLine($"PostCertificate returned : {JsonConvert.SerializeObject(certificateResponse1)} \r\n");
        }

        private async static Task<CertificateResponse> GetCertificateAsync()
        {
            return await _certificateService.GetCertificateAsync("shopeneur.com");
        }

        private async static Task<List<CertificateResponse>> GetCertificateListAsync()
        {
            return await _certificateService.GetCertificatesListAsync();
        }

        private async static Task<List<CertificateResponse>> PostCertificateRenewalAsync()
        {
            return await _certificateService.PostCertificateRenewalAsync(false);
        }

        private async static Task<CertificateResponse> PostCertificateAsync()
        {
            CertificateResponse certificateResponse = new CertificateResponse
            {
                id = 123,
                name = "shopeneur.com",
                remoteCreateDate = DateTime.Now
            };

            return await _certificateService.PostCertificateAsync(certificateResponse);
        }
    }
}
