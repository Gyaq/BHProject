using DomainObjects.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainObjects.Entities
{
    public class AppUser:EntityBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime JoinDate { get; set; }

    }
}
