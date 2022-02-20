using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using Framework.Util;
using System.Globalization;

namespace Framework.Pages
{
    public class TradingPage : PageFactoryBase
    {

        private readonly By _popUpSkipButton =
            By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div:nth-child(14) > div > div > div.styles__popupContent--3_6iJ > div.styles__risk--1U9Pj > a > span");
        private readonly By _spotBalanceBTC =
            By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.header-container-chunk.react-chunk > div > div > div > div > div.styles__topPart--2NpVr > div.styles__tools--2XUJY > div:nth-child(1) > div.styles__balanceInfo--1AnT7 > div:nth-child(2) > span:nth-child(1)");
        private readonly By _activeOrders =
             By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.terminal__edit-container.on_advanced > div:nth-child(2) > div > div.terminal.on_advanced > div.terminal__window.window.terminal__window_myOrders.window_6-col.ui-resizable > div.window__window > div.window__body > div > div > div.tabs__menu.tabs__menu_wide.ui-clearfix > div.tabs__menuItem.tabs__menuItem_active > span.window__ordersCounter.myOrder__count.myOrder__count_active > span");
        private readonly By _marketBuyButton =
            By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.terminal__edit-container.on_advanced > div:nth-child(2) > div > div.terminal.on_advanced > div.terminal__window.window.terminal__window_buyOrder > div.window__window > div.window__body > div.terminalSwitchBlocks.window__terminalSwitchBlocks > form.form.form_createOrder.form_newErrors.form_createOrder_Buy.limit.window__form_createOrder.form_createOrder__withAmountSlider > div.form_createOrder__header.form_createOrder_withStops > ul > li.ui-fl.market > div");
        private readonly By _marketSellButton =
            By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.terminal__edit-container.on_advanced > div:nth-child(2) > div > div.terminal.on_advanced > div.terminal__window.window.terminal__window_buyOrder > div.window__window > div.window__body > div.terminalSwitchBlocks.window__terminalSwitchBlocks > form.form.form_createOrder.form_newErrors.form_createOrder_Sell.limit.window__form_createOrder.form_createOrder__withAmountSlider > div.form_createOrder__header.form_createOrder_withStops > ul > li.ui-fl.market > div");
        private readonly By _buyBTCButton =
           By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.terminal__edit-container.on_advanced > div:nth-child(2) > div > div.terminal.on_advanced > div.terminal__window.window.terminal__window_buyOrder > div.window__window > div.window__body > div.terminalSwitchBlock__header > div.terminalSwitchBlock__label.terminalSwitchBlock__label_buy.buy.active");
        private readonly By _buyMarketLimitScaledButton =
           By.XPath("/html/body/div[2]/div[7]/div[2]/div/div[1]/div[4]/div[2]/div[2]/div[2]/form[1]/div[9]/button");
        private readonly By _amountBuyMarketInputField =
           By.Name("amount");
        private readonly By _amountBuyLimitInputField =
           By.Name("amount");
        private readonly By _amountBuyScaleInputField =
           By.Name("amount");
        private readonly By _amountSellMarketInputField =
           By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.terminal__edit-container.on_advanced > div:nth-child(2) > div > div.terminal.on_advanced > div.terminal__window.window.terminal__window_buyOrder > div.window__window > div.window__body > div.terminalSwitchBlocks.window__terminalSwitchBlocks > form.form.form_createOrder.form_newErrors.form_createOrder_Sell.window__form_createOrder.form_createOrder__withAmountSlider.market > div.form_createOrder__entries.ui-clearfix > div.form_createOrder__entries_label.form_createOrder__entries_labelAmount.labelAmount.form__row.ui-clearfix > div.form_createOrder__entries_container > span.ui-spinner.ui-widget.ui-widget-content.ui-corner-all > input");
        private readonly By _amountSellLimitInputField =
           By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.terminal__edit-container.on_advanced > div:nth-child(2) > div > div.terminal.on_advanced > div.terminal__window.window.terminal__window_buyOrder > div.window__window > div.window__body > div.terminalSwitchBlocks.window__terminalSwitchBlocks > form.form.form_createOrder.form_newErrors.form_createOrder_Sell.limit.window__form_createOrder.form_createOrder__withAmountSlider > div.form_createOrder__entries.ui-clearfix > div.form_createOrder__entries_label.form_createOrder__entries_labelAmount.labelAmount.form__row.ui-clearfix > div.form_createOrder__entries_container > span.ui-spinner.ui-widget.ui-widget-content.ui-corner-all > input");
        private readonly By _amountSellScaleInputField =
           By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.terminal__edit-container.on_advanced > div:nth-child(2) > div > div.terminal.on_advanced > div.terminal__window.window.terminal__window_buyOrder > div.window__window > div.window__body > div.terminalSwitchBlocks.window__terminalSwitchBlocks > form.form.form_createOrder.form_newErrors.form_createOrder_Sell.window__form_createOrder.form_createOrder__withAmountSlider.postOnly.scaled > div.form_createOrder__entries.ui-clearfix > div.form_createOrder__entries_label.form_createOrder__entries_labelAmount.labelAmount.form__row.ui-clearfix > div.form_createOrder__entries_container > span.ui-spinner.ui-widget.ui-widget-content.ui-corner-all > input");
        private readonly By _limitBuyButton =
            By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.terminal__edit-container.on_advanced > div:nth-child(2) > div > div.terminal.on_advanced > div.terminal__window.window.terminal__window_buyOrder > div.window__window > div.window__body > div.terminalSwitchBlocks.window__terminalSwitchBlocks > form.form.form_createOrder.form_newErrors.form_createOrder_Buy.window__form_createOrder.form_createOrder__withAmountSlider.limit > div.form_createOrder__header.form_createOrder_withStops > ul > li.ui-fl.limit > div");
        private readonly By _limitSellButton =
            By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.terminal__edit-container.on_advanced > div:nth-child(2) > div > div.terminal.on_advanced > div.terminal__window.window.terminal__window_buyOrder > div.window__window > div.window__body > div.terminalSwitchBlocks.window__terminalSwitchBlocks > form.form.form_createOrder.form_newErrors.form_createOrder_Sell.limit.window__form_createOrder.form_createOrder__withAmountSlider > div.form_createOrder__header.form_createOrder_withStops > ul > li.ui-fl.limit > div");
        private readonly By _priceInputLimitField =
          By.Name("price");
        private readonly By _priceInputLimitSellField =
          By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.terminal__edit-container.on_advanced > div:nth-child(2) > div > div.terminal.on_advanced > div.terminal__window.window.terminal__window_buyOrder > div.window__window > div.window__body > div.terminalSwitchBlocks.window__terminalSwitchBlocks > form.form.form_createOrder.form_newErrors.form_createOrder_Sell.limit.window__form_createOrder.form_createOrder__withAmountSlider > div.form_createOrder__entries.ui-clearfix > div.form_createOrder__entries_label.form__row.form_createOrder__entries_labelPrice.ui-clearfix > div.form_createOrder__entries_container > span.ui-spinner.ui-widget.ui-widget-content.ui-corner-all > input");
        private readonly By _scaledBuyButton =
           By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.terminal__edit-container.on_advanced > div:nth-child(2) > div > div.terminal.on_advanced > div.terminal__window.window.terminal__window_buyOrder > div.window__window > div.window__body > div.terminalSwitchBlocks.window__terminalSwitchBlocks > form.form.form_createOrder.form_newErrors.form_createOrder_Buy.window__form_createOrder.form_createOrder__withAmountSlider > div.form_createOrder__header.form_createOrder_withStops > ul > li.ui-fl.scaled > div");
        private readonly By _scaledSellButton =
           By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.terminal__edit-container.on_advanced > div:nth-child(2) > div > div.terminal.on_advanced > div.terminal__window.window.terminal__window_buyOrder > div.window__window > div.window__body > div.terminalSwitchBlocks.window__terminalSwitchBlocks > form.form.form_createOrder.form_newErrors.form_createOrder_Sell.limit.window__form_createOrder.form_createOrder__withAmountSlider > div.form_createOrder__header.form_createOrder_withStops > ul > li.ui-fl.scaled > div");
        private readonly By _priceStepBuyField =
          By.Name("price_step");
        private readonly By _priceMinBuyField =
         By.Name("price_min");
        private readonly By _priceMaxBuyField =
        By.Name("price_max");
        private readonly By _orderCountBuyField =
        By.Name("order_count");
        private readonly By _priceStepSellField =
          By.XPath("/html/body/div[2]/div[7]/div[2]/div/div[1]/div[4]/div[2]/div[2]/div[2]/form[2]/div[7]/div[4]/div[2]/span[1]/input");
        private readonly By _priceMinSellField =
         By.XPath("/html/body/div[2]/div[7]/div[2]/div/div[1]/div[4]/div[2]/div[2]/div[2]/form[2]/div[7]/div[5]/div[2]/span[1]/input");
        private readonly By _priceMaxSellField =
        By.XPath("/html/body/div[2]/div[7]/div[2]/div/div[1]/div[4]/div[2]/div[2]/div[2]/form[2]/div[7]/div[6]/div[2]/span[1]/input");
        private readonly By _orderCountSellField =
        By.XPath("/html/body/div[2]/div[7]/div[2]/div/div[1]/div[4]/div[2]/div[2]/div[2]/form[2]/div[7]/div[7]/div[2]/span/input");
        private readonly By _sellBTCButton =
          By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.terminal__edit-container.on_advanced > div:nth-child(2) > div > div.terminal.on_advanced > div.terminal__window.window.terminal__window_buyOrder > div.window__window > div.window__body > div.terminalSwitchBlock__header > div.terminalSwitchBlock__label.terminalSwitchBlock__label_sell.sell");
        private readonly By _sellMarketLimitScaledButton =
           By.XPath("/html/body/div[2]/div[7]/div[2]/div/div[1]/div[4]/div[2]/div[2]/div[2]/form[2]/div[9]/button");
        private readonly By _hitBitChartButton =
          By.Id("switcherToTv");
        private readonly By _chartPropertiesButton =
          By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/div/div/div/div/div[6]/div");
        private readonly By _chartPropertiesBackgroundButton =
          By.CssSelector("body > div._tv-dialog._tv-dialog-nonmodal.ui-draggable > div._tv-dialog-content > div.properties-tabs.tv-tabs.ui-draggable-handle > a.properties-tabs-label.tv-tabs__tab.active");
        private readonly By _chartPropertiesBackgroundColorButton =
          By.CssSelector("body > div._tv-dialog._tv-dialog-nonmodal.ui-draggable > div._tv-dialog-content > div:nth-child(4) > div > div:nth-child(1) > table > tbody > tr:nth-child(1) > td:nth-child(2) > span");
        private readonly By _chartPropertiesBackgroundColorToSwitchButton =
          By.CssSelector("body > div.tvcolorpicker-popup.opened > div.tvcolorpicker-swatches-area > table:nth-child(3) > tbody > tr:nth-child(3) > td:nth-child(9) > div > div");
        private readonly By _chartPropertiesBackgroundApproveButton =
          By.CssSelector("body > div._tv-dialog._tv-dialog-nonmodal.ui-draggable > div._tv-dialog-content > div.main-properties.main-properties-aftertabs > div > a._tv-button.ok");
        private readonly By _chartIndicatorsButton =
          By.Id("header-toolbar-indicators");
        private readonly By _chartIndicatorsAccumDistribButton =
         By.CssSelector("body > div.tv-dialog.js-dialog.tv-insert-indicator-dialog.i-minimized.tv-dialog--popup.i-focused.ui-draggable > div.tv-insert-indicator-dialog__body.js-dialog__scroll-wrap > div.tv-insert-indicator-dialog__right-panel.js-right-panel > div.tv-insert-indicator-dialog__pages.js-pages.i-active > div:nth-child(3) > div > div:nth-child(1) > div");
        private readonly By _chartIndicatorsAccumDistribDeleteButton =
         By.CssSelector("body > div.js-rootresizer__contents > div.layout__area--center > div > div.chart-container-border > div.chart-widget > table > tbody > tr:nth-child(3) > td.chart-markup-table.pane.pane--cursor-pointer > div > div.pane-legend > div > span.pane-legend-icon-container > a.pane-legend-icon.apply-common-tooltip.delete");
        private readonly By _chartCandlesListButton =
         By.CssSelector("#header-toolbar-chart-styles > div");
        private readonly By _chartCandlesListBarsButton =
         By.CssSelector("#__outside-render-1 > div > div > div > div > div > div:nth-child(1)");
        private readonly By _amountSlider25PercentsButton =
          By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.terminal__edit-container.on_advanced > div:nth-child(2) > div > div.terminal.on_advanced > div.terminal__window.window.terminal__window_buyOrder > div.window__window > div.window__body > div.terminalSwitchBlocks.window__terminalSwitchBlocks > form.form.form_createOrder.form_newErrors.form_createOrder_Sell.window__form_createOrder.form_createOrder__withAmountSlider.market > div.form_createOrder__entries.ui-clearfix > div.form_createOrder__slider.form_createOrder__Sell.ui-slider.ui-slider-horizontal.ui-widget.ui-widget-content.ui-corner-all > div.sliderBg > div.sliderStepWrp.s25");
        private readonly By _amountSlider50PercentsButton =
          By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.terminal__edit-container.on_advanced > div:nth-child(2) > div > div.terminal.on_advanced > div.terminal__window.window.terminal__window_buyOrder > div.window__window > div.window__body > div.terminalSwitchBlocks.window__terminalSwitchBlocks > form.form.form_createOrder.form_newErrors.form_createOrder_Sell.window__form_createOrder.form_createOrder__withAmountSlider.market > div.form_createOrder__entries.ui-clearfix > div.form_createOrder__slider.form_createOrder__Sell.ui-slider.ui-slider-horizontal.ui-widget.ui-widget-content.ui-corner-all > div.sliderBg > div.sliderStepWrp.s50");

