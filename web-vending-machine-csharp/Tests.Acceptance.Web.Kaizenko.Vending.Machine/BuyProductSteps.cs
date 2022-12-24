using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Tests.Acceptance.Web.Excella.Vending.Machine
{

    [Binding]
    public class BuyProductSteps :IDisposable
    {
        private IWebDriver Browser;
        private const string HOME_PAGE_URL = "http://localhost:5000/VendingMachine";       

        [BeforeScenario]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("ignore-certificate-errors");            
            Browser = new ChromeDriver(options);
            Browser.Navigate().GoToUrl(HOME_PAGE_URL);
        }

        [AfterScenario]
        public void Teardown()
        {
            var button = Browser.FindElement(By.Id("releaseChange"));
            button.Click();
            Browser.Close();
            Browser.Quit();
        }

        [Given(@"I have inserted (.*) quarter\(s\)")]
        public void WhenIInsertQuarters(int numberOfQuarters)
        {           
            for (int i = 0; i < numberOfQuarters; i++)
            {
                var button = Browser.FindElement(By.Id("insertCoin"));
                button.Click();
            }                  
        }      

        [When(@"I release the change")]
        public void WhenIReleaseTheChange()
        {           
            var button = Browser.FindElement(By.Id("releaseChange"));
            button.Click();           
        }

        [Then(@"I should receive (.*) cents")]
        public void ThenIShouldReceiveXCentsInChange(int cents)
        {
            var wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));
            var elementText = wait.Until(drv => drv.FindElement(By.Id("releasedChangeAmount"))).Text;
            var releasedChange = int.Parse(elementText);
            Assert.That(releasedChange, Is.EqualTo(cents));
        }

        [Given(@"I purchase a product")]
        public void GivenIPurchaseAProduct()
        {
            var button = Browser.FindElement(By.Id("buyProduct"));
            button.Click();
        }

        public void Dispose()
        {
            Browser?.Quit();
            Browser?.Dispose();
            Browser = null;
        }
    }
}