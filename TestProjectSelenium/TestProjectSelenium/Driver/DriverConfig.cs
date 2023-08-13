using OpenQA.Selenium.Chrome;

namespace TestProjectSelenium.Driver
{
    public class DriverConfig
    {
        public static IWebDriver driver;
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
