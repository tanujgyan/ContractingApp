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
                         Name = "Jone Doe",
                         ContractorAddress = new Address()
                         {
                             Id = 3,
                             StreetName = "Jone Street",
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
                     });
                context.SaveChanges();
            }
        }
    }
}
