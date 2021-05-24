using DomainObjects.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainObjects.Entities
{
    public class AppReason : EntityBase
    {
        public int Id { get; set; }

        public string ReasonTitle { get; set; }

        public string ReasonDescription { get; set; }

        public int SortOrder { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime DateTime { get; set; }

        public int CreatedBy { get; set; }
    }
}
