using dotNETSelenium.Pages;
using OpenQA.Selenium;

namespace dotNETSelenium.Tests
{
    public class BancoCentralTest
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly CotacoesPage _cotacoesPage;
        private readonly ResultadoPage _resultadoPage;

        public BancoCentralTest(IWebDriver driver, HomePage homePage, CotacoesPage cotacoesPage, ResultadoPage resultadoPage)
        {
            _driver = driver;
            _homePage = homePage;
            _cotacoesPage = cotacoesPage;
            _resultadoPage = resultadoPage;
        }

        public void Run()
        {
            _homePage.GoTo();
            _homePage.AccessMenuCambioECapitais();
            _homePage.GoToSearchPage();

            //Ao clicar na opção das cotações, o sistema muda a página e utiliza um iframe pro formulário na mesma
            _cotacoesPage.SetInitialDateOnSearchMenu("01102025");
            _cotacoesPage.SetFinalDateOnSearchMenu("17112025");
            _cotacoesPage.SetCurrencyOnSearchMenu("222");
            _cotacoesPage.ClickSearchButton();

            //Tabela com o resultado
            _resultadoPage.ExtractResults();

            _driver.Quit();
        }
    }
}
