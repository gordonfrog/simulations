namespace Kaizenko.Vending.DAL
{
    public class FakePaymentDAO : IPaymentDAO
    {
        private int _balance;

        public void Save(int amount)
        {
            _balance += amount;
        }
       

        public int Retrieve()
        {
            return _balance;
        }
    }
}
