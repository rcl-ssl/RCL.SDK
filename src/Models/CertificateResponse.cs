using System;

namespace RCL.SDK
{
    public class CertificateResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime expiryDate { get; set; }
        public DateTime? remoteCreateDate { get; set; }
        public string remoteCreate { get; set; }
        public string target { get; set; }
        public string renewal { get; set; }
        public string pemUri { get; set; }
        public string pfxUri { get; set; }
        public string crtUri { get; set; }
        public string cerUri { get; set; }
        public string privateKeyUri { get; set; }
        public string certificateUri { get; set; }
        public string intermediateCertificateUri { get; set; }
        public string fullChainCertificateUri { get; set; }
        public string pfxpwd { get; set; }
    }
}
