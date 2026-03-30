using OpenQA.Selenium;

namespace dotNETSelenium.Config.Interface
{
    public interface IWebDriverFactory
    {
        IWebDriver Create();
    }
}
