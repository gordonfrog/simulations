using Kaizenko.Vending.DAL;
using Kaizenko.Vending.Domain;
using Moq;
using NUnit.Framework;

namespace Tests.Unit.Kaizenko.Vending.Domain
{
    [TestFixture]
    public class CoinPaymentProcessorTests
    {
        CoinPaymentProcessor _paymentProcessor;
        Mock<IPaymentDAO> _paymentDAO;

        [SetUp]
        public void SetUp()
        {
            _paymentDAO = new Mock<IPaymentDAO>();
            _paymentProcessor = new CoinPaymentProcessor(_paymentDAO.Object);
        }

        [Test]
        public void Payment_WhenNoMoney_ExpectBalanceIsZero()
        {
            _paymentDAO.Setup(d => d.Retrieve()).Returns(0);

            var balance = _paymentProcessor.Payment;

            Assert.That(balance, Is.EqualTo(0));
        }

        [Test]
        public void Payment_WhenMoney_ExpectBalanceIsNotZero()
        {
            _paymentDAO.Setup(d => d.Retrieve()).Returns(25);

            var balance = _paymentProcessor.Payment;

            Assert.That(balance, Is.EqualTo(25));
        }

        [Test]
        public void IsPaymentMade_WhenNoMoney_ExpectFalse()
        {
            _paymentDAO.Setup(d => d.Retrieve()).Returns(0);

            var actual = _paymentProcessor.IsPaymentMade();

            Assert.That(actual, Is.False);
        }

        [Test]
        public void IsPaymentMade_WhenLessThan50Cents_ExpectFalse()
        {
            _paymentDAO.Setup(d => d.Retrieve()).Returns(25);

            var actual = _paymentProcessor.IsPaymentMade();

            Assert.That(actual, Is.False);
        }

        [Test]
        public void IsPaymentMade_When50Cents_ExpectTrue()
        {
            _paymentDAO.Setup(d => d.Retrieve()).Returns(50);

            var actual = _paymentProcessor.IsPaymentMade();

            Assert.That(actual, Is.True);
        }

        [Test]
        public void IsPaymentMade_WhenGreaterThan50Cents_ExpectTrue()
        {
            _paymentDAO.Setup(d => d.Retrieve()).Returns(75);

            var actual = _paymentProcessor.IsPaymentMade();

            Assert.That(actual, Is.True);
        }

        [Test]
        public void ProcessPayment_WhenPaymentMade_ExpectSavedToDB()
        {
            _paymentDAO.Setup(d => d.Save(It.IsAny<int>())).Verifiable();

            _paymentProcessor.ProcessPayment(25);

            _paymentDAO.Verify(d => d.Save(25), Times.Once);
        }

        [Test]
        public void ProcessPurchase_WhenPurchaseMade_ExpectSavedToDB()
        {
            _paymentProcessor.ProcessPurchase();

            _paymentDAO.Verify(d => d.Save(-50), Times.Once);
        }

        [Test]
        public void ClearPayment_WhenPaymentHasBeenMade_TellsDaoToClearPayment()
        {
            _paymentDAO.Setup(x => x.Retrieve()).Returns(25);

            _paymentProcessor.ClearPayments();
            
            _paymentDAO.Verify(x=>x.Save(0), Times.Once);
        }

        [Test]
        public void ClearPayment_WhenPaymentHasNotBeenMade_DoesNotTellDaoToClearPayment()
        {
            _paymentDAO.Setup(x => x.Retrieve()).Returns(0);

            _paymentProcessor.ClearPayments();

            _paymentDAO.Verify(x => x.Save(0), Times.Never);
        }
    }
}
