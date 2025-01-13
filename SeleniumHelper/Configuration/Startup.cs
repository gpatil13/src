namespace SeleniumHelper.Configuration;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var configuration = ConfigurationSetup.Configure();
        services.AddSingleton<IConfiguration>(configuration);
    }
}
