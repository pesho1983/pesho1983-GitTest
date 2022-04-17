using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace Generali.InsuerWeb.Tests.Hooks
{
    [Binding]
    public class DriverHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public static RemoteWebDriver Driver { get; set; }

        [BeforeScenario]
        public void OpenBrowser()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
