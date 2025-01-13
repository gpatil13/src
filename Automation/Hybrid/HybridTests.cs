[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass, MaxParallelThreads = 4)]

namespace Automation.Hybrid;

public class HybridTests : UITestsBase, IDisposable
{
    /*   private readonly ApiTestsBase _api;

      public ParallelTests(ITestOutputHelper output) : base(output)
      {
          _api = new ApiTestsBase(output);
      }

      [Fact]
      public void TestUIAndApiParallel()
      {
          try
          {
              var googleHomePage = new GoogleHomePage(Driver);
              googleHomePage.Navigate();
              googleHomePage.Search("Selenium with C#");

              var request = new RestRequest("/user/profile", Method.GET);
              var response = _api.Client.Execute(request);
              Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

              // ExtentX reporting
              var extent = ExtentReportSetup.GetExtentReports();
              var test = extent.CreateTest("TestUIAndApiParallel");
              test.Pass("Test passed successfully");

              extent.Flush();
              Output.WriteLine("UI and API test passed.");
          }
          catch (Exception ex)
          {
              TakeScreenshot(nameof(TestUIAndApiParallel));
              Output.WriteLine($"Test failed: {ex.Message}");
              throw;
          }
      }

      public new void Dispose()
      {
          base.Dispose();
          _api?.ServiceProvider?.Dispose();
      } */
}
