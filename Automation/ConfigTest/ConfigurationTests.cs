using Xunit;
namespace Automation.ConfigTest;

using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using SeleniumHelper.Configuration;
using Xunit;

public class ConfigurationTests
{
    private readonly IConfiguration _configuration;

    public ConfigurationTests()
    {
        _configuration = ConfigurationSetup.Configure();
    }

    [Fact]
    public void TestConfigurationSettings()
    {
        var browser = _configuration["UIRunSettings:Browser"];
        var remoteUrl = _configuration["UIRunSettings:RemoteUrl"];
        var apiBaseUrl = _configuration["ApiRunSettings:ApiBaseUrl"];
        var extentReportPath = _configuration["ReportSettings:ExtentReportPath"];

        Assert.Equal("chrome", browser);
        Assert.Equal("http://localhost:4444/wd/hub", remoteUrl);
        Assert.Equal("https://api.example.com", apiBaseUrl);
        Assert.Equal("Reports/ExtentReport.html", extentReportPath);
    }

    [Fact]
    public void TestWebDriver()
    {
        var browser = _configuration["WebDriver:Browser"];
        IWebDriver driver;

        if (browser == "chrome")
        {
            driver = new ChromeDriver();
        }
        else
        {
            driver = new RemoteWebDriver(new Uri(_configuration["WebDriver:RemoteUrl"]), new ChromeOptions());
        }

        driver.Navigate().GoToUrl("https://www.google.com");
        Assert.Contains("Google", driver.Title);

        driver.Quit();
    }
}
