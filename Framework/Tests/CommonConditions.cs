using OpenQA.Selenium;
using NUnit.Framework;
using Framework.Driver;
using Framework.Pages;
using Framework.Model;
using NUnit.Framework.Interfaces;
using Framework.Util;
using System.IO;
using System.Threading;

namespace Framework.Tests
{
    [SetUpFixture]
    public abstract class CommonConditions
    {
        protected IWebDriver _driver;
        internal TradingPage _tradingPage;
        private LoginPage _loginPage;


        [SetUp]
        public void InitBrowserAndLogIn()
        {
            _driver = DriverManager.GetWebDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demo.hitbtc.com/signinapp");

            User testUser = UserCreator.WithCredentialsFromProperty();
            _loginPage = new LoginPage(_driver);
            _loginPage.FindEmailInputFieldToBeClickable(100);
            _loginPage.InputEmail();
            _loginPage.InputPassword();
            _loginPage.LogIn();
            //_loginPage.WaitUntilTradingPageIsLoaded(5000);
            Thread.Sleep(2000);
            _tradingPage = new TradingPage(_driver);
            Thread.Sleep(2000);
            _tradingPage.PopUpSkip();
            Thread.Sleep(2000);
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                ScreenShot.MakeScreenShot();
            }
            DriverManager.CloseWebDriver();
        }
    }
}
