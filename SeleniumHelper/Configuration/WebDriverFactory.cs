namespace SeleniumHelper.Configuration;

public class WebDriverFactory
{
    public static IWebDriver GetWebDriver(string browser, string remoteUrl, bool isParallelExecution = false)
    {
        new DriverManager().SetUpDriver(browser.ToLower() switch
        {
            "firefox" => new FirefoxConfig(),
            _ => new ChromeConfig()
        });

        return isParallelExecution
            ? browser.ToLower() switch
            {
                "firefox" => new RemoteWebDriver(new Uri(remoteUrl), new FirefoxOptions()),
                "chrome" => new RemoteWebDriver(new Uri(remoteUrl), GetChromeOptions()),
                _ => throw new ArgumentException($"Unsupported browser: {browser}"),
            }
            : browser.ToLower() switch
            {
                "firefox" => new FirefoxDriver(new FirefoxOptions()),
                "chrome" => new ChromeDriver(GetChromeOptions()),
                _ => throw new ArgumentException($"Unsupported browser: {browser}"),
            };
    }

    private static ChromeOptions GetChromeOptions()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--start-maximized");
        chromeOptions.AddArgument("--disable-popup-blocking");
        chromeOptions.AddArgument("--headless"); // Run in headless mode
        return chromeOptions;
    }
}
