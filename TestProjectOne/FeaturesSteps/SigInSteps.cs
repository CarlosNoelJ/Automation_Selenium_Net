using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TestProjectOne.General;
using TestProjectOne.Helpers;
using TestProjectOne.Pages;

namespace TestProjectOne.FeaturesSteps
{
    [Binding]
    [Scope(Feature = "SigIn")]
    public class SigInSteps : BaseComponents
    {
        //IWebDriver driver;
        //string baseUrl;
        //WaitToFindNewElement wait;

        //public SigInSteps()
        //{
        //    driver = new ChromeDriver();
        //    baseUrl = "http://automationpractice.com/index.php";
        //    wait = new WaitToFindNewElement();
        //}

        //[Given(@"The sign in webpage")]
        //public void GivenTheSignInWebpage()
        //{
        //    driver.Navigate().GoToUrl(baseUrl + "/");
        //    driver.Manage().Window.Maximize();
        //}
        
        [When(@"I complete pass and user fields")]
        public void WhenICompletePassAndUserFields()
        {
            driver.FindElement(By.ClassName("login")).Click();
            var registerFormPage = new RegisterPage(driver);
            registerFormPage.SignInFaker()
                .StrictMode(false)
                .Generate("HappyPath, Default");
            driver.FindElement(By.Id("SubmitLogin")).Click();
        }
        
        [When(@"I click Sign Out Button")]
        public void WhenIClickSignOutButton()
        {
            driver.FindElement(By.ClassName("login")).Click();
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).SendKeys("pruebaTest@yopmail.com");
            driver.FindElement(By.Id("passwd")).Click();
            driver.FindElement(By.Id("passwd")).SendKeys("qwerty");
            driver.FindElement(By.Id("SubmitLogin")).Click();
            wait.WaitToElement(driver, By.ClassName("logout"));
            driver.FindElement(By.ClassName("logout")).Click();
        }
        
        [When(@"I complete the fields with a no registered email")]
        public void WhenICompleteTheFieldsWithANoRegisteredEmail()
        {
            driver.FindElement(By.ClassName("login")).Click();
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).SendKeys("asdads@yopmail.com");
            driver.FindElement(By.Id("passwd")).Click();
            driver.FindElement(By.Id("passwd")).SendKeys("qwerty");
            driver.FindElement(By.Id("SubmitLogin")).Click();
           
        }
        
        [Then(@"I can see the account section on the top")]
        public void ThenICanSeeTheAccountSectionOnTheTop()
        {
            Assert.AreEqual("Sign out", driver.FindElement(By.ClassName("logout")).Text);
            driver.Quit();
        }
        
        [Then(@"I can see the Sign In WebPage")]
        public void ThenICanSeeTheSignInWebPage()
        {
            Assert.AreEqual("Sign in", driver.FindElement(By.ClassName("login")).Text);
            driver.Quit();
        }
        
        [Then(@"I see the alert message")]
        public void ThenISeeTheAlertMessage()
        {
            wait.WaitToElement(driver, By.ClassName("alert-danger"));
            Assert.AreEqual("There is 1 error", 
                driver.FindElement(By.CssSelector("#center_column > div.alert.alert-danger>p")).Text);
            driver.Quit();
        }
    }
}
