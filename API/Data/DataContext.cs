using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }

        public DbSet<AppReason> Reason { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>().HasData(
                new AppUser { Id = 1, FirstName = "Robbert",  LastName="Smith", ImageUrl= @"https://upload.wikimedia.org/wikipedia/commons/thumb/2/26/Robert_Smith_%28musician%29_crop.jpg/1200px-Robert_Smith_%28musician%29_crop.jpg", JoinDate = DateTime.Now.AddYears(-2) },
                new AppUser { Id = 2, FirstName = "Sally", LastName = "Field", ImageUrl = @"https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Sally_Field_%2811205%29_%28cropped%29.jpg/1200px-Sally_Field_%2811205%29_%28cropped%29.jpg", JoinDate = DateTime.Now.AddYears(-1) },
                new AppUser { Id = 3, FirstName = "Peter", LastName = "Gaberial", ImageUrl = @"https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/Peter_Gabriel_%283%29_%28cropped%29.jpg/1200px-Peter_Gabriel_%283%29_%28cropped%29.jpg", JoinDate = DateTime.Now.AddMonths(-2) },
                new AppUser { Id = 4, FirstName = "Genny", LastName = "Weasley", ImageUrl = @"https://upload.wikimedia.org/wikipedia/en/e/e7/Ginny_Weasley_poster.jpg", JoinDate = DateTime.Now.AddMonths(-15) }
                );

            builder.Entity<AppReason>().HasData(
                new AppReason { Id = 1, CreatedBy = 1, DateTime = DateTime.Now, ReasonTitle = "Easy Commute", ReasonDescription = "Having a better commute will really help with my gas costs and ware and tear on my car.", SortOrder = 2 },
                new AppReason { Id = 2, CreatedBy = 2, DateTime = DateTime.Now, ReasonTitle = "Stable company", ReasonDescription = "Working with a good stable company will be a nice change from the companies and contracts I've been envolved with in the past", SortOrder = 0 },
                new AppReason { Id = 3, CreatedBy = 4, DateTime = DateTime.Now, ReasonTitle = "Good Benifits", ReasonDescription = "The older I get the more important benifits matter to me.", SortOrder = 1 }
                );
        }
    }
}