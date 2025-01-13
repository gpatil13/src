using Microsoft.VisualStudio.TestPlatform.Utilities;
using SeleniumHelper;

namespace Automation.TestCases;

public class UITests(ITestOutputHelper Result) : NewTestBase(Result) //UITestsBase
{
    [Fact]
    [SmokeTest]
    public void TestGoogleSearch()
    {
        var googleHomePage = new GoogleHomePage(Driver);
        googleHomePage.Navigate();
        googleHomePage.Search("xUnit with Selenium");
        Assert.Contains("xUnit with Selenium", Driver.PageSource);
        Result.WriteLine("TestGoogleSearch Passed");

    }
}
