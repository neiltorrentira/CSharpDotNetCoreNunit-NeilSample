using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using DotNet_TestNeil.Models;
using OpenQA.Selenium.Interactions;

namespace DotNet_TestNeil.Helper
{
    public class Helpers : Browser
    {
        public void Click(string element)
        {
            Driver.FindElement(By.CssSelector(element)).Click();
            Wait(1000);
        }

        public void EnterText(string element, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException();
            Driver.FindElement(By.CssSelector(element)).SendKeys(value);
            Wait(500);
        }

        public void Wait(int time)
        {
            Thread.Sleep(time);
        }

        public void CloseBrowser()
        {
            try
            {
                Wait(1000);
                Driver.Quit();
            }
            catch
            {
                Console.WriteLine("Browser already close");
            }
        }

        public void AssertPageTitle(string title)
        {
            Assert.AreEqual(title, Driver.Title, "Title not matching!");
        }

        public void SelectDropDownByText(string element, string value)
        {
            Wait(2000);
            new SelectElement(Driver.FindElement(By.CssSelector(element))).SelectByText(value);
            Wait(500);
        }

        public void highlightElement(IWebElement element){
            ((IJavaScriptExecutor) Driver).ExecuteScript("arguments[0].style.border='3px solid red'", element);
        }
        
        public void ValidateAmountNotEqualOrGreater(string element, double value){
            Wait(2000);
            try
            {
                IWebElement webElement = Driver.FindElement(By.CssSelector(element));    
                highlightElement(webElement);
                string text = webElement.Text;
                Console.WriteLine("Actual text : " + text);
                int amount = int.Parse(text, System.Globalization.NumberStyles.AllowCurrencySymbol);
                double amountDouble = Convert.ToDouble(amount);
                Console.WriteLine("Parsed Amount : " + amountDouble);
                if (amountDouble >= value) {
                    Console.WriteLine("Test FAILED - Parsed Amount : " + amountDouble 
                    + " is greater or equal to $" + value);
                } else {
                    Console.WriteLine("Test PASSED - Parsed Amount : " + amountDouble 
                    + " is Less than $" + value);
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + By.CssSelector(element) + "' was not found in current context page.");
                throw;
            }
            Wait(1000);
        }

        public void assertTextEquals(string value, string element) {
            Wait(2000);
            try
            {
                IWebElement webElement = Driver.FindElement(By.CssSelector(element));    
                highlightElement(webElement);
                string text = webElement.Text;
                Console.WriteLine("Actual text : " + text);
                Assert.True(text.Equals(value));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + By.CssSelector(element) + "' was not found in current context page.");
                throw;
            }
            Wait(1000);
        }

        public void ClickUnder25DollarsFilter(){
            PressPageDown();
            Wait(500);          
            Click(Constant.Under25Dollars);
            PressPageUp();
            Wait(1000);
        }

        public void PressPageDown(){
            new Actions(Driver).SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();  
        }

        public void PressPageUp(){
            new Actions(Driver).SendKeys(OpenQA.Selenium.Keys.PageUp).Perform();  
        }
    }
}