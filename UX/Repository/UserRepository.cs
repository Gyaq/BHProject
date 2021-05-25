using DomainObjects.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UX.Controllers;
using UX.Models;

namespace UX.Repository
{
    public class UserRepository:IUserRepository
    {
        #region class variables
        private readonly ILogger<ReasonsController> _logger;
        private IConfiguration _config;
        private string _apiAddy;
        #endregion

        #region constructors
        public UserRepository(ILogger<ReasonsController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _apiAddy = _config["ApiUri"];
        }
        #endregion

        #region public functions
        // GET: AppUsers
        public async Task<AppUserModel> CreateUser(AppUserModel appUser)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync(string.Format("{0}Users/Create", _apiAddy), appUser))
                {
                    response.EnsureSuccessStatusCode();
                }
            }

            return appUser;
        }

        /// <summary>
        /// function that sends the updated/edited user to the api to persist to the database.
        /// </summary>
        /// <param name="appUser"></param>
        /// <returns></returns>
        public async Task<AppUserModel> EditUser(AppUserModel appUser)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync(string.Format("{0}Users/Edit", _apiAddy), appUser))
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(String.Format("Error on reason edit. Error: {0}", ex.Message));
            }

            return appUser;
        }      

        public async Task DeleteUser(int id)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                var responseMessage = await client.DeleteAsync(string.Format("{0}Users/Delete/{1}", _apiAddy, id));
            }
        }

       
        public async Task<List<AppUserModel>> GetAllUsers()
        {
            List<AppUserModel> users = new List<AppUserModel>();
            using (var httpClient = new HttpClient())
            {
                using (var usersResponse = await httpClient.GetAsync(string.Format("{0}Users/GetUsers", _apiAddy)))
                {
                    string usersData = await usersResponse.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<AppUserModel>>(usersData);
                }
            }

            return users;
        }

        public async Task<string> GetAllUsersJson()
        {
            string usersData;
            using (var httpClient = new HttpClient())
            {
                using (var usersResponse = await httpClient.GetAsync(string.Format("{0}Users/GetUsers", _apiAddy)))
                {
                     usersData = await usersResponse.Content.ReadAsStringAsync();
                }
            }

            return usersData;
        }

        public async Task<AppUserModel> GetUser(int? id)
        {
            AppUserModel user = new AppUserModel();

            using (var httpClient = new HttpClient())
            {
                using (var usersResponse = await httpClient.GetAsync(string.Format("{0}Users/GetUser/{1}", _apiAddy, id)))
                {
                    string usersData = await usersResponse.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<AppUserModel>(usersData);
                }
            }

            return user;
        }
        #endregion
    }
}
