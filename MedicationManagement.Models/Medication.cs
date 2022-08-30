using System.ComponentModel.DataAnnotations;

namespace MedicationManagement.Models
{
    public class Medication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1,Int32.MaxValue)]
        public int Quantity { get; set; }

        public DateTime CreationDate { get; set; }

    }
}