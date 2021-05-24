using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UX.Models;

namespace UX.ViewModels
{
    public class UserReasonsViewModel
    {
        private List<ReasonWithUser> _userReasonsViewModels;

        public List<ReasonWithUser> UserReasonsViewModels
        {
            get
            {
                if (_userReasonsViewModels == null)
                {
                    _userReasonsViewModels = new List<ReasonWithUser>();
                }

                return _userReasonsViewModels;
            }
            set 
            { 
                _userReasonsViewModels = value; 
            }
        }
        
    }
}
