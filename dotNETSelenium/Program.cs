using dotNETSelenium.Config;
using dotNETSelenium.Config.Interface;
using dotNETSelenium.Pages;
using dotNETSelenium.Tests;
using dotNETSelenium.Utils;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;

var services = new ServiceCollection();

services.AddSingleton<IWebDriverFactory, WebDriverFactory>();

services.AddScoped<IWebDriver>(provider =>
{
    var factory = provider.GetRequiredService<IWebDriverFactory>();
    return factory.Create();
});

services.AddScoped<HomePage>();
services.AddScoped<CotacoesPage>();
services.AddScoped<ResultadoPage>();
services.AddScoped<BancoCentralTest>();
services.AddScoped<WaitHelper>();

var provider = services.BuildServiceProvider();

// Por ser um projeto de execução única para trazer os dados, fiz dessa forma com o teste rodando dentro do program,
// mas em um cenário real de testes, o ideal seria ter um teste para cada cenário e rodar eles individualmente.
// A passagem dos dados para a pesquisa também seria feita de forma dinâmica, provavelmente através de um controller que receberia os dados necessários ou arquivo de configuração
// podendo assim serem feitas várias pesquisas diferentes de forma mais rápida e fácil, sem precisar alterar o código sempre.
using (var scope = provider.CreateScope())
{
    var test = scope.ServiceProvider.GetRequiredService<BancoCentralTest>();
    test.Run();
}