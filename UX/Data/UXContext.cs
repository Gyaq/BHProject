using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DomainObjects.Entities;

namespace UX.Data
{
    public class UXContext : DbContext
    {
        public UXContext (DbContextOptions<UXContext> options)
            : base(options)
        {
        }

        public DbSet<DomainObjects.Entities.AppUser> AppUser { get; set; }
    }
}
