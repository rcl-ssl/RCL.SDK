using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace RCL.SDK.FunctionSample
{
    public class GetCertificateList
    {
        private readonly ICertificateService _certificateService;

        public GetCertificateList(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [FunctionName("GetCertificateList")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
        {
            List<CertificateResponse> lstCertificateResponses = await _certificateService
                 .GetCertificatesListAsync();

            return new OkObjectResult(lstCertificateResponses);
        }
    }
}
