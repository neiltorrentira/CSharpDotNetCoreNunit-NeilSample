using NUnit.Framework;
using DotNet_TestNeil.Helper;
using DotNet_TestNeil.Models;

namespace DotNet_TestNeil.Tests
{
    [TestFixture]
    public class TestAmazon : Helpers
    {
        [SetUp]
        public void Setup()
        {
            SetDriver = BrowserType.Chrome;
            Driver.Navigate().GoToUrl(Constant.BaseUrl);
        }

         [Test(Description = "TC01: Validate successful Add to Cart for Toys & Games")]
        public void AddToCartToysGamesTest01(){
            //Switch to “Toys &amp; Games”
            SelectDropDownByText(Constant.CategoryDropdown, "Toys & Games");
            //Search for some product in the search text box.
            EnterText(Constant.SearchTextBox, "woody and buzz toys");
            Click(Constant.SubmitButton);            
            //Select the product and add it to cart
            Click(Constant.FistProduct);
            Click(Constant.AddToCartButton);
            //Validate that the add to cart action was successful
            assertTextEquals(Constant.CartSuccessMessage, "Added to Cart");

            //Do steps 3 - 5 twice - this is 1st time
            SelectDropDownByText(Constant.CategoryDropdown, "Toys & Games");
            EnterText(Constant.SearchTextBox, "Jessie toy story");
            Click(Constant.SubmitButton);
            ClickUnder25DollarsFilter();
            Click(Constant.FistProduct);
            Click(Constant.AddToCartButton);
            assertTextEquals(Constant.CartSuccessMessage, "Added to Cart");

            //Do steps 3 - 5 twice - this is 2nd time
            SelectDropDownByText(Constant.CategoryDropdown, "Toys & Games");
            EnterText(Constant.SearchTextBox, "Jessie toy story");
            Click(Constant.SubmitButton);
            ClickUnder25DollarsFilter();
            Click(Constant.FistProduct);
            Click(Constant.AddToCartButton);
            assertTextEquals(Constant.CartSuccessMessage, "Added to Cart");

            //Go to cart and make sure the purchase doesn’t cost more than 100$
            Click(Constant.CartButton);
            ValidateAmountNotEqualOrGreater(Constant.SubTotal, 100.00);            
        }

        [TearDown]
        public void EndTest()
        {
            CloseBrowser();
        }

    }

}