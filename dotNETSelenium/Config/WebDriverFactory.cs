using dotNETSelenium.Config.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace dotNETSelenium.Config
{
    public class WebDriverFactory : IWebDriverFactory
    {
        public IWebDriver Create()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            return new ChromeDriver(options);
        }
    }
}
