using ContractingApp.Models;
using ContractingApp.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            try
            {
                applicationContext.Contractors.Add(contractor);
                return applicationContext.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public int AddNewContractRelation(int contractor1Id, int contractor2Id)
        {
            try
            {
                applicationContext.ContractorRelations.Add(new ContractorRelations()
                {
                    Contractor1Id = contractor1Id,
                    Contractor2Id = contractor2Id
                });
                return applicationContext.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Contractor>> AddNewContractRelation()
        {
            try
            {
                return await GetContractors();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<Contractor> GetContractorDetails(int contractorId)
        {
            try
            {
                var contractors = await applicationContext.Contractors.
                        Include(a => a.ContractorAddress)
                       .FirstOrDefaultAsync(a => a.Id == contractorId && a.IsDeleted == false);
                return contractors;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Contractor>> GetContractors()
        {

            try
            {
                var contractors = await applicationContext.Contractors.
                         Include(a => a.ContractorAddress)
                        .Where(a => a.IsDeleted == false)
                        .ToListAsync();
                return contractors;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public List<int> GetRelatedContractors(int contractorId)
        {
            try
            {
                List<int> relatedContractorIds = new List<int>();
                var ids = applicationContext.ContractorRelations.Where(x => (x.Contractor1Id == contractorId || x.Contractor2Id == contractorId) && x.IsDeleted == false).ToList();
                foreach (var id in ids)
                {
                    relatedContractorIds.Add(id.Contractor1Id != contractorId ? id.Contractor1Id : id.Contractor2Id);
                }
                return relatedContractorIds;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public string GetShortestContractingChain(int contractor1Id, int contractor2Id)
        {
            try
            {
                List<string> shortestContractingChainOfContractors = new List<string>();
                var adjacencyList = BuildAdjacencyList(contractor1Id, contractor2Id);
                var shortestChainsIds = GetShortestContractingChainHelper(contractor1Id, contractor2Id, adjacencyList);
                if (shortestChainsIds.Count > 0)
                {
                    shortestContractingChainOfContractors = GetNameFromIds(shortestChainsIds);
                    StringBuilder sb = new StringBuilder();
                    foreach (var s in shortestContractingChainOfContractors)
                    {
                        sb.Append(s);
                        sb.Append("->");
                    }
                    sb.Remove(sb.Length - 2, 2);
                    return sb.ToString();
                }
                else
                {
                    return "No relations found";
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool IsContractorAlreadyRelated(int contractor1Id, int contractor2Id)
        {
            try
            {
                var result = applicationContext.ContractorRelations.FirstOrDefault(c => (c.Contractor1Id == contractor1Id && c.Contractor2Id == contractor2Id && c.IsDeleted == false) || (c.Contractor1Id == contractor2Id && c.Contractor2Id == contractor1Id && c.IsDeleted == false));
                if (result == null)
                {
                    return false;
                }
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public int TerminateContractorRelation(int contractor1Id, int contractor2Id)
        {
            try
            {
                var contractorRelation = applicationContext.ContractorRelations.FirstOrDefault(x => (x.Contractor1Id == contractor1Id && x.Contractor2Id == contractor2Id) || (x.Contractor1Id == contractor2Id && x.Contractor2Id == contractor1Id));
                contractorRelation.IsDeleted = true;
                return applicationContext.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// This is the first step of BFS to build the adjacency list
        /// This is used to represent graph on which BFS will run
        /// </summary>
        /// <param name="contractor1Id"></param>
        /// <param name="contractor2Id"></param>
        /// <returns></returns>
        private Dictionary<int, List<int>> BuildAdjacencyList(int contractor1Id, int contractor2Id)
        {
            try
            {
                Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
                var relationsList = applicationContext.ContractorRelations.Where(x => (x.Contractor1Id == contractor1Id || x.Contractor2Id == contractor1Id) && x.IsDeleted == false).ToList();
                var relationsList2 = applicationContext.ContractorRelations.Where(x => (x.Contractor1Id == contractor2Id || x.Contractor2Id == contractor2Id) && x.IsDeleted == false).ToList();
                foreach (var r in relationsList2)
                {
                    if (!relationsList.Contains(r))
                    {
                        relationsList.Add(r);
                    }
                }

                foreach (var relation in relationsList)
                {
                    if (adjacencyList.ContainsKey(relation.Contractor1Id))
                    {
                        adjacencyList[relation.Contractor1Id].Add(relation.Contractor2Id);
                    }
                    else
                    {
                        adjacencyList.Add(relation.Contractor1Id, new List<int>() { relation.Contractor2Id });
                    }
                    if (adjacencyList.ContainsKey(relation.Contractor2Id))
                    {
                        adjacencyList[relation.Contractor2Id].Add(relation.Contractor1Id);
                    }
                    else
                    {
                        adjacencyList.Add(relation.Contractor2Id, new List<int>() { relation.Contractor1Id });
                    }
                }
                return adjacencyList;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Here we are using BFS to find the shortest path between two nodes of the graph
        /// </summary>
        /// <param name="contractor1Id"></param>
        /// <param name="contractor2Id"></param>
        /// <param name="adjacencyList"></param>
        /// <returns></returns>
        private List<int> GetShortestContractingChainHelper(int contractor1Id, int contractor2Id, Dictionary<int, List<int>> adjacencyList)
        {

            try
            {
                List<int> path = new List<int>();
                if (adjacencyList.Count > 0)
                {
                    Queue<int> queue = new Queue<int>();
                    bool[] visited = new bool[adjacencyList.Count + 1];

                    bool flag = false;
                    List<int?> prev = new List<int?>();
                    for (int i = 0; i < adjacencyList.Count + 1; i++)
                    {
                        prev.Add(null);
                    }

                    queue.Enqueue(contractor1Id);
                    visited[contractor1Id] = true;
                    while (queue.Count > 0 && !flag)
                    {
                        int size = queue.Count;

                        for (int i = 0; i < size; i++)
                        {
                            var contractorId = queue.Dequeue();

                            foreach (var relatedContractorId in adjacencyList[contractorId])
                            {
                                if (!visited[relatedContractorId])
                                {
                                    visited[relatedContractorId] = true;
                                    queue.Enqueue(relatedContractorId);

                                    prev[relatedContractorId] = contractorId;

                                }
                            }
                            if (contractorId == contractor2Id)
                            {
                                flag = true;
                                break;
                            }
                        }

                    }
                    if (flag)
                    {
                        path = ReconstructPath(contractor1Id, contractor2Id, prev);
                    }
                }
                return path;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Once the BFS is completed this method will be called to reconstruct the path
        /// </summary>
        /// <param name="contractor1Id"></param>
        /// <param name="contractor2Id"></param>
        /// <param name="prev"></param>
        /// <returns></returns>
        private List<int> ReconstructPath(int contractor1Id,int contractor2Id,List<int?> prev)
        {
            try
            {
                List<int> path = new List<int>();
                path.Add(contractor2Id);
                int previousNode = contractor2Id;
                while (prev[previousNode] != null)
                {
                    path.Add((int)prev[previousNode]);
                    previousNode = (int)prev[previousNode];
                }
                path.Reverse();
                return path;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private List<string> GetNameFromIds(List<int> ids)
        {
            try
            {
                List<string> result = new List<string>();
                foreach (var id in ids)
                {
                    result.Add(applicationContext.Contractors.FirstOrDefault(x => x.Id == id).Name);
                }
                return result;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
