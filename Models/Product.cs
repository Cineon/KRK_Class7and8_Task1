using System.ComponentModel.DataAnnotations.Schema;

namespace KRK_Class7_Task1.Models
{
    // Entity class (domain class) named Product
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   // Set IDENTITY to OFF
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int? CategoryID { get; set; } // W tym wypadku chcę, aby FK buł nullable

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }


        // navigation properties
        public Category Category { get; set; }
        public ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
