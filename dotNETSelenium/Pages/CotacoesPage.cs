using System.Collections;
using dotNETSelenium.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace dotNETSelenium.Pages
{
    public class CotacoesPage
    {
        private readonly IWebDriver _driver;
        private readonly WaitHelper _wait;
        private By Frame => By.TagName("iframe");

        public CotacoesPage(IWebDriver driver, WaitHelper wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public void SetInitialDateOnSearchMenu(string initialDate)
        {
            var iframe = _wait.WaitForElement(Frame);
            _driver.SwitchTo().Frame(iframe);

            var searchBox = _wait.WaitForElement(By.Name("DATAINI"));
            searchBox.Clear();
            searchBox.SendKeys(initialDate);

            _driver.SwitchTo().DefaultContent();
        }

        public void SetFinalDateOnSearchMenu(string finalDate)
        {
            var iframe = _wait.WaitForElement(Frame);
            _driver.SwitchTo().Frame(iframe);

            var searchBox = _wait.WaitForElement(By.Name("DATAFIM"));
            searchBox.Clear();
            searchBox.SendKeys(finalDate);

            _driver.SwitchTo().DefaultContent();
        }

        public void SetCurrencyOnSearchMenu(string currencyCode)
        {
            var iframe = _wait.WaitForElement(Frame);
            _driver.SwitchTo().Frame(iframe);

            var selectElement = new SelectElement(_wait.WaitForElement(By.Name("ChkMoeda")));
            selectElement.SelectByValue(currencyCode);

            _driver.SwitchTo().DefaultContent();
        }

        public void ClickSearchButton()
        {
            // Aceitar cookies caso o banner apareça. Se o banner aparecer, ele cobre o botão em telas menores e aí o selenium não consegue clicar kkkkk
            // Está antes do iframe pois não faz parte dele
            var cookiesButtonElement = _wait.WaitForElement(By.XPath("//button[contains(normalize-space(),'Aceitar cookies')]"));
            if (cookiesButtonElement != null)
                cookiesButtonElement.Click();

            var iframe = _wait.WaitForElement(Frame);
            _driver.SwitchTo().Frame(iframe);

            _wait.WaitForElement(By.CssSelector("[value='Pesquisar']")).Click();

            _driver.SwitchTo().DefaultContent();
        }
    }
}
