using ContractingApp.Models;
using ContractingApp.Repository.Contracts;
using ContractingApp.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractingApp.Repository.Implementation
{
    public class ContractorRepository : IContractorRepository
    {
        private readonly ApplicationContext applicationContext;

        public ContractorRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public int AddContractor(Contractor contractor)
        {
            applicationContext.Contractors.Add(contractor);
            return applicationContext.SaveChanges();
        }

        public int AddNewContractRelation(int contractor1Id, int contractor2Id)
        {
            applicationContext.ContractorRelations.Add(new ContractorRelations()
            {
                Contractor1Id = contractor1Id,
                Contractor2Id = contractor2Id
            });
            return applicationContext.SaveChanges();
        }

        public async Task<IEnumerable<Contractor>> AddNewContractRelation()
        {
            return await GetContractors();
        }

        public async Task<Contractor> GetContractorDetails(int contractorId)
        {
            var contractors = await applicationContext.Contractors.
                 Include(a => a.ContractorAddress)
                .FirstOrDefaultAsync(a => a.Id == contractorId && a.IsDeleted == false);
            return contractors;
        }

        public async Task<IEnumerable<Contractor>> GetContractors()
        {
            //var c = applicationContext.Contractors.ToList();
            var contractors = await applicationContext.Contractors.
                 Include(a => a.ContractorAddress)
                .Where(a => a.IsDeleted == false)
                .ToListAsync();
            return contractors;
        }

        public List<int> GetRelatedContractors(int contractorId)
        {
            List<int> relatedContractorIds = new List<int>();
            var ids = applicationContext.ContractorRelations.Where(x => (x.Contractor1Id == contractorId || x.Contractor2Id == contractorId) && x.IsDeleted==false ).ToList();
            foreach (var id in ids)
            {
                relatedContractorIds.Add(id.Contractor1Id != contractorId ? id.Contractor1Id : id.Contractor2Id);
            }
            return relatedContractorIds;
        }

        public bool IsContractorAlreadyRelated(int contractor1Id, int contractor2Id)
        {
            var result = applicationContext.ContractorRelations.FirstOrDefault(c => (c.Contractor1Id == contractor1Id && c.Contractor2Id == contractor2Id && c.IsDeleted == false) || (c.Contractor1Id == contractor2Id && c.Contractor2Id == contractor1Id && c.IsDeleted == false));
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public int TerminateContractorRelation(int contractor1Id, int contractor2Id)
        {
            var contractorRelation=  applicationContext.ContractorRelations.FirstOrDefault(x => (x.Contractor1Id == contractor1Id && x.Contractor2Id == contractor2Id) || (x.Contractor1Id == contractor2Id && x.Contractor2Id == contractor1Id));
            contractorRelation.IsDeleted = true;
            return applicationContext.SaveChanges();
        }
    }
}
