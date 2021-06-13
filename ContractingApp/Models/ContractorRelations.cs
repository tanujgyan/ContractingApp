using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContractingApp.Models
{
    public class ContractorRelations
    {
        public int Id { get; set; }
       
        public int Contractor1Id { get; set; }
        public int Contractor2Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        //[ForeignKey("Contractor1Id")]
        //public virtual Contractor Contractor1 { get; set; }
        //[ForeignKey("Contractor2Id")]
        //public virtual Contractor Contractor2 { get; set; }
    }
}
