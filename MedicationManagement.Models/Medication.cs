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
        public uint Quantity { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

    }
}