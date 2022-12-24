using System.ComponentModel.DataAnnotations;

namespace Kaizenko.Vending.DAL.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }
}
