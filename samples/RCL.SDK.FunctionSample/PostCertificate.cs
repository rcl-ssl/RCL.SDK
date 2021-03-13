using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace RCL.SDK.FunctionSample
{
    public class PostCertificate
    {
        private readonly ICertificateService _certificateService;

        public PostCertificate(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [FunctionName("PostCertificate")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req)
        {

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            CertificateResponse data = JsonConvert.DeserializeObject<CertificateResponse>(requestBody);

            CertificateResponse certificateResponse = await _certificateService.
                PostCertificateAsync(data);

            return new OkObjectResult(certificateResponse);
        }
    }
}
