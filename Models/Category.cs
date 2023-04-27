using System.ComponentModel.DataAnnotations.Schema;

namespace KRK_Class7_Task1.Models
{
    // Entity class (domain class) named Category
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   // Set IDENTITY to OFF
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        // navigation properties
        public ICollection<Product> Product { get; set; }
    }
}
