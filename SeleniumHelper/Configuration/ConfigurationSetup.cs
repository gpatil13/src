namespace SeleniumHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using RestSharp;
using System;
using Xunit.Abstractions;

//Configuration setup class
public class ConfigurationSetup
{

    public static IConfigurationRoot Configure()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        return builder.Build();
    }

    public static ServiceProvider ConfigureServices(ITestOutputHelper testOutput)
    {
        var serviceCollection = new ServiceCollection();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        serviceCollection.AddSingleton<ITestOutputHelper>(testOutput); //Register the ITestOutputHelper
        serviceCollection.AddSingleton<IConfiguration>(configuration); //Register the IConfiguration


        serviceCollection.AddTransient<IWebDriver, IWebDriver>(sp => //Register the IWebDriver
        {
            var config = sp.GetRequiredService<IConfiguration>();

            return GetWebDriver(config);
        });
        // serviceCollection.AddTransient<RestClient, RestClient>(sp =>
        // {
        //     var config = sp.GetRequiredService<IConfiguration>();
        //     var baseUrl = config.GetValue<string>("ApiBaseUrl");
        //     return new RestClient(baseUrl);
        // });

        return serviceCollection.BuildServiceProvider();
    }

    private static IWebDriver GetWebDriver(IConfiguration config)
    {
        string? browser = config.GetValue<string>("UIRunSettings:Browser");
        string? remoteUrl = config.GetValue<string>("UIRunSettings:RemoteUrl");

        new DriverManager().SetUpDriver((browser ?? throw new ArgumentNullException(nameof(browser))).ToLower() switch
        {
            "firefox" => new FirefoxConfig(),
            "chrome" => new ChromeConfig(),
            "edge" => new EdgeConfig(),
            "ie" => new InternetExplorerConfig(),
            "opera" => new OperaConfig(),
            "phantomjs" => new PhantomConfig(),
            _ => new ChromeConfig()
        });

        return browser.ToLower() switch
        {
            "firefox" => new RemoteWebDriver(new Uri(remoteUrl ?? throw new ArgumentNullException(nameof(remoteUrl))), new FirefoxOptions()),
            "chrome" => new RemoteWebDriver(new Uri(remoteUrl ?? throw new ArgumentNullException(nameof(remoteUrl))), new ChromeOptions()),
            _ => throw new ArgumentException($"Unsupported browser: {browser}"),
        };
    }



}
