namespace Kaizenko.Vending.DAL
{
    public interface IPaymentDAO
    {
        int Retrieve();
        void Save(int amount);
        
       
    }
}