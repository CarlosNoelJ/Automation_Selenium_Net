using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TestProjectOne.Helpers;

namespace TestProjectOne.General
{
    public class BaseComponents
    {
        protected IWebDriver driver;
        protected string baseUrl;
        protected WaitToFindNewElement wait;

        public BaseComponents()
        {
            driver = new ChromeDriver();
            baseUrl = "http://automationpractice.com/index.php";
            wait = new WaitToFindNewElement();
        }

        [Given(@"The sign in webpage")]
        public void GivenTheSignInWebpage()
        {
            driver.Navigate().GoToUrl(baseUrl + "/");
            driver.Manage().Window.Maximize();
        }

    }
}
