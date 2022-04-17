using FluentAssertions;
using Generali.InsuerWeb.Tests.Hooks;
using Generali.InsuerWeb.Tests.Pages;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.Steps
{
    [Binding]
    public sealed class AmexisSteps
    {
        private AmexisMainPage amexisMainPage;
        private ContactsPage contactsPage;
        private CustomersPage customersPage;

        [Given(@"I am on Amexis page")]
        public void IAmOnAmexisPage()
        {
            DriverHooks.Driver.Navigate().GoToUrl("http://www.amexis.net/");
        }

        [When(@"I open contacts menu from main page")]
        public void IOpenContactsMenuFromMainPage()
        {
            amexisMainPage = new AmexisMainPage(DriverHooks.Driver);
            amexisMainPage.CLickLang();
            contactsPage = amexisMainPage.OpenContactsMenu();
        }

        [When(@"I send the form without entering information")]
        public void ISendTheFormWithoutEnteringInformation()
        {
            contactsPage.ClickSendMessageButton();
        }

        [Then(@"I should see validation messages")]
        public void IShouldSeeValidationMessages()
        {
            foreach (var element in contactsPage.elementTexts)
            {
                element.Text.Should().Be("Полето е задължително.");
            }

            contactsPage.validationMessageText.Should().Be("Има грешка в някое от полетата. Моля проверете и опитайте отново.");
        }

        [When(@"I open customer page from main page")]
        public void IOpenCustomerPageFromMainPage()
        {
            amexisMainPage = new AmexisMainPage(DriverHooks.Driver);
            amexisMainPage.CLickLang();
            customersPage = amexisMainPage.OpenCustomersMenu();
        }

        [Then(@"“Versant Corporation” should be present on the customer page")]
        public void VersantCorporationShouldBePresentOnTheCustomerPage()
        {
            customersPage.VersantCorporationLabelText.Should().Contain("Versant");
        }
    }
}