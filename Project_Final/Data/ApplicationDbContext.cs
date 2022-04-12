using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_Final.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Final.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Traveller> traveller { get; set; }
        public virtual DbSet<Flights> flights { get; set; }
        public virtual DbSet<Hotels> hotels { get; set; }
        public virtual DbSet<Spots> spots { get; set; }
        public virtual DbSet<Cities> cities { get; set; }
    }
}
