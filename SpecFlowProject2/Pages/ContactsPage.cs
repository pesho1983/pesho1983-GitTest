using Generali.AutomationFramework.UI.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Generali.InsuerWeb.Tests.Pages
{

    public class ContactsPage : AmexisMainPage
    {
        private readonly By nameTextBox = By.Name("your-name");
        private readonly By emailTextBox = By.Name("email");
        private readonly By phoneTextBox = By.Name("phone");
        private readonly By subjectTextBox = By.Name("subject");
        private readonly By validationMessage = By.XPath("//div[contains(text(), 'Има грешка') and @style= 'display: block;']");
        private readonly By validationMessages = By.XPath("//span[@role = 'alert']");
        private readonly By sendMessageButton = By.XPath("//input[@type = 'submit']");

        public ContactsPage(RemoteWebDriver driver)
        : base(driver)
        {
        }


        public void ClickSendMessageButton() => Driver.FindElement(sendMessageButton).Click();

        public string validationMessageText => Driver.FindElementUntilIsVisible(validationMessage, 10).Text;

        public IList<IWebElement> elementTexts => Driver.FindElements(validationMessages);
    }
}