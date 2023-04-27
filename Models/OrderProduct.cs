using System.ComponentModel.DataAnnotations.Schema;

namespace KRK_Class7_Task1.Models
{
    // Entity class (domain class) named OrderProduct
    public class OrderProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   // Set IDENTITY to OFF
        public int OrderProductID { get; set; }
        public int Count { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }


        // navigation properties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
