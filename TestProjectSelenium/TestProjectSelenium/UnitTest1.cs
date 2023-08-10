using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProjectSelenium.Data;
using TestProjectSelenium.Models;

namespace SeleniumCsharp
{
    public class Tests
    {
        IWebDriver driver;
        String demoBlazeUrl = "https://demoblaze.com/";
        By logoImageXpath = By.XPath("//nav[@id='narvbarx']//a/img");
        By productFisrtOptionXpath = By.XPath("//a[contains(text(), 'Samsung galaxy s6')]");
        By addToCartButtonXpath = By.XPath("//div[@id='tbodyid']//div[@class='row']//a");
        By logInButtonXpath = By.XPath("//button[text()='Log in']");
        By logInTitleByID = By.Id("login2");
        By logInUserNameByID = By.Id("loginusername");
        By logInPasswordByID = By.Id("loginpassword");

        [Test]
        public void LogInInvalid()
        {
            var invalidUser = UserLoginDataInstances.InvalidUser;
            verifyLogo();
            IWebElement logInTitle = driver.FindElement(logInTitleByID);
            Assert.IsTrue(logInTitle.Displayed, "Verify if logIn Title was displayed.");
            logInTitle.Click();
            FillLogInPopUp(invalidUser);
            IWebElement logInButton = driver.FindElement(logInButtonXpath);
            logInButton.Click();
            Thread.Sleep(Const.TwoSecond);
            IAlert alertPopUp = driver.SwitchTo().Alert();
            String alertPopUpText = alertPopUp.Text;
            Assert.AreEqual(Const.WrongMessagePassword, alertPopUpText, 
                $"Verify if alert pop up message is '{Const.WrongMessagePassword}' to '{alertPopUpText}'");
            Thread.Sleep(Const.TwoSecond);
            alertPopUp.Accept();
        }

        [Test]
        public void BuyAProduct()
        {
            verifyLogo();
            AddToCart();
        }

        public void verifyLogo()
        {
            driver.Navigate().GoToUrl(demoBlazeUrl);
            IWebElement logoImage = driver.FindElement(logoImageXpath);
            Assert.IsTrue(logoImage.Displayed, "Logo demoblaze was displayed.");
        }

        public void FillLogInPopUp(UserLoginData user)
        {
            driver.SwitchTo().ActiveElement();
            IWebElement logInUserNameInput = driver.FindElement(logInUserNameByID);
            Thread.Sleep(Const.TwoSecond);
            logInUserNameInput.SendKeys(user.UserName);
            IWebElement logInPasswordInput = driver.FindElement(logInPasswordByID);
            logInPasswordInput.SendKeys(user.Password);
        }

        public String DinamicElement(String xpath, String value)
        {
            return xpath.Replace("?", value);
        }

  /*      public void waitElement(IWebElement element, int timeMilliseconds = Const.TwoSecond)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeMilliseconds));
            wait.Until(WaitType(element.GetAttribute("xpath")));
        }
       private Func<IWebDriver, bool> WaitType(string xpath)
        {
            return (driver) =>
            {
                    try
                    {
                        return driver.FindElement(driver.FindElement(By.XPath(xpath))).Text.Equals("");
                    }
                    catch
                    {
                        return false;
                    }
            };
         }
        */

        public void AddToCart()
        {
            Thread.Sleep(Const.TwoSecond);
            IWebElement productFisrtOption = driver.FindElement(productFisrtOptionXpath);
            Assert.IsTrue(productFisrtOption.Displayed, "Logo product Fisrt Option was displayed.");
            productFisrtOption.Click();
            Thread.Sleep(Const.TwoSecond);
            IWebElement addToCartButton = driver.FindElement(addToCartButtonXpath);
            Assert.IsTrue(addToCartButton.Displayed, "Button 'Add To Cart' was displayed.");
            addToCartButton.Click();
            Thread.Sleep(Const.TwoSecond);
            IAlert alertPopUp = driver.SwitchTo().Alert();
            String alertPopUpText = alertPopUp.Text;
            Assert.AreEqual(Const.ProductAddedMessage, alertPopUpText,
                $"Verify if alert pop up message is '{Const.ProductAddedMessage}' to '{alertPopUpText}'");
            Thread.Sleep(Const.TwoSecond);
            alertPopUp.Accept();
        }


        [OneTimeSetUp]
        public void Setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + @"\drivers\");
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }

}
