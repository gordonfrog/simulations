using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Tests.Web.Kaizenko.Vending.Machine
{
    public class VendingMachineEnd2EndTests
    {
        private IWebDriver Browser;
        private const string HOME_PAGE_URL = "http://localhost:5000/VendingMachine";

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("ignore-certificate-errors");
            Browser = new ChromeDriver(options);
            Browser.Navigate().GoToUrl(HOME_PAGE_URL);
        }

        [TearDown]
        public void Teardown()
        {
            var button = Browser.FindElement(By.Id("releaseChange"));
            button.Click();
            Browser.Close();
            Browser.Quit();
        }

        [Test]
        public void InsertQuarters_WhenClicked_UpdatesBalanceTo25()
        {
            var button = Browser.FindElement(By.Id("insertCoin"));           
            button.Click();            
            var elementText = Browser.FindElement(By.Id("balanceAmount")).Text;
            var balance = int.Parse(elementText);
            Assert.That(balance, Is.EqualTo(25));
        }

        [Test]
        public void Insert2Quarters_WhenClicked_UpdatesBalanceTo50()
        {
            var button = Browser.FindElement(By.Id("insertCoin"));
            button.Click();
            button = Browser.FindElement(By.Id("insertCoin"));
            button.Click();            
            var elementText = Browser.FindElement(By.Id("balanceAmount")).Text;
            var balance = int.Parse(elementText);
            Assert.That(balance, Is.EqualTo(50));
        }

        [Test]
        public void ReleaseChange_WhenClicked_ResetsBalanceTo0()
        {
            var insertButton = Browser.FindElement(By.Id("insertCoin"));
            insertButton.Click();
            var releaseButton = Browser.FindElement(By.Id("releaseChange"));
            releaseButton.Click();
            var balanceText = Browser.FindElement(By.Id("balanceAmount")).Text;
            var balance = int.Parse(balanceText);
            var changeText = Browser.FindElement(By.Id("releasedChangeAmount")).Text;
            var change = int.Parse(changeText);
            Assert.That(balance, Is.EqualTo(0));
            Assert.That(change, Is.EqualTo(25));
        }      
    }
}
