using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProjectSelenium.Data;
using TestProjectSelenium.Models;
using TestProjectSelenium.PageObjects;
using TestProjectSelenium.Driver;

namespace TestProjectSelenium.Tests.UI
{
    public class Tests : DriverConfig
    {
        DemoBlazePage demoBlazePage = new DemoBlazePage();
        GlobalMethods globalMethods = new GlobalMethods();
        BuyProductPage buyProductPage = new BuyProductPage();
        By logInButtonXpath = By.XPath("//button[text()='Log in']");
        By logInTitleByID = By.Id("login2");

        UserLoginData invalidUser = UserLoginDataInstances.InvalidUser;

        [Test]
        public void LogInInvalid()
        {
            demoBlazePage.VerifyLogo();
            IWebElement logInTitle = driver.FindElement(logInTitleByID);
            Assert.IsTrue(logInTitle.Displayed, "Verify if logIn Title was displayed.");
            logInTitle.Click();
            demoBlazePage.FillLogInPopUp(invalidUser);
            IWebElement logInButton = driver.FindElement(logInButtonXpath);
            logInButton.Click();
            globalMethods.AssertAndAcceptPopUp(Const.WrongMessagePassword);
        }

        [Test]
        public void BuyAProduct()
        {
            demoBlazePage.VerifyLogo();
            demoBlazePage.ClickRandomProduct();
            buyProductPage.AddToCart();
            globalMethods.AssertAndAcceptPopUp(Const.ProductAddedMessage);
        }
    }

}
