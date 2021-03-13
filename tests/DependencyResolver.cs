using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RCL.SDK.Tests
{
    public static class DependencyResolver
    {
        public static ServiceProvider ServiceProvider()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddUserSecrets<TestProject>();
            IConfiguration Configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();

            services.AddAuthTokenService(options => Configuration.Bind("Auth",options));
            services.AddLetsEncryptSDK(options => Configuration.Bind("LetsEncryptSDK", options));
            
            return services.BuildServiceProvider();
        }
    }

    public class TestProject
    {
    }
}