        public TradingPage(IWebDriver driver) : base(driver) { }

        public void WaitUntilTradingPageIsLoaded(double waitTime)
        {
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            Wait.Until(
                ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("body > div.wrap.wrap-static.wrap_terminal > div.header-container-chunk.react-chunk > div > div > div > div > div.styles__topPart--2NpVr > div.styles__tools--2XUJY > div:nth-child(1) > div.styles__balanceInfo--1AnT7 > div:nth-child(2) > span:nth-child(1)")));
        }
        public decimal GetBTCBalance()
        {
            WaitUntilTradingPageIsLoaded(1);
            IWebElement spotBalanceBTC = driver.FindElement(_spotBalanceBTC);
            string stringValue = spotBalanceBTC.GetAttribute("innerText").ToString();
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            return Math.Round(Convert.ToDecimal(stringValue, formatter),5);
        }
        public int LimitOrdersCounter()
        {
            IWebElement activeOrders = driver.FindElement(_activeOrders);
            WaitUntilTradingPageIsLoaded(2);
            string stringValue = activeOrders.GetAttribute("innerText").ToString().Trim(new Char[] { '(', ')' });
            return Convert.ToInt32(stringValue);
        }
        public decimal PercentageAmount()
        {
            var amountSellMarketInputField = driver.FindElement(_amountSellMarketInputField);
            string stringValue = amountSellMarketInputField.GetAttribute("value");
            if (stringValue == "NaN")
            {
                return 0;
            }
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            return Math.Round(Convert.ToDecimal(stringValue, formatter),5);
        }

