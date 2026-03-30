using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace dotNETSelenium.Utils
{
    public class WaitHelper
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public WaitHelper(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            _wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public IWebElement WaitForElement(By locator)
        {
            return _wait.Until(driver => {
                var element = driver.FindElement(locator);
                return element.Displayed ? element : null;
            });
        }
    }
}
