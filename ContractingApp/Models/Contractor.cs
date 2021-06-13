using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContractingApp.Models
{
    public class Contractor
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
      
        [ForeignKey("ContractorId")]
        public virtual Address ContractorAddress { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number can be digits only of length 10")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public ContractorType Type { get; set; }
        [Display(Name = "Health Status")]
        public HealthStatus HealthStatus { get; set; }
        public bool IsDeleted { get; set; } = false;
       // public ContractorRelations ContractorRelations { get; set; }

        //[InverseProperty("Contractor1")]
        //public virtual ContractorRelations Contractor1Relations { get; set; }
        //[InverseProperty("Contractor2")]
        //public virtual ContractorRelations Contractor2Relations { get; set; }

    }
    public enum ContractorType
    {
        [Display(Name ="Carrier")]
        Carrier,
        [Display(Name = "MGA")]
        MGA,
        [Display(Name = "Advisor")]
        Advisor
    }
    public enum HealthStatus
    {
        [Display(Name = "Green")]
        Green,
        [Display(Name = "Red")]
        Red,
        [Display(Name = "Yellow")]
        Yellow
    }
}
