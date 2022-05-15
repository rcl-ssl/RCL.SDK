using RCL.SDK;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RCLSDKExtension
    {
        public static IServiceCollection AddRCLSDKService(this IServiceCollection services, Action<RCLSDKOptions> setupAction)
        {
            services.AddTransient<IAuthTokenService, AuthTokenService>();
            services.AddTransient<ICertificateRequestService, CertificateRequestService>();
            services.Configure(setupAction);

            return services;
        }
    }
}
