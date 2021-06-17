using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractingApp.Models
{
    public class MockupData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new ApplicationContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>()))
            {
                //if data already exists
                if (context.Contractors.Any())
                {
                    return;
                }
                context.Contractors.AddRangeAsync(
                    new Contractor
                    {
                        Id = 1,
                        Name = "Billy Jones",
                        ContractorAddress = new Address()
                        {
                            Id = 1,
                            StreetName = "Billy Road",
                            StreetNumber = 18,
                            Suite="12",
                            City = "Metropolis",
                            Province="Ontario",
                            Country="Canada",

                            PostalCode="M1M1M1",
                            ContractorId = 1
                        },
                        HealthStatus = HealthStatus.Green,
                        PhoneNumber = "9089010908",
                        Type = ContractorType.Advisor
                    },
                     new Contractor
                     {
                         Id = 2,
                         Name = "Jane Doe",
                         ContractorAddress = new Address()
                         {
                             Id = 2,
                             StreetName = "Jane Street",
                             StreetNumber = 12,
                             City = "Metropolis",
                             Province = "Ontario",
                             Country = "Canada",
                             PostalCode = "M1M1M1",
                             ContractorId = 2
                         },
                         HealthStatus = HealthStatus.Green,
                         PhoneNumber = "9089010907",
                         Type = ContractorType.Advisor
                     },
                     new Contractor
                     {
                         Id = 3,
                         Name = "Alice Wayne",
                         ContractorAddress = new Address()
                         {
                             Id = 3,
                             StreetName = "Alice Street",
                             StreetNumber = 12,
                             City = "Metropolis",
                             Province = "Ontario",
                             Country = "Canada",
                             PostalCode = "M1M1M1",
                             ContractorId = 3
                         },
                         HealthStatus = HealthStatus.Green,
                         PhoneNumber = "9089010906",
                         Type = ContractorType.Advisor
                     },
                     new Contractor
                     {
                         Id = 4,
                         Name = "Clark Kent",
                         ContractorAddress = new Address()
                         {
                             Id = 4,
                             StreetName = "Clark Street",
                             StreetNumber = 12,
                             City = "Metropolis",
                             Province = "Ontario",
                             Country = "Canada",
                             PostalCode = "M1M1M1",
                             ContractorId = 4
                         },
                         HealthStatus = HealthStatus.Yellow,
                         PhoneNumber = "9089010905",
                         Type = ContractorType.Advisor
                     }, new Contractor
                     {
                         Id = 5,
                         Name = "Lois Lane",
                         ContractorAddress = new Address()
                         {
                             Id = 5,
                             StreetName = "Lois Street",
                             StreetNumber = 12,
                             City = "Metropolis",
                             Province = "Ontario",
                             Country = "Canada",
                             PostalCode = "M1M1M1",
                             ContractorId = 5
                         },
                         HealthStatus = HealthStatus.Red,
                         PhoneNumber = "9089010904",
                         Type = ContractorType.Carrier
                     },
                     new Contractor
                     {
                         Id = 6,
                         Name = "Oliver Queen",
                         ContractorAddress = new Address()
                         {
                             Id = 6,
                             StreetName = "Oliver Street",
                             StreetNumber = 12,
                             City = "Metropolis",
                             Province = "Ontario",
                             Country = "Canada",
                             PostalCode = "M1M1M1",
                             ContractorId = 6
                         },
                         HealthStatus = HealthStatus.Green,
                         PhoneNumber = "9089010902",
                         Type = ContractorType.MGA
                     },
                     new Contractor
                     {
                         Id = 7,
                         Name = "Mona Payne",
                         ContractorAddress = new Address()
                         {
                             Id = 7,
                             StreetName = "Mona Street",
                             StreetNumber = 12,
                             City = "Metropolis",
                             Province = "Ontario",
                             Country = "Canada",
                             PostalCode = "M1M1M1",
                             ContractorId = 7
                         },
                         HealthStatus = HealthStatus.Yellow,
                         PhoneNumber = "9089110902",
                         Type = ContractorType.MGA
                     },
                     new Contractor
                     {
                         Id = 8,
                         Name = "Sam Fisher",
                         ContractorAddress = new Address()
                         {
                             Id = 8,
                             StreetName = "Sam Street",
                             StreetNumber = 12,
                             City = "Metropolis",
                             Province = "Ontario",
                             Country = "Canada",
                             PostalCode = "M1M1M1",
                             ContractorId = 8
                         },
                         HealthStatus = HealthStatus.Yellow,
                         PhoneNumber = "9089010502",
                         Type = ContractorType.MGA
                     },
                     new Contractor
                     {
                         Id = 9,
                         Name = "Anthony NG",
                         ContractorAddress = new Address()
                         {
                             Id = 9,
                             StreetName = "Hail Street",
                             StreetNumber = 12,
                             City = "Metropolis",
                             Province = "Ontario",
                             Country = "Canada",
                             PostalCode = "M1M1M1",
                             ContractorId = 9
                         },
                         HealthStatus = HealthStatus.Yellow,
                         PhoneNumber = "9089010502",
                         Type = ContractorType.MGA
                     });
                context.ContractorRelations.AddRangeAsync(
                    new ContractorRelations
                    {
                        Contractor1Id = 1,
                        Contractor2Id = 2,
                        Id = 1
                    },
                     new ContractorRelations
                     {
                         Contractor1Id = 2,
                         Contractor2Id = 3,
                         Id = 2
                     },
                      new ContractorRelations
                      {
                          Contractor1Id = 1,
                          Contractor2Id = 4,
                          Id = 3
                      },
                      new ContractorRelations
                      {
                          Contractor1Id = 4,
                          Contractor2Id = 5,
                          Id = 4
                      },
                        new ContractorRelations
                        {
                            Contractor1Id = 5,
                            Contractor2Id = 6,
                            Id = 5
                        },
                         new ContractorRelations
                         {
                             Contractor1Id = 7,
                             Contractor2Id = 6,
                             Id = 6
                         },
                         new ContractorRelations
                         {
                             Contractor1Id = 7,
                             Contractor2Id = 4,
                             Id = 7
                         },
                         new ContractorRelations
                         {
                             Contractor1Id = 7,
                             Contractor2Id = 8,
                             Id = 8
                         },
                         new ContractorRelations
                         {
                             Contractor1Id = 5,
                             Contractor2Id = 8,
                             Id = 9
                         });
                context.SaveChanges();
            }
        }
    }
}
