using System.Linq;

namespace Kaizenko.Vending.DAL
{
    public class EFPaymentDAO : IPaymentDAO
    {
        private readonly VendingMachineContext _context = new VendingMachineContext();

        public int Retrieve()
        {
            var payment = _context.Payments.FirstOrDefault(p => p.Id == 1);

            if (payment != null)
            {
                return payment.Value;
            }

            return 0;
        }

        public void Save(int amount)
        {
            var payment = _context.Payments.FirstOrDefault(p => p.Id == 1);

            if (payment != null)
            {
                payment.Value = amount;
                _context.SaveChanges();
            }
        }        

       
    }
}
