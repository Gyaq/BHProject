
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainObjects.BaseClasses
{
    public class EntityBase 
    {
        [NotMapped]
        public string ErrorMessage { get; set; }
    }
}
