//Aula 27
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        [Given(@"que acesso a pagina inicial do site")]
        public void DadoQueAcessoAPaginaInicialDoSite()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [When(@"preecho o usuario como ""(.*)""")]
        public void QuandoPreechoOUsuarioComo(string username)
        {
            driver.FindElement(By.Id("user-name")).SendKeys(username);
        }

        [When(@"a senha ""(.*)"" e clico no botao Login")]
        public void QuandoASenhaEClicoNoBotaoLogin(string password)
        {
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();
        }

        [When(@"adiciono o produto no ""(.*)"" ao carrinho")]
        public void QuandoAdicionoOProdutoNoAoCarrinho(string product)
        {
            String productSelector = "add-to-cart-" + product.ToLower().Replace(" ","-");
            Console.WriteLine($"Seletor de Produtos = {productSelector}");
        }
        
        [When(@"clico no icone do carrinho de compras")]
        public void QuandoClicoNoIconeDoCarrinhoDeCompras()
        {
            
        }

        [Then(@"exibe ""Products' no titulo da secao")]
        public void EntaoExibeProductsNoTituloDaSecao(String title)
        {
            Assert.That(driver.FindElement(By.CssSelector("span.title")).Text, Is.EquivalentTo(title));
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