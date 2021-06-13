using ContractingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContractingApp.ViewModel
{
    public class ContractorRelationViewModelForDelete
    {
        [Range(1, int.MaxValue,ErrorMessage = "Please select Contractor 1")]
        public int Contractor1Id{ get; set; }
        public string Contractor1Name { get; set; }
      
        public int Contractor2Id { get; set; }
        public string Contractor2Name { get; set; }
        public List<Contractor> ContractorList { get; set; }
        public List<Contractor> DependentContractorList { get; set; }
    }
}
