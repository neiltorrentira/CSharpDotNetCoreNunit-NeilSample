using OpenQA.Selenium;

namespace DotNet_TestNeil.Helper
{
    public class WebDriverFactory
    {
        public static IWebDriver Driver { get; set; }
    }
    public enum PropertyType
    {
        Id,
        CssSelector,
        Classname,
        LinkText
    }
}
