using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TestProjectOne.General;
using TestProjectOne.Pages;

namespace TestProjectOne.FeaturesSteps
{
    [Binding]
    [Scope(Feature = "Register")]
    public class AutomationRegisterPracticeSteps : BaseComponents
    {
        [When(@"I complete all the fields")]
        public void WhenICompleteAllTheFields()
        {
            driver.FindElement(By.ClassName("login")).Click();
            var registerFormPage = new RegisterPage(driver);
            registerFormPage.Generator()
                .StrictMode(false)
                .Generate("HappyPath, Default");

            driver.FindElement(By.Id("SubmitCreate")).Click();
        }

        [Then(@"I can see the account name on the top")]
        public void ThenICanSeeTheAccountNameOnTheTop()
        {
            wait.WaitToElement(driver, By.ClassName("page-heading"));
            Assert.AreEqual("AUTHENTICATION", driver.FindElement(By.ClassName("page-heading")).Text);
        }
        //}
    }
}
