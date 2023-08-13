using OpenQA.Selenium.Support.UI;
using TestProjectSelenium.Driver;
using TestProjectSelenium.Data;

namespace TestProjectSelenium.PageObjects
{    
    public class GlobalMethods : DriverConfig
    {
        public string DynamicToElement(string xpath, string value)
        {
            return xpath.Replace("?", value);
        }

        public void waitElementDisplay(IWebElement element, int timeMilliseconds = Const.TwoSecond)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeMilliseconds));
            wait.Until(d => element.Displayed);
        }

        public void waitElementHasValue(IWebElement element, string expectedValue, int timeMilliseconds = Const.TwoSecond)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeMilliseconds));
            wait.Until(WaitType(element.GetAttribute("xpath"), expectedValue));
        }

        private Func<IWebDriver, bool> WaitType(string xpath, string expectedValue)
        {
            return (driver) =>
            {
                try
                {
                    return driver.FindElement(By.XPath(xpath)).Text.Equals(expectedValue);
                }
                catch
                {
                    return false;
                }
            };
        }
        public void AssertAndAcceptPopUp(String expectedPopUpMessage)
        {
            Thread.Sleep(Const.TwoSecond);
            IAlert alertPopUp = driver.SwitchTo().Alert();
            string alertPopUpText = alertPopUp.Text;
            Assert.AreEqual(expectedPopUpMessage, alertPopUpText,
                $"Verify if alert pop up message is '{expectedPopUpMessage}' to '{alertPopUpText}'");
            Thread.Sleep(Const.TwoSecond);
            alertPopUp.Accept();
        }
    }
}
