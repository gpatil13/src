using SeleniumHelper.Configuration;

namespace Automation.TestBase;

public class NewTestBase : IDisposable
{
    protected readonly ServiceProvider ConfigProvider;
    protected readonly ITestOutputHelper Result;
    protected readonly IWebDriver Driver;

    public NewTestBase(ITestOutputHelper output)
    {

        ConfigProvider = ConfigurationSetup.ConfigureServices(output); // Set the ServiceProvider
        Result = ConfigProvider.GetRequiredService<ITestOutputHelper>(); // Set the ITestOutputHelper
        Driver = ConfigProvider.GetRequiredService<IWebDriver>(); // Set the IWebDriver
    }


    public void Dispose()
    {
        throw new NotImplementedException();
    }
}

