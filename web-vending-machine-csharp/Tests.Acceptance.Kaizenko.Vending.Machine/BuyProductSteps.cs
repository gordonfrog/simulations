using Kaizenko.Vending.DAL;
using Kaizenko.Vending.Domain;
using Kaizenko.Vending.Machine;
using NUnit.Framework;
using System.Transactions;
using TechTalk.SpecFlow;

namespace Tests.Acceptance.Kaizenko.Vending.Machine
{
    [Binding]
    public class BuyProductSteps
    {
        private IVendingMachine _vendingMachine;
        private TransactionScope _transactionScope;
        private Product _product;
        private int _changeReleased;

        [BeforeFeature]
        public static void BeforeFeature()
        {
            var efDao = new EFPaymentDAO();
            var paymentProcessor = new CoinPaymentProcessor(efDao);
            paymentProcessor.ClearPayments();
        }

        [BeforeScenario]
        public void Setup()
        {
            _product = null;
            _changeReleased = 0;
            _transactionScope = new TransactionScope();
            var efDao = new EFPaymentDAO();
            var paymentProcessor = new CoinPaymentProcessor(efDao);
            _vendingMachine = new VendingMachine(paymentProcessor);
        }

        [AfterScenario]
        public void Teardown()
        {
            _transactionScope.Dispose();
        }

        [Given(@"I have inserted (.*) quarter\(s\)")]
        public void GivenIHaveInsertedAQuarter(int numberOfQuarters)
        {
            for (int i = 0; i < numberOfQuarters; i++)
            {
                _vendingMachine.InsertCoin();
            }            
        }

        [StepDefinition(@"I purchase a product")]
        public void WhenIPurchaseAProduct()
        {
            _product = _vendingMachine.BuyProduct();
        }

        [Then(@"I should receive no change")]
        public void ThenIShouldReceiveNoChange()
        {
            Assert.That(_changeReleased, Is.EqualTo(0));
        }

        [Then(@"I should receive (.*) cents")]
        public void ThenIShouldReceive75Cents(int cents)
        {
            Assert.That(_changeReleased, Is.EqualTo(cents));
        }

        [Then(@"I should receive the product")]
        public void ThenIShouldReceiveTheProduct()
        {
            Assert.That(_product, Is.Not.Null);
        }

        [When(@"I release the change")]
        public void WhenIReleaseTheChange()
        {
            _changeReleased = _vendingMachine.ReleaseChange();
        }

        [Then(@"I should not receive a product")]
        public void ThenIShouldNotReceiveAProduct()
        {
            Assert.That(_product, Is.Null);
        }
    }
}