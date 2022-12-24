using Kaizenko.Vending.DAL;

namespace Kaizenko.Vending.Domain
{
    public class CoinPaymentProcessor : IPaymentProcessor
    {
        public int Payment
        {
            get { return _paymentDAO.Retrieve(); }
        }

        private readonly IPaymentDAO _paymentDAO;

        public CoinPaymentProcessor(IPaymentDAO dao)
        {
            _paymentDAO = dao;
        }

        public void ProcessPayment(int amount)        {
            
            _paymentDAO.Save(Payment+ amount);
        }

        public bool IsPaymentMade()
        {
            return Payment >= 50;
        }       

        public void ClearPayments()
        {
            if (Payment > 0)
            {
                _paymentDAO.Save(0);
            }
        }

        public void ProcessPurchase()
        {
            _paymentDAO.Save(Payment - 50);
        }
    }
}
