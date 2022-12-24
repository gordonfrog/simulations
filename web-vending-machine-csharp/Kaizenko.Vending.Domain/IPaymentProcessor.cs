namespace Kaizenko.Vending.Domain
{
    public interface IPaymentProcessor
    {
        int Payment { get; }
        bool IsPaymentMade();
        void ProcessPayment(int amount);        
        void ClearPayments();
        void ProcessPurchase();
    }
}