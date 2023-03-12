using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DotNet_TestNeil.Helper
{
    public class Browser : WebDriverFactory
    {
        public BrowserType SetDriver
        {
            set
            {
                if (value == BrowserType.Chrome)
                {
                    Console.WriteLine("Setup Driver... : " + BrowserType.Chrome);
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    Driver = new ChromeDriver();                    
                }
                else if (value == BrowserType.Edge)
                {
                    Console.WriteLine("Setup Driver... : " + BrowserType.Edge);
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    Driver = new EdgeDriver();
                }
                else
                {
                    throw new Exception("Driver not found");
                }
                Thread.Sleep(2000);
                PrepareBrowser();
            }
        }

        public static void PrepareBrowser()
        {
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }
    }

    public enum BrowserType
    { Chrome, Edge }

}
