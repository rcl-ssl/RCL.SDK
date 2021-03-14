using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RCL.SDK.ConsoleSample
{
    public static class Startup
    {
        public static ServiceProvider ServiceProvider()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddUserSecrets<ConsoleProject>();
            IConfiguration Configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();

            // Add the SDK Services
            services.AddAuthTokenService(options => Configuration.Bind("Auth", options));
            services.AddRCLSDK(options => Configuration.Bind("RCLSDK", options));

            return services.BuildServiceProvider();
        }
    }

    public class ConsoleProject
    {
    }
}
