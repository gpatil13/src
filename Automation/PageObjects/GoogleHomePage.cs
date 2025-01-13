using OpenQA.Selenium;

namespace Automation.PageObjects;

public class GoogleHomePage
{

    private readonly IWebDriver _driver;

    public GoogleHomePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public IWebElement SearchBox => _driver.FindElement(By.Name("q"));

    public void Navigate() => _driver.Navigate().GoToUrl("https://www.google.com");

    public void Search(string query)
    {
        SearchBox.SendKeys(query);
        SearchBox.Submit();
    }
}
