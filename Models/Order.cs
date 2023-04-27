using System.ComponentModel.DataAnnotations.Schema;

namespace KRK_Class7_Task1.Models
{
    // Entity class (domain class) named Order
    public class Order
    {
        // Database columns
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   // Set IDENTITY to OFF
        public int OrderID { get; set; }
        public DateTime Date { get; set; }
        public int ClientID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }


        // navigation properties
        public Client Client { get; set; }
        public ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
