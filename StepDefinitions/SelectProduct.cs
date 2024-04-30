//Aula 27
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace MyNamespace
{
    [Binding]
    public class StepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver; //objeto dop selenium

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void SetUp()
        {
            //Instanciando o ChromeDriver atraves do WebDriverManager
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver(); // Instanciou o selenium com o chromedriver
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            driver.Manage().Window.Maximize();

        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit(); //encerou o selenium
        }
        [Given(@"que acesso a página inicial do site")]
        public void DadoQueAcessoAPaginaInicialDoSite()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [When(@"preencho o usuário como ""(.*)""")]
        [When(@"preencho o ""(.*)""")]
        public void QuandoPreenchoOUsuarioComo(string username)
        {
            driver.FindElement(By.Id("user-name")).SendKeys(username);
        }

        [When(@"a senha ""(.*)"" e clico no botao Login")]
        public void QuandoASenhaEClicoNoBotaoLogin(string password)
        {
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();
        }

        [When(@"adiciono o produto ""(.*)"" ao carrinho")]
        public void QuandoAdicionoOProdutoAoCarrinho(string product)
        {
           String productSelector = "add-to-cart-" + product.ToLower().Replace(" ","-");
           Console.WriteLine($"Seletor de Produto = {productSelector}");
        }
        
        [When(@"clico no icone do carrinho de compras")]
        public void QuandoClicoNoIconeDoCarrinhoDeCompras()
        {
            
        }

       [Then(@"exibe ""(.*)"" no titulo da secao")]
        public void EntaoExibeNoTituloDaSecao(string title)
        {
            //Espera explicita pelo elemento span.title ser carregado na pagina
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(3000));
            wait.Until(d => driver.FindElement(By.CssSelector("span.title")).Displayed);
            Assert.That(driver.FindElement(By.CssSelector("span.title")).Text, Is.EqualTo(title));
        }

        [Then(@"exibe a pagina do carrinho com a quantidade ""(.*)""")]
        public void EntaoExibeAPaginaDoCarrinhoComAQuantidade(string p0)
        {
            
        }

        [Then(@"nome do produto ""(.*)""")]
        public void EntaoNomeDoProduto(string p0)
        {
            
        }

        [Then(@"o preco como ""(.*)""")]
        public void EntaoOPrecoComo(string p0)
        {
            
        }
    }
}