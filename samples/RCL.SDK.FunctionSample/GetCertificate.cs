using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace RCL.LetsEncrypt.SDK.FunctionSample
{
    public class GetCertificate
    {
        private readonly ICertificateService _certificateService;

        public GetCertificate(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [FunctionName("GetCertificate")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
        {
            string name = req.Query["name"];

            CertificateResponse certificateResponse = await _certificateService
                .GetCertificateAsync(name);

            return new OkObjectResult(certificateResponse);
        }
    }
}
