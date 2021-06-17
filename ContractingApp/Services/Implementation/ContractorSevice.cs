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
            try
            {
                this.contractorRepository = contractorRepository;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AddContractor(Contractor contractor)
        {
            try
            {
                contractor.HealthStatus = SelectHealthStatus();
                return contractorRepository.AddContractor(contractor);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AddNewContractRelation(int contractor1Id, int contractor2Id)
        {
            try
            {
                return contractorRepository.AddNewContractRelation(contractor1Id, contractor2Id);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Task<IEnumerable<Contractor>> AddNewContractRelation()
        {
            try
            {
                return contractorRepository.AddNewContractRelation();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Contractor> GetContractorDetails(int contractorId)
        {
            try
            {
                return contractorRepository.GetContractorDetails(contractorId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<IEnumerable<Contractor>> GetContractors()
        {
            try
            {
                return contractorRepository.GetContractors();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<int> GetRelatedContractors(int contractorId)
        {
            try
            {
                return contractorRepository.GetRelatedContractors(contractorId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetShortestContractingChain(int contractor1Id, int contractor2Id)
        {
            try
            {
                return contractorRepository.GetShortestContractingChain(contractor1Id, contractor2Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsContractorAlreadyRelated(int contractor1Id, int contractor2Id)
        {
            try
            {
                return contractorRepository.IsContractorAlreadyRelated(contractor1Id, contractor2Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int TerminateContractorRelation(int contractor1Id, int contractor2Id)
        {
            try
            {
                return contractorRepository.TerminateContractorRelation(contractor1Id, contractor2Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private HealthStatus SelectHealthStatus()
        {
            try
            {
                var rand = new Random();
                List<HealthStatus> list = new List<HealthStatus>() {HealthStatus.Green,
                HealthStatus.Green , HealthStatus.Green ,
                HealthStatus.Green , HealthStatus.Green , HealthStatus.Green,
                HealthStatus.Red,HealthStatus.Red,HealthStatus.Yellow,HealthStatus.Yellow};
                var s = list[rand.Next(list.Count)];
                return s;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
