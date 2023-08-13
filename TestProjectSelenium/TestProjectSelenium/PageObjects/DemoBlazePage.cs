using TestProjectSelenium.Models;
using TestProjectSelenium.Driver;
using TestProjectSelenium.Data;

namespace TestProjectSelenium.PageObjects
{
    public class DemoBlazePage : DriverConfig
    {
        GlobalMethods globalMethods = new GlobalMethods();
        string demoBlazeUrl = "https://demoblaze.com/";
        By logoImageXpath = By.XPath("//nav[@id='narvbarx']//a/img");
        By logInUserNameByID = By.Id("loginusername");
        By logInPasswordByID = By.Id("loginpassword");
        String productOptionDynamic = "(//div[@id='tbodyid']//h4)[?]";
        By productsTitle = By.XPath("//div[@id='tbodyid']//h4");
        public void VerifyLogo()
        {
            driver.Navigate().GoToUrl(demoBlazeUrl);
            IWebElement logoImage = driver.FindElement(logoImageXpath);
            Assert.IsTrue(logoImage.Displayed, "Logo demoblaze was displayed.");
        }
        public void FillLogInPopUp(UserLoginData user)
        {
            driver.SwitchTo().ActiveElement();
            IWebElement logInUserNameInput = driver.FindElement(logInUserNameByID);
            globalMethods.waitElementDisplay(logInUserNameInput);
            logInUserNameInput.SendKeys(user.UserName);
            IWebElement logInPasswordInput = driver.FindElement(logInPasswordByID);
            logInPasswordInput.SendKeys(user.Password);
        }
        public void ClickRandomProduct()
        {
            Random random = new Random();
            int totalProductsTitle = TotalElements(productsTitle);
            Thread.Sleep(Const.TwoSecond);
            int randomNumber = random.Next(1, totalProductsTitle);
            String productTitleRandomString = globalMethods.DynamicToElement(productOptionDynamic, $"{randomNumber}");
            IWebElement productTitleIWebEle = driver.FindElement(By.XPath(productTitleRandomString));
            globalMethods.waitElementDisplay(productTitleIWebEle);
            Assert.IsTrue(productTitleIWebEle.Displayed, "Verify if product Title IWeb Element was displayed.");
            productTitleIWebEle.Click();
        }
        public int TotalElements(By element)
        {
            return driver.FindElements(element).Count;
        }
    }
}
