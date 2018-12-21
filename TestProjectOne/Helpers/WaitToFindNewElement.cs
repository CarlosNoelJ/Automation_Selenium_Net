using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestProjectOne.Helpers
{
    public class WaitToFindNewElement
    {
        public IWebElement WaitToElement(IWebDriver driver, By elementLocator, int timeout=10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

            return wait.Until(ExpectedConditions.ElementExists(elementLocator));
        } 
    }
}
