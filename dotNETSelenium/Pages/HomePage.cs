using dotNETSelenium.Utils;
using OpenQA.Selenium;

namespace dotNETSelenium.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly WaitHelper _wait;

        public HomePage(IWebDriver driver, WaitHelper wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl("https://www.bcb.gov.br/");
        }

        public void AccessMenuCambioECapitais()
        {
            _wait.WaitForElement(By.Id("navbarDropdown2")).Click();
            _wait.WaitForElement(By.CssSelector("[data-target='#cambioecapitais']")).Click();
            _wait.WaitForElement(By.CssSelector("[data-target='#cotacoesmoedas']")).Click();
        }

        public void GoToSearchPage()
        {
            _wait.WaitForElement(By.PartialLinkText("Consulta de cotações e boletins")).Click();
        }
    }
}