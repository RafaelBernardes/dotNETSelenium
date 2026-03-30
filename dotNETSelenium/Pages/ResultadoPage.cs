using dotNETSelenium.Dtos;
using dotNETSelenium.Utils;
using OpenQA.Selenium;

namespace dotNETSelenium.Pages
{
    public class ResultadoPage
    {
        private readonly IWebDriver _driver;
        private readonly WaitHelper _wait;
        private By Frame => By.TagName("iframe");

        public ResultadoPage(IWebDriver driver, WaitHelper wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public void ExtractResults()
        {
            var iframe = _wait.WaitForElement(Frame);
            _driver.SwitchTo().Frame(iframe);

            var resultsTable = _wait.WaitForElement(By.CssSelector("table.tabela"));
            var rows = resultsTable.FindElements(By.CssSelector("tbody tr")).ToList();
            var dataRows = rows.Where(row => row.FindElements(By.TagName("td")).Count > 0).ToList();

            ProcessResults(rows, dataRows);

            _driver.SwitchTo().DefaultContent();
        }

        public void ProcessResults(List<IWebElement> rows, List<IWebElement> dataRows)
        {
            var list = new List<ResultadoCotacaoDto>();

            foreach (var row in dataRows)
            {
                var columns = row.FindElements(By.TagName("td")).ToList();

                if (columns.Count < 6)
                    continue;

                var currency = new ResultadoCotacaoDto
                {
                    Data = columns[0].Text,
                    Tipo = columns[1].Text,
                    CotacaoCompra = decimal.Parse(columns[2].Text),
                    CotacaoVenda = decimal.Parse(columns[3].Text),
                    ParidadeCompra = decimal.Parse(columns[4].Text),
                    ParidadeVenda = decimal.Parse(columns[5].Text)
                };

                list.Add(currency);
            }

            Console.WriteLine($"Data  |  Moeda  |  Cotação Compra  |  Cotação Venda  |  Paridade Compra  |  Paridade Venda");

            foreach (var item in list)
            {
                Console.WriteLine($"{item.Data} Euro {item.CotacaoCompra} {item.CotacaoVenda} {item.ParidadeCompra} {item.ParidadeVenda}");
            }

        }
    }
}