        public void TestClick()
        {
            var sellMarketLimitScaledButton = driver.FindElement(_sellMarketLimitScaledButton);
            sellMarketLimitScaledButton.Click();
            Log.Info("Just check");
            
        }
        public void PopUpSkip()
        {
            var popUpSkipButton = driver.FindElement(_popUpSkipButton);
            popUpSkipButton.Click();
            Log.Info("Popup window has been closed");
        }

        public void SwitchToBuyBTC()
        {
            var buyBTCButton = driver.FindElement(_buyBTCButton);
            buyBTCButton.Click();
            Log.Info("Buy BTC button has been pressed");
        }

        public void SwitchToSellBTC()
        {
            var sellBTCButton = driver.FindElement(_sellBTCButton);
            sellBTCButton.Click();
            Log.Info("Sell BTC button has been pressed");

        }

        public void SwitchToBuyMarket()
        {
            var marketBuyButton = driver.FindElement(_marketBuyButton);
            marketBuyButton.Click();
            Log.Info("Market order button has been pressed in Buy BTC form");

        }

        public void SwitchToBuyLimit()
        {
            var limitBuyButton = driver.FindElement(_limitBuyButton);
            limitBuyButton.Click();
            Log.Info("Limit order button has been pressed in Buy BTC form");

        }
        public void SwitchToBuyScaled()
        {
            var scaledBuyButton = driver.FindElement(_scaledBuyButton);
            scaledBuyButton.Click();
            Log.Info("Scaled order button has been pressed in Buy BTC form");

        }
        public void SwitchToSellMarket()
        {
            var marketSellButton = driver.FindElement(_marketSellButton);
            marketSellButton.Click();
            Log.Info("Market button has been pressed in Sell BTC form");

        }

