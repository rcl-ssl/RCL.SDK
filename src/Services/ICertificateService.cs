using System.Collections.Generic;
using System.Threading.Tasks;

namespace RCL.SDK
{
    public interface ICertificateService
    {
        Task<CertificateResponse> GetCertificateAsync(string certificateName);
        Task<CertificateResponse> PostCertificateAsync(CertificateResponse certificateResponse);
        Task<List<CertificateResponse>> GetCertificatesListAsync();
        Task<List<CertificateResponse>> PostCertificateRenewalAsync(bool includeKeyVaultAccessToken = false);
    }
}
