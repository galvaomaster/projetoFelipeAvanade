using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;

namespace AcademiaDeTestes
{
    public class testeDesafioAnderson
    {
        private IWebDriver driver;
        private string baseURL;
        

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            baseURL = "http://automationpractice.com/";
 
        }

        [TearDown]
        public void TeardownTest()
        {

        }


        [Test]
        public void abrirItemHomePage()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.LinkText("Faded Short Sleeve T-shirts")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Dispose();
        }
        [Test]
        public void buscarItem()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.Id("search_query_top")).Click();
            driver.FindElement(By.Id("search_query_top")).Clear();
            driver.FindElement(By.Id("search_query_top")).SendKeys("faded");
            driver.FindElement(By.Name("submit_search")).Click();
            driver.FindElement(By.LinkText("Faded Short Sleeve T-shirts")).Click();
            driver.Dispose();
        }

        [Test]
        public void navegarDepartamento()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            //driver.FindElement(By.LinkText("Dresses")).Click();
            driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[6]/ul/li[2]/a")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'Printed Dress')])[2]")).Click();
            driver.Dispose();
        }

        [Test]
        public void adicionarCarrinho()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.LinkText("Faded Short Sleeve T-shirts")).Click();
            driver.FindElement(By.XPath("//p[@id='add_to_cart']/button/span")).Click();
            driver.Dispose();
        }

        [Test]
        public void criarUsuario()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("andersonavanade1@gmail.com");
            driver.FindElement(By.XPath("//button[@id='SubmitCreate']/span")).Click();
            Assert.IsTrue(driver.FindElement(By.Id("customer_firstname")).Displayed);
            driver.FindElement(By.Id("customer_firstname")).SendKeys("anderson");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("galvao");
            driver.FindElement(By.Id("passwd")).SendKeys("123456");
            driver.FindElement(By.Id("address1")).SendKeys("rua");
            driver.FindElement(By.Id("city")).SendKeys("Hellcife");
            driver.FindElement(By.Id("id_state")).Click();
            new SelectElement(driver.FindElement(By.Id("id_state"))).SelectByText("Alabama");
            driver.FindElement(By.Id("id_state")).Click();
            driver.FindElement(By.Id("postcode")).SendKeys("51000");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("819999999");
            driver.FindElement(By.XPath("//button[@id='submitAccount']/span")).Click();
            driver.Dispose();
        }

        [Test]
        public void realizarCompra()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.LinkText("Faded Short Sleeve T-shirts")).Click();
            driver.FindElement(By.XPath("//p[@id='add_to_cart']/button/span")).Click();
            driver.FindElement(By.XPath("//div[@id='layer_cart']/div/div[2]/div[4]/a/span")).Click();
            Assert.IsTrue(driver.FindElement(By.CssSelector("#cart_title")).Displayed);
            driver.FindElement(By.XPath("//div[@id='center_column']/p[2]/a/span")).Click();
            Assert.IsTrue(driver.FindElement(By.CssSelector(".page-heading")).Displayed);
            driver.FindElement(By.Id("email")).SendKeys("andersonavanade@gmail.com");
            driver.FindElement(By.Id("passwd")).SendKeys("123456");
            driver.FindElement(By.XPath("//button[@id='SubmitLogin']/span")).Click();
            Assert.IsTrue(driver.FindElement(By.CssSelector(".page-heading")).Displayed);
            driver.FindElement(By.CssSelector("button.button:nth-child(4) > span:nth-child(1)")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='carrier_area']/h1")).Displayed);
            driver.FindElement(By.Id("cgv")).Click();
            driver.FindElement(By.CssSelector("button.button:nth-child(4) > span")).Click();
            Assert.IsTrue(driver.FindElement(By.CssSelector("html body#order.order.hide-left-column.hide-right-column.lang_en div#page div.columns-container div#columns.container div.breadcrumb.clearfix span.navigation_page")).Displayed);
            driver.FindElement(By.CssSelector(".bankwire")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='center_column']/h1")).Displayed);
            driver.FindElement(By.XPath("//*[@id='cart_navigation']/button/span")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='center_column']/div/p/strong")).Displayed);
            driver.Dispose();
        }


    }
}
