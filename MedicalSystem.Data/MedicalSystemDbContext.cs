using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
