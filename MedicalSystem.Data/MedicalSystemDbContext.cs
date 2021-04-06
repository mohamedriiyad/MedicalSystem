using System;
using System.Collections.Generic;
using System.Text;
using MedicalSystem.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicalSystem.Infra.Data
{
    public class MedicalSystemDbContext : IdentityDbContext
    {
        public MedicalSystemDbContext(DbContextOptions options)
            :base(options)
        {
            
        }
        public DbSet<User> Patients { get; set; }
        public DbSet<MedicalHistory> MedicalHistory { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Sensitivity> Sensitivities { get; set; }
    }
}
