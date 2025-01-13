

namespace Automation.TestBase;

public class UITestsBase : IDisposable
{
    protected readonly IWebDriver Driver;
    protected readonly ServiceProvider ServiceProvider;

    public ITestOutputHelper testOutput;

    public UITestsBase()
    {
        ServiceProvider = DependencySetup.ConfigureServices();
        Driver = ServiceProvider.GetRequiredService<IWebDriver>();
        testOutput = ServiceProvider.GetRequiredService<ITestOutputHelper>();
    }

    public void Dispose()
    {
        Driver.Quit();
        ServiceProvider.Dispose();
    }
    protected void TakeScreenshot(string testName)
    {
        var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
        var fileName = $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
        var filePath = $"Screenshots/filename";
        screenshot.SaveAsFile(filePath);
    }


}