        public void SwitchToSellLimit()
        {
            var limitSellButton = driver.FindElement(_limitSellButton);
            limitSellButton.Click();
            Log.Info("Limit button has been pressed in Sell BTC form");

        }
        public void SwitchToSellScaled()
        {
            var scaledSellButton = driver.FindElement(_scaledSellButton);
            scaledSellButton.Click();
            Log.Info("Scaled button has been pressed in Sell BTC form");

        }
        public void SwitchSchema()
        {
            var hitBitChartButton = driver.FindElement(_hitBitChartButton);
            hitBitChartButton.Click();
            Log.Info("Schema-switcher has been pressed");

        }
        public void OpenProperties()
        {
            //Thread.Sleep(2000);
            var chartPropertiesButton = driver.FindElement(_chartPropertiesButton);
            chartPropertiesButton.Click();
            Log.Info("Properties button has been pressed");


        }
        public void OpenBackgroundProperties()
        {
            var chartPropertiesBackgroundButton = driver.FindElement(_chartPropertiesBackgroundButton);
            chartPropertiesBackgroundButton.Click();
            Log.Info("Background properties has been pressed");

        }
        public void OpenBackgroundColorProperties()
        {
            var chartPropertiesBackgroundColorButton = driver.FindElement(_chartPropertiesBackgroundColorButton);
            chartPropertiesBackgroundColorButton.Click();
            Log.Info("Background color properties has been pressed");

        }

