using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Framework.Driver;


namespace Framework.Util
{
    public class ScreenShot
    {
        public static void MakeScreenShot()
        {
            Screenshot ss = ((ITakesScreenshot)DriverManager.GetWebDriver()).GetScreenshot();
            string path = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");

            try
            {
                ss.SaveAsFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName +
                    "/Framework/SavedLogs/" + path + ".png", ScreenshotImageFormat.Png);

                Log.Info("Screenshot is taken");
            }
            catch (Exception e)
            {
                Log.Info(e, "Screenshot isn't taken");
                throw;
            }
        }
    }
}
