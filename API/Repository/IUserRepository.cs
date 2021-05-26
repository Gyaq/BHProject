using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    interface IUserRepository
    {
        public Task<IEnumerable<AppUserModel>> GetUsers();

        public Task<AppUserModel> Edit(AppUserModel appUser);

        public Task<AppUserModel> Create( AppUserModel appUser);

        public Task<int> Delete(int id);
    }
}
