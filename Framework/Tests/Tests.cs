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
            Thread.Sleep(2000);
            _tradingPage = new TradingPage(_driver);
            Thread.Sleep(2000);
            _tradingPage.PopUpSkip();
        }

        [Test]
        public void BuyBTCMarketTest()
        {
           // _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            _tradingPage.SwitchToBuyBTC();
            _tradingPage.SwitchToBuyMarket();
            _tradingPage.SetAmountMarketBuy("0.00001");
            Thread.Sleep(1000);
            decimal previousValue = _tradingPage.GetBTCBalance();
            _tradingPage.BuyMarketLimitScaled();
            _tradingPage.WaitUntilTradingPageIsLoaded(0.2);
            Thread.Sleep(1000);
            decimal currentValue = _tradingPage.GetBTCBalance();
            Assert.AreEqual(Math.Round(previousValue+ Math.Round(Convert.ToDecimal(0.00001), 5), 5), Math.Round(currentValue,5));
        }

        [Test]
        public void BuyBTCLimitTest()
        {
            _tradingPage.SwitchToBuyBTC();
            _tradingPage.SwitchToBuyLimit();
            _tradingPage.SetAmountLimitBuy("0.00001");
            Thread.Sleep(500);
            _tradingPage.SetPriceForLimit("37850");
            int previousValue = _tradingPage.LimitOrdersCounter();
            _tradingPage.BuyMarketLimitScaled();
            Thread.Sleep(500);
            int currentValue = _tradingPage.LimitOrdersCounter();
            Assert.AreEqual(previousValue+1,currentValue);

        }

        [Test]
        public void BuyBTCScaledTest()
        {
            _tradingPage.SwitchToBuyBTC();
            _tradingPage.SwitchToBuyScaled();
            _tradingPage.SetAmountScaleBuy("0.00002");
            Thread.Sleep(1000);
            _tradingPage.SetPriceStepForScaleBuy("0.01");
            _tradingPage.SetMinPriceForScaleBuy("38793.94");
            _tradingPage.SetMaxPriceForScaleBuy("38793.95");
            _tradingPage.SetOrderCountBuy("2");
            _tradingPage.SetOrderCountBuy("2");
            int previousValue = _tradingPage.LimitOrdersCounter();
            _tradingPage.BuyMarketLimitScaled();
            Thread.Sleep(1000);
            int currentValue = _tradingPage.LimitOrdersCounter();
            if (previousValue != currentValue) 
            {
                Assert.AreEqual(previousValue + 2, currentValue);
            }
            else
            {
                Assert.AreEqual(previousValue, currentValue);
            }
        }

        [Test]
        public void SellBTCMarketTest()
        {
            _tradingPage.SwitchToSellBTC();
            _tradingPage.SwitchToSellMarket();
            Thread.Sleep(1000);
            _tradingPage.SetAmountMarketSell("0.00001000");
            decimal previousValue = _tradingPage.GetBTCBalance();
            _tradingPage.SellMarketLimitScaled();
            Thread.Sleep(1200);
            decimal currentValue = _tradingPage.GetBTCBalance();
           Assert.AreEqual(Math.Round(previousValue - Math.Round(Convert.ToDecimal(0.00001),5), 5), Math.Round(currentValue, 5));
        }

        [Test]
        public void SellBTCLimitTest()
        {
            _tradingPage.SwitchToSellBTC();
            _tradingPage.SwitchToSellLimit();
            _tradingPage.SetAmountLimitSell("0.00001");
            _tradingPage.SetPriceForSaleLimit("37850");
            Thread.Sleep(1000);
            decimal previousValue = _tradingPage.GetBTCBalance();
            _tradingPage.SellMarketLimitScaled();
            Thread.Sleep(1000);
            decimal currentValue = _tradingPage.GetBTCBalance();
            Assert.AreEqual(Math.Round(previousValue - Math.Round(Convert.ToDecimal(0.00001), 5), 5), Math.Round(currentValue, 5));
        }

        [Test]
        public void SellBTCScaledTest()
        {
            _tradingPage.SwitchToSellBTC();
            _tradingPage.SwitchToSellScaled();
            _tradingPage.SetAmountScaleSell("0.00002");
            _tradingPage.SetPriceStepForScaleSell("0.01");
            _tradingPage.SetMinPriceForScaleSale("38198.59");
            _tradingPage.SetMaxPriceForScaleSale("38198.60");
            _tradingPage.SetOrderCountSale("2");
            Thread.Sleep(1000);
            decimal previousValue = _tradingPage.GetBTCBalance();
            _tradingPage.SellMarketLimitScaled();
            Thread.Sleep(1000);
            decimal currentValue = _tradingPage.GetBTCBalance();
            if (previousValue != currentValue)
            {
                Assert.AreEqual(Math.Round(previousValue - Math.Round(Convert.ToDecimal(0.00002), 5), 5), Math.Round(currentValue, 5));
            }
            else
            {
                Assert.AreEqual(previousValue, currentValue);
            }

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
            _tradingPage.WaitUntilTradingPageIsLoaded(0.5);
            _tradingPage.SwitchToSellBTC();
            _tradingPage.SwitchToSellMarket();
            Thread.Sleep(1000);
            decimal previousValue = _tradingPage.GetBTCBalance();
            _tradingPage.SelectSellPercentage();
            Thread.Sleep(1000);
            _tradingPage.WaitUntilTradingPageIsLoaded(0.2);
            decimal amount = _tradingPage.PercentageAmount();
            _tradingPage.SellMarketLimitScaled();
            Thread.Sleep(1000);
            decimal currentValue = _tradingPage.GetBTCBalance();
            Assert.AreEqual(previousValue - amount, currentValue);
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