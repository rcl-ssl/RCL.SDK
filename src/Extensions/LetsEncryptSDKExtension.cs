using Microsoft.Extensions.DependencyInjection.Extensions;
using RCL.SDK;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LetsEncryptSDKExtension
    {
        public static IServiceCollection AddLetsEncryptSDK(this IServiceCollection services, Action<LetsEncryptSDKOptions> setupAction)
        {
            services.TryAddTransient<IHttpService, HttpService>();
            services.TryAddTransient<ICertificateService, CertificateService>();
            services.Configure(setupAction);

            return services;
        }
    }
}
