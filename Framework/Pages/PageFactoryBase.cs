using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Framework.Pages
{
    public class PageFactoryBase
    {
        protected readonly IWebDriver driver;
        protected WebDriverWait Wait;

        protected PageFactoryBase(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public IWebElement FindElementToBeClickable(By elementLocator, double waitTime)
        {
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            return Wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
        }
    }
}
