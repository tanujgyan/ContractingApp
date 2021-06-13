using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractingApp.Models
{
    public class Address
    {
        public int Id { get; set; }
        [ForeignKey("Contractor")]
        public int ContractorId { get; set; }
        [Display(Name ="Street Name")]
        [Required]
        public string StreetName { get; set; }
        [Display(Name = "Street Number")]
        [Required]
        public long StreetNumber { get; set; }
        [Display(Name = "Suite/Apt/Unit")]
        public string Suite { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Contractor Contractor { get; set; }
    }
}