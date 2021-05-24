using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UX.Models
{
    /// <summary>
    /// this uses the domain objects as a base to ensure changes are 
    /// propagated to where needed, while allowing for modification 
    /// if needed for this specific application.
    /// </summary>
    public class AppUserModel:DomainObjects.Entities.AppUser
    {
    }
}
