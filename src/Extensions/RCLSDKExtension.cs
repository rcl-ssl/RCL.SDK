using Microsoft.Extensions.DependencyInjection.Extensions;
using RCL.SDK;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RCLSDKExtension
    {
        public static IServiceCollection AddRCLSDK(this IServiceCollection services, Action<RCLSDKOptions> setupAction)
        {
            services.TryAddTransient<IHttpService, HttpService>();
            services.TryAddTransient<ICertificateService, CertificateService>();
            services.Configure(setupAction);

            return services;
        }
    }
}
