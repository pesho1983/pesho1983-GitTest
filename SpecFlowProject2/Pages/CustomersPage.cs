using OpenQA.Selenium;
using OpenQA.Selenium.Remote;


namespace Generali.InsuerWeb.Tests.Pages
{

    public class CustomersPage : AmexisMainPage
    {
        private readonly By versantCorporationLabel = By.XPath("//div[@class='item-content']/h3");


        public CustomersPage(RemoteWebDriver driver) : base(driver)
        {
        }

        public string VersantCorporationLabelText => Driver.FindElement(versantCorporationLabel).Text;

    }
}

