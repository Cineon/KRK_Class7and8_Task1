using System.ComponentModel.DataAnnotations.Schema;

namespace KRK_Class7_Task1.Models
{
    // Entity class (domain class) named Client
    public class Client
    {
        // Database columns
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   // Set IDENTITY to OFF
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }


        // navigation properties
        public ICollection<Order> Order { get; set; }
    }
}