using ContractingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractingApp
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {

        }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContractorRelations> ContractorRelations { get; set; }
       
    }
}
