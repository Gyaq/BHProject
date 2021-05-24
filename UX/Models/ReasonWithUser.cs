using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UX.Models
{
    /// <summary>
    /// this is a reason with its user. 
    /// </summary>
    public class ReasonWithUser
    {
        public AppUserModel appUserModel { get; set; }
        public AppReasonModel appReasonModel { get; set; }
    }
}
