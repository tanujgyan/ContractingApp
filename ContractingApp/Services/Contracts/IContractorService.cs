using ContractingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractingApp.Services.Contracts
{
    public interface IContractorService
    {
        public Task<IEnumerable<Contractor>> GetContractors();
        public int AddContractor(Contractor contractor);
        public int AddNewContractRelation( int contractor1Id, int contractor2Id);
        public Task<IEnumerable<Contractor>> AddNewContractRelation();
        bool IsContractorAlreadyRelated(int contractor1Id, int contractor2Id);
        List<int> GetRelatedContractors(int contractorId);
        int TerminateContractorRelation(int contractor1Id, int contractor2Id);
        Task<Contractor> GetContractorDetails(int contractorId);
       string GetShortestContractingChain(int contractor1Id, int contractor2Id);
    }
}
