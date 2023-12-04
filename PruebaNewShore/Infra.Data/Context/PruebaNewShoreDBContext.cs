using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.Data.Context
{
    public class PruebaNewShoreDBContext : DbContext
    {
        public PruebaNewShoreDBContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Fligth> Fligth { get; set; }
        public DbSet<Journey> Journey { get; set; }
        public DbSet<JourneyFlight> JourneyFlight { get; set; }
        public DbSet<Transport> Transport { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Load all assemblies from configurations folder in infra.data
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

        }
    }
}
