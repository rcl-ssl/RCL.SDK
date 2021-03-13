using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RCL.SDK.Tests
{
    [TestClass]
    public class CertificateServiceTest
    {
        private readonly ICertificateService _certificateService;

        public CertificateServiceTest()
        {
            _certificateService = (ICertificateService)DependencyResolver
                .ServiceProvider().GetService(typeof(ICertificateService));
        }

        [TestMethod]
        public async Task GetCertificateTest()
        {
            try
            {
                CertificateResponse certificateResponse = await _certificateService
                    .GetCertificateAsync("shopeneur.com");

                Assert.IsNotNull(certificateResponse);
            }
            catch(Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }

        }

        [TestMethod]
        public async Task PostCertificateTest()
        {
            try
            {
                CertificateResponse certificateResponse = new CertificateResponse
                {
                    id = 174,
                    name = "shopeneur.com",
                    remoteCreateDate = DateTime.UtcNow,
                    remoteCreate = $"dev-server;test-server;prod-server"
                };

                CertificateResponse _certificateResponse = await _certificateService
                    .PostCertificateAsync(certificateResponse);

                Assert.IsNotNull(_certificateResponse);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }

        }

        [TestMethod]
        public async Task GetCertificateListTest()
        {
            try
            {
                List<CertificateResponse> certificateResponses = await _certificateService
                    .GetCertificatesListAsync();

                Assert.AreNotEqual(0,certificateResponses?.Count);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task PostRenewCertificateTest()
        {
            try
            {
                
                AccessTokenPayload accessTokenPayload = new AccessTokenPayload
                {
                    keyVaultAccessToken = string.Empty
                };

                List<CertificateResponse> certificateResponses = await _certificateService
                    .PostCertificateRenewalAsync(false);

                Assert.AreEqual(0, certificateResponses.Count);
            }

            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }
    }
}
