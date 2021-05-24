using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UX.Models
{
    public class AppReasonModel
    {
        public int Id { get; set; }
        public string ReasonTitle { get; set; }
        public string ReasonDescription { get; set; }
        public int SortOrder { get; set; }
        public DateTime DateTime { get; set; }
        public int CreatedBy { get; set; }
    }
}
