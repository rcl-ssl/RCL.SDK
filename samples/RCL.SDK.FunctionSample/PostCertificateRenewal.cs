using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace RCL.LetsEncrypt.SDK.FunctionSample
{
    public class PostCertificateRenewal
    {
        private readonly ICertificateService _certificateService;

        public PostCertificateRenewal(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [FunctionName("PostCertificateRenewal")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req)
        {
            List<CertificateResponse> lstCertificateResponse = await _certificateService
                .PostCertificateRenewalAsync();

            return new OkObjectResult(lstCertificateResponse);
        }
    }
}
