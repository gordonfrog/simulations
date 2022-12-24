using Kaizenko.Vending.DAL;
using Kaizenko.Vending.Domain;
using Kaizenko.Vending.Machine;
using Kaizenko.Vending.Web.UI.Controllers;
using NUnit.Framework;
using System.Transactions;
using Kaizenko.Vending.Web.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Integration.Kaizenko.Vending.Web.UI
{
    public class VendingMachineControllerUsingEFTests
    {
        private TransactionScope _transactionScope;
        private VendingMachineController _controller;
        private IPaymentDAO _paymentDao = new EFPaymentDAO();

        [OneTimeSetUp]
        public void FixtureSetup()
        {
      //      _paymentDao.ClearPayments();
        }

        [SetUp]
        public void Setup()
        {
            _transactionScope = new TransactionScope();
            _paymentDao = new EFPaymentDAO();
            var paymentProcessor = new CoinPaymentProcessor(_paymentDao);
            var vendingMachine = new VendingMachine(paymentProcessor);
            _controller = new VendingMachineController(vendingMachine);
        }

        [TearDown]
        public void Teardown()
        {
            _transactionScope.Dispose();
        }

        [Test]
        public void Index_WhenFirstLoad_ExpectNoBalance()
        {
            _controller.Index();

            var vm = _controller.ViewData.Model as VendingMachineViewModel;
            Assert.That(vm.Balance, Is.EqualTo(0));
        }

        [Test]
        public void InsertCoin_WhenCalledOnce_Expect25Balance()
        {
            _controller.InsertCoin();
            _controller.Index();

            var result = _controller.ViewData.Model as VendingMachineViewModel;
            var balance = result.Balance;

            Assert.That(balance, Is.EqualTo(25));
        }

        [Test]
        public void ReleaseChange_WithMoneyEntered_ReturnsChange()
        {
            _controller.InsertCoin();

            var result = _controller.ReleaseChange() as RedirectToActionResult;

            var releasedChange = result.RouteValues["ReleasedChange"];

            Assert.That(releasedChange, Is.EqualTo(25));
        }

        [Test]
        public void ReleaseChange_WithMoneyEntered_SetsBalanceToZero()
        {
            _controller.InsertCoin();

            _controller.ReleaseChange();

            _controller.Index();
            var vm = _controller.ViewData.Model as VendingMachineViewModel;
            var balance = vm.Balance;

            Assert.That(balance, Is.EqualTo(0));
        }
    }
}
