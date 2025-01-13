namespace SeleniumHelper.Models;

public class ConfigModel
{
    public UIRunSettings? UIRunSettings { get; set; }
    public APITestSettings? APITestSettings { get; set; }
    public TestDataRunSettings? TestDataRunSettings { get; set; }
    public ReportSettings? ReportSettings { get; set; }
    public List<UserConfig>? UserConfig { get; set; }
}

public class UIRunSettings
{
    public string? Browser { get; set; }
    public string? BaseUrl { get; set; }
    public string? RemoteUrl { get; set; }
    public string? ImplicitWait { get; set; }
    public string? PageLoadTimeout { get; set; }
    public string? ScriptTimeout { get; set; }
    public string? Headless { get; set; }
    public string? WindowSize { get; set; }
    public string? BrowserVersion { get; set; }
    public string? Platform { get; set; }
    public string? EnableVideo { get; set; }

}

public class APITestSettings
{
    public string? BaseUrl { get; set; }
}

public class TestDataRunSettings
{
    public string? ExcelPath { get; set; }

    public string? ExcelSheetName { get; set; }
}

public class ReportSettings
{
    public string? ExtentReportPath { get; set; }
}

public class UserConfig
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? AccountNumber { get; set; }

}