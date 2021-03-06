using DomainObjects.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime JoinDate { get; set; }

    }
}