        public void ChooseBackgroundColorProperties()
        {
            var chartPropertiesBackgroundColorToSwitchButton = driver.FindElement(_chartPropertiesBackgroundColorToSwitchButton);
            chartPropertiesBackgroundColorToSwitchButton.Click();
            Log.Info("Preferred color has been pressed");

        }
        public void ApproveBackgroundColorProperties()
        {
            var chartPropertiesBackgroundApproveButton = driver.FindElement(_chartPropertiesBackgroundApproveButton);
            chartPropertiesBackgroundApproveButton.Click();
            Log.Info("Background color changes has been approved");

        }
        public void OpenIndicatorsList()
        {
            var chartIndicatorsButton = driver.FindElement(_chartIndicatorsButton);
            chartIndicatorsButton.Click();
            Log.Info("Indicators list button has been pressed");

        }
        public void AddIndicator()
        {
            var chartIndicatorsAccumDistribButton = driver.FindElement(_chartIndicatorsAccumDistribButton);
            chartIndicatorsAccumDistribButton.Click();
            Log.Info("Preffered indicator has been chosen and added");

        }
        public void DeleteIndicator()
        {
            var chartIndicatorsAccumDistribDeleteButton = driver.FindElement(_chartIndicatorsAccumDistribDeleteButton);
            chartIndicatorsAccumDistribDeleteButton.Click();
            Log.Info("Preffered indicator has been deleted");

        }
        public void OpenCandlesList()
        {
            var chartCandlesListButton = driver.FindElement(_chartCandlesListButton);
            chartCandlesListButton.Click();
            Log.Info("Candles list button has been pressed");

        }
        public void ChooseBars()
        {
            var chartCandlesListBarsButton = driver.FindElement(_chartCandlesListBarsButton);
            chartCandlesListBarsButton.Click();
            Log.Info("Bars has been chosen");

        }
        public void SelectSellPercentage()
        {
            var amountSlider50PercentsButton = driver.FindElement(_amountSlider50PercentsButton);
            amountSlider50PercentsButton.Click();
            var amountSlider25PercentsButton = driver.FindElement(_amountSlider25PercentsButton);
            amountSlider25PercentsButton.Click();
            Log.Info("We choose 25% of BTC balance to sell");

        }

        public void BuyMarketLimitScaled()
        {
            var buyMarketLimitScaledButton = driver.FindElement(_buyMarketLimitScaledButton);
            buyMarketLimitScaledButton.Click();
            Log.Info("Buy button has been pressed, transaction has been approved");

        }
        public void SellMarketLimitScaled()
        {
            var sellMarketLimitScaledButton = driver.FindElement(_sellMarketLimitScaledButton);
            sellMarketLimitScaledButton.Click();
            Log.Info("Sell button has been pressed, transaction has been approved");

        }

