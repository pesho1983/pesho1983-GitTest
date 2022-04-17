using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Generali.AutomationFramework.UI.Extensions
{
    public static class DriverExtensions
    {
        [Obsolete]
        public static IWebElement FindInitializedElement(this IWebDriver driver, By by)
        {
            var element = new WebDriverWait(driver, TimeSpan.FromSeconds(90))
               .Until(ExpectedConditions.ElementToBeClickable(by));

            return element;
        }

        [Obsolete]
        public static IEnumerable<IWebElement> FindInitializedElements(this IWebDriver driver, By by)
        {
            var elements = new WebDriverWait(driver, TimeSpan.FromSeconds(90))
                .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));

            return elements;
        }

        [Obsolete]
        public static void ClickWithRetry(this IWebDriver driver, By by)
        {
            int attempts = 0;
            while (attempts < 3)
            {
                try
                {
                    driver.FindInitializedElement(by).Click();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    Thread.Sleep(attempts * 500);
                }
                catch (ElementClickInterceptedException)
                {
                    Thread.Sleep((attempts + 1) * 500);
                }
                catch (ElementNotInteractableException)
                {
                    Thread.Sleep((attempts + 1) * 500);
                }
                catch (System.Net.WebException) //TODO: Try to avoid Timeouts on Module wake up
                {
                    Thread.Sleep((attempts + 1) * 500);
                }
                attempts++;
            }
        }

        public static IWebElement FindElementUntilIsVisible(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}