using Kaizenko.Vending.DAL;
using Kaizenko.Vending.Domain;
using Kaizenko.Vending.Machine;
using NUnit.Framework;
using System.Transactions;

namespace Tests.Integration.Kaizenko.Vending.Machine
{
    public class ADOPaymentDAOTests
    {
        private ADOPaymentDAO _paymentDAO ;
        private TransactionScope _transactionScope;

        [OneTimeSetUp]
        public void FixtureSetup() 
        {
     
        }

        [SetUp]
        public void Setup()
        {
            _paymentDAO = new ADOPaymentDAO();
            _transactionScope = new TransactionScope();          
        }

        [TearDown]
        public void Teardown()
        {
            _transactionScope.Dispose(); //toggle on and off to demo rollback
        }

        [Test]
        public void Save_WhenCalledWith50_ExpectUpdatedDatabaseWith50()
        {
            var currentValue = _paymentDAO.Retrieve();
            Assert.That(currentValue, Is.EqualTo(0)); //demo to show that state was rolled back
            _paymentDAO.Save(50);
            var updatedValue = _paymentDAO.Retrieve();
            Assert.That(updatedValue, Is.EqualTo(currentValue + 50));
        }

        [Test]
        public void Save_WhenCalledWith25_Expect25InDB()
        {
            var currentValue = _paymentDAO.Retrieve();
            Assert.That(currentValue, Is.EqualTo(0)); //demo to show that state was rolled back
            _paymentDAO.Save(25);
            var updatedValue = _paymentDAO.Retrieve();
            Assert.That(updatedValue, Is.EqualTo(25));
        }

    }
}
