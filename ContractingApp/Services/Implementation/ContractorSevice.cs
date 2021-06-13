using ContractingApp.Models;
using ContractingApp.Repository.Contracts;
using ContractingApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractingApp.Services.Implementation
{
    public class ContractorSevice : IContractorService
    {
        private readonly IContractorRepository contractorRepository;

        public ContractorSevice(IContractorRepository contractorRepository)
        {
            this.contractorRepository = contractorRepository;
        }

        public int AddContractor(Contractor contractor)
        {
           contractor.HealthStatus = SelectHealthStatus();
           return contractorRepository.AddContractor(contractor);
        }

        public int AddNewContractRelation( int contractor1Id, int contractor2Id)
        {
            return contractorRepository.AddNewContractRelation(contractor1Id, contractor2Id);
        }

        public Task<IEnumerable<Contractor>> AddNewContractRelation()
        {
           return contractorRepository.AddNewContractRelation();
        }

        public Task<Contractor> GetContractorDetails(int contractorId)
        {
            return contractorRepository.GetContractorDetails(contractorId);
        }

        public Task<IEnumerable<Contractor>> GetContractors()
        {
            return contractorRepository.GetContractors();
        }

        public List<int> GetRelatedContractors(int contractorId)
        {
           return contractorRepository.GetRelatedContractors(contractorId);
        }

        public bool IsContractorAlreadyRelated(int contractor1Id, int contractor2Id)
        {
            return contractorRepository.IsContractorAlreadyRelated(contractor1Id, contractor2Id);
        }

        public int TerminateContractorRelation(int contractor1Id, int contractor2Id)
        {
           return contractorRepository.TerminateContractorRelation(contractor1Id, contractor2Id);
        }
        private HealthStatus SelectHealthStatus()
        {
            var rand = new Random();
            List<HealthStatus> list = new List<HealthStatus>() {HealthStatus.Green,
                HealthStatus.Green , HealthStatus.Green ,
                HealthStatus.Green , HealthStatus.Green , HealthStatus.Green,
                HealthStatus.Red,HealthStatus.Red,HealthStatus.Yellow,HealthStatus.Yellow};
            var s = list[rand.Next(list.Count)];
            return s;
        }
    }
}