        public void SetAmountMarketBuy(string val)
        {
            var amountBuyMarketInputField = driver.FindElement(_amountBuyMarketInputField);
            //Thread.Sleep(200);
            amountBuyMarketInputField.Click();
            amountBuyMarketInputField.SendKeys(val);
            Log.Info("Amount field has been filled");

        }
        public void SetAmountLimitBuy(string val)
        {
            var amountBuyLimitInputField = driver.FindElement(_amountBuyLimitInputField);
            //Thread.Sleep(200);
            amountBuyLimitInputField.Click();
            amountBuyLimitInputField.SendKeys(val);
            Log.Info("Amount field has been filled");

        }
        public void SetAmountScaleBuy(string val)
        {
            var amountBuyScaleInputField = driver.FindElement(_amountBuyScaleInputField);
            //Thread.Sleep(200);
            amountBuyScaleInputField.Click();
            amountBuyScaleInputField.SendKeys(val);
            Log.Info("Amount field has been filled");

        }
        public void SetAmountMarketSell(string val)
        {
            var amountSellMarketInputField = driver.FindElement(_amountSellMarketInputField);
            //Thread.Sleep(200);
            amountSellMarketInputField.Click();
            amountSellMarketInputField.SendKeys(val);
            Log.Info("Amount field has been filled");

        }
        public void SetAmountLimitSell(string val)
        {
            var amountSellLimitInputField = driver.FindElement(_amountSellLimitInputField);
            //Thread.Sleep(200);
            amountSellLimitInputField.Click();
            amountSellLimitInputField.SendKeys(val);
            Log.Info("Amount field has been filled");

        }
        public void SetAmountScaleSell(string val)
        {
            var amountSellScaleInputField = driver.FindElement(_amountSellScaleInputField);
            //Thread.Sleep(200);
            amountSellScaleInputField.Click();
            amountSellScaleInputField.SendKeys(val);
            Log.Info("Amount field has been filled");

        }
        public void SetPriceForLimit(string val)
        {
            var priceInputLimitField = driver.FindElement(_priceInputLimitField);
            priceInputLimitField.Click();
            priceInputLimitField.SendKeys(val);
            Log.Info("Price field has been filled");

        }
        public void SetPriceForSaleLimit(string val)
        {
            var priceInputLimitSellField = driver.FindElement(_priceInputLimitSellField);
            priceInputLimitSellField.Click();
            priceInputLimitSellField.SendKeys(val);
            Log.Info("Price field has been filled");

        }
        public void SetPriceStepForScaleBuy(string val)
        {
            var priceStepBuyField = driver.FindElement(_priceStepBuyField);
            priceStepBuyField.Click();
            priceStepBuyField.SendKeys(val);
            Log.Info("Price Step field has been filled");

        }
        public void SetPriceStepForScaleSell(string val)
        {
            var priceStepSellField = driver.FindElement(_priceStepSellField);
            priceStepSellField.Click();
            priceStepSellField.SendKeys(val);
            Log.Info("Price Step field has been filled");

        }
        public void SetMinPriceForScaleBuy(string val)
        {
            var priceMinBuyField = driver.FindElement(_priceMinBuyField);
            priceMinBuyField.Click();
            priceMinBuyField.SendKeys(val);
            Log.Info("Min Price field has been filled");

        }
        public void SetMaxPriceForScaleBuy(string val)
        {
            var priceMaxBuyField = driver.FindElement(_priceMaxBuyField);
            priceMaxBuyField.Click();
            priceMaxBuyField.SendKeys(val);
            Log.Info("Max Price field has been filled");

        }
        public void SetOrderCountBuy(string val)
        {
            var orderCountBuyField = driver.FindElement(_orderCountBuyField);
            orderCountBuyField.Click();
            orderCountBuyField.Clear();
            orderCountBuyField.SendKeys(val);
            Log.Info("Order Count field has been filled");

        }

        public void SetMinPriceForScaleSale(string val)
        {
            var priceMinSellField = driver.FindElement(_priceMinSellField);
            priceMinSellField.Click();
            priceMinSellField.SendKeys(val);
            Log.Info("Min Price field has been filled");

        }
        public void SetMaxPriceForScaleSale(string val)
        {
            var priceMaxSellField = driver.FindElement(_priceMaxSellField);
            priceMaxSellField.Click();
            priceMaxSellField.SendKeys(val);
            Log.Info("Max Price field has been filled");

        }
        public void SetOrderCountSale(string val)
        {
            var orderCountSellField = driver.FindElement(_orderCountSellField);
            orderCountSellField.Click();
            orderCountSellField.Clear();
            orderCountSellField.SendKeys(val);
            Log.Info("Order Count field has been filled");

        }

    }
}
