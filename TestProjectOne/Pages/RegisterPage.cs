using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestProjectOne.General;

namespace TestProjectOne.Pages
{
    class RegisterPage
    {
        [FindsBy]
        private IWebElement email_create = null,email = null, passwd = null;
        [FindsBy(How = How.Id, Using = "email_create")]
        private IWebElement createAccountBtn = null;
        private IWebElement logInBtn = null;
        private IWebDriver driver;
        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string RegisterEmail { get { return email_create.GetText(); } private set { email_create.SetText(value); } }
        public string Email { get { return email.GetText(); } private set { email.SetText(value);} }
        public string Psswd { get { return passwd.GetText(); } private set { passwd.SetText(value); } }

        public Faker<RegisterPage> Generator()
        {
            var registerSigInPage = new Faker<RegisterPage>()
                .CustomInstantiator(f => new RegisterPage(driver))
                .CustomInstantiator(f => new RegisterPage(driver))
                .RuleSet("HappyPath",
                 (set) =>
                 {
                     set.StrictMode(false);
                     set.RuleFor(a => a.RegisterEmail, f => f.Person.Email);
                 });
            return registerSigInPage;
        }

        public Faker<RegisterPage> SignInFaker()
        {
            var registerSigInPage = new Faker<RegisterPage>()
                .CustomInstantiator(f => new RegisterPage(driver))
                .CustomInstantiator(f => new RegisterPage(driver))
                .RuleSet("HappyPath",
                 (set) =>
                 {
                     set.StrictMode(false);
                     set.RuleFor(a => a.Email, f => "pruebaTest@yopmail.com");
                     set.RuleFor(a => a.Psswd, f => "qwerty");
                 });
            return registerSigInPage;
        }
    }
}
