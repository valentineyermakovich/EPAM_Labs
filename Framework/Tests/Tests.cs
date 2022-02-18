using System;
using System.Drawing;
using Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NUnit.Framework.Interfaces;
using Framework.Util;
using Framework.Model;



namespace TestProject1.Tests
{
    public class Tests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private TradingPage _tradingPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demo.hitbtc.com/signinapp");
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

        [Test]
        public void BuyBTCMarketTest()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            _tradingPage.SwitchToBuyBTC();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SwitchToBuyMarket();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SetAmountMarketBuy("0.00001");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.BuyMarketLimitScaled();
        }

        [Test]
        public void BuyBTCLimitTest()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            _tradingPage.SwitchToBuyBTC();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SwitchToBuyLimit();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SetAmountLimitBuy("0.00001");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SetPriceForLimit("37850");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.BuyMarketLimitScaled();
        }

        [Test]
        public void BuyBTCScaledTest()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            _tradingPage.SwitchToBuyBTC();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            _tradingPage.SwitchToBuyScaled();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SetAmountScaleBuy("0.00002");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SetPriceStepForScaleBuy("0.01");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SetMinPriceForScaleBuy("381009.94");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SetMaxPriceForScaleBuy("381009.95");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SetOrderCountBuy("2");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.BuyMarketLimitScaled();
        }

        [Test]
        public void SellBTCMarketTest()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            _tradingPage.SwitchToSellBTC();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SwitchToSellMarket();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(200);
            _tradingPage.SetAmountMarketSell("0.00001");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SellMarketLimitScaled();
        }

        [Test]
        public void SellBTCLimitTest()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            _tradingPage.SwitchToSellBTC();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SwitchToSellLimit();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SetAmountLimitSell("0.00001");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SetPriceForSaleLimit("37850");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SellMarketLimitScaled();
        }

        [Test]
        public void SellBTCScaledTest()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            _tradingPage.SwitchToSellBTC();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SwitchToSellScaled();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SetAmountScaleSell("0.00002");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SetPriceStepForScaleSell("0.01");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SetMinPriceForScaleSale("38198.59");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SetMaxPriceForScaleSale("38198.60");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SetOrderCountSale("2");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SellMarketLimitScaled();
        }

        //[Test]
        //public void BackgroundColorChangeTest()
        //{
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
        //    _tradingPage.SwitchSchema();
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    _tradingPage.OpenProperties();
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    _tradingPage.OpenBackgroundProperties();
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    _tradingPage.OpenBackgroundColorProperties();
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    _tradingPage.ChooseBackgroundColorProperties();
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    _tradingPage.ApproveBackgroundColorProperties();
        //}

        //[Test]
        //public void AddIndicatorTest()
        //{
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
        //    _tradingPage.SwitchSchema();
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    _tradingPage.OpenIndicatorsList();
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    _tradingPage.AddIndicator();
        //}

        //[Test]
        //public void DeleteIndicatorTest()
        //{
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
        //    _tradingPage.SwitchSchema();
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    _tradingPage.OpenIndicatorsList();
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    _tradingPage.DeleteIndicator();
        //}

        //[Test]
        //public void CandlesChangeTest()
        //{
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
        //    _tradingPage.SwitchSchema();
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        //    _tradingPage.OpenCandlesList();
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    _tradingPage.ChooseBars();
        //}

        [Test]
        public void SellBTCMarketByPercentageTest()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            _tradingPage.SwitchToSellBTC();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SwitchToSellMarket();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SelectSellPercentage();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _tradingPage.SellMarketLimitScaled();
        }


        [TearDown]
        public void CloseBrowser()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                ScreenShot.MakeScreenShot();
            }
            _driver.Close();
        }
    }
}