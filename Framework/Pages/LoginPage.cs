using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using Framework.Util;


namespace Framework.Pages
{
    public class LoginPage : PageFactoryBase
    {
        private const string TestEmail = "valik123qaz@gmail.com";
        private const string Password = "Valik123qaz";

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div/div/div/div/div[1]/form[1]/div[2]/div/label/input")]
        private IWebElement _emailInputField;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div/div/div/div/div[1]/form[1]/div[3]/div/label/input")]
        private IWebElement _passwordInputField;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div/div/div/div/div[1]/form[1]/div[5]/button")]
        private IWebElement _signInButton;

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void LogIn()
        {
            _signInButton.Click();
            Log.Info("Login form has been passed");
        }

        public void InputEmail()
        {
            _emailInputField.SendKeys(TestEmail);
            Log.Info("Email input");
        }

        public void InputPassword()
        {
            _passwordInputField.SendKeys(Password);
            Log.Info("Password input");

        }

        public void FindEmailInputFieldToBeClickable(double waitTime)
        {
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            Wait.Until(ExpectedConditions.ElementToBeClickable(_emailInputField));
        }

        public void WaitUntilTradingPageIsLoaded(double waitTime)
        {
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            Wait.Until(
                ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.terminal__edit-container.on_advanced > div:nth-child(2) > div > div.terminal.on_advanced > div.terminal__window.window.terminal__window_buyOrder > div.window__window > div.window__body > div.terminalSwitchBlocks.window__terminalSwitchBlocks > form.form.form_createOrder.form_newErrors.form_createOrder_Buy.limit.window__form_createOrder.form_createOrder__withAmountSlider > div.form_createOrder__header.form_createOrder_withStops > ul > li.ui-fl.market > div")));
        }
    }
}