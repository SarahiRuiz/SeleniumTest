
using TestProjectSelenium.Driver;

namespace TestProjectSelenium.PageObjects
{
    public class BuyProductPage : DriverConfig
    {
        GlobalMethods globalMethods = new GlobalMethods();
        By addToCartButtonXpath = By.XPath("//div[@id='tbodyid']//div[@class='row']//a");
        public void AddToCart()
        {
            IWebElement addToCartButton = driver.FindElement(addToCartButtonXpath);
            globalMethods.waitElementDisplay(addToCartButton);
            Assert.IsTrue(addToCartButton.Displayed, "Button 'Add To Cart' was displayed.");
            addToCartButton.Click();
        }
    }
}
