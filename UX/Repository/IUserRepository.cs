using DomainObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UX.Models;

namespace UX.Repository
{
    public interface IUserRepository
    {
        public Task<AppUserModel> CreateUser(AppUserModel appUser);

        public Task<AppUserModel> EditUser(AppUserModel appUser);

        public Task DeleteUser(int id);

        public Task<List<AppUserModel>> GetAllUsers();

        public Task<string> GetAllUsersJson();

        public Task<AppUserModel> GetUser(int? id);
    }
}
