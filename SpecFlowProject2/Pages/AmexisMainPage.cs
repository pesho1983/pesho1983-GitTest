using OpenQA.Selenium;
using OpenQA.Selenium.Remote; 

namespace Generali.InsuerWeb.Tests.Pages
{
    public class AmexisMainPage
    {
        private readonly By customersMenu = By.Id("menu-item-322");
        private readonly By contactsMenu = By.Id("menu-item-324");
        private readonly By polylang = By.Id("polylang-2");
     
        public AmexisMainPage(RemoteWebDriver driver) 
        {
            Driver = driver;
        }

        protected RemoteWebDriver Driver { get; private set; }

        public void CLickLang() => Driver.FindElement(polylang).Click();

        public CustomersPage OpenCustomersMenu()
        {
            Driver.FindElement(customersMenu).Click();

            return new CustomersPage(Driver);
        }

        public ContactsPage OpenContactsMenu()
        {
            Driver.FindElement(contactsMenu).Click();

            return new ContactsPage(Driver);
        }
    }
}