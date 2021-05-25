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
using UX.ViewModels;

namespace UX.Repository
{
    public class ReasonRepository:IReasonRepository
    {
        #region class variables
        private readonly ILogger<ReasonsController> _logger;
        private IConfiguration _config;
        private string _apiAddy;
        private IUserRepository _userRepository;

        #endregion

        #region constructors
        public ReasonRepository(ILogger<ReasonsController> logger, IConfiguration config, IUserRepository userRep)
        {
            _logger = logger;
            _config = config;
            _userRepository = userRep;

            _apiAddy = _config["ApiUri"];
        }
        #endregion

        #region public functions
        /// <summary>
        /// function to get each reason with the user that created it. 
        /// </summary>
        /// <returns></returns>
        public async Task<UserReasonsViewModel> GetReasonsWithUser()
        {
            var userReasonsViewModel = new UserReasonsViewModel();
            var reasons = await GetAllReasons();
            var users = await _userRepository.GetAllUsers();

            foreach (var reason in reasons)
            {
                var reasonsWithUsers = new ReasonWithUser();
                reasonsWithUsers.appReasonModel = reason;
                reasonsWithUsers.appUserModel = users.Find(x => x.Id == reason.CreatedBy);

                userReasonsViewModel.UserReasonsViewModels.Add(reasonsWithUsers);
            }

            return userReasonsViewModel;
        }

        public async Task<List<AppReasonModel>> GetAllReasons()
        {
            var reasons = new List<AppReasonModel>();

            using (var httpClient = new HttpClient())
            {
                using (var reasonsResponse = await httpClient.GetAsync(string.Format("{0}Reasons/GetReasons", _apiAddy)))
                {
                    string reasonsData = await reasonsResponse.Content.ReadAsStringAsync();
                    reasons = JsonConvert.DeserializeObject<List<AppReasonModel>>(reasonsData);
                }               
            }

            return reasons;
        }

        /// <summary>
        /// added this for the jQuersy example
        /// 
        /// gets all reasons and returns them as a json string
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAllReasonsJson()
        {
            string reasonsData;

            using (var httpClient = new HttpClient())
            {
                using (var reasonsResponse = await httpClient.GetAsync(string.Format("{0}Reasons/GetReasons", _apiAddy)))
                {
                    reasonsData = await reasonsResponse.Content.ReadAsStringAsync();                    
                }
            }

            return reasonsData;
        }

        public async Task<AppReasonModel> GetReason(int id)
        {
            var reasons = new AppReasonModel();

            using (var httpClient = new HttpClient())
            {
                using (var reasonsResponse = await httpClient.GetAsync(string.Format("{0}Reasons/GetReason/{1}", _apiAddy, id)))
                {
                    string reasonsData = await reasonsResponse.Content.ReadAsStringAsync();
                    reasons = JsonConvert.DeserializeObject<AppReasonModel>(reasonsData);
                }
            }

            return reasons;
        }

        public async Task<AppReasonModel> Create(AppReasonModel appReasonModel)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync(string.Format("{0}Reason/Create", _apiAddy), appReasonModel))
                {
                    response.EnsureSuccessStatusCode();
                }
            }

            return appReasonModel;
        }

        public async Task DeleteReason(int id)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                var responseMessage = await client.DeleteAsync(string.Format("{0}Reason/Delete/{1}", _apiAddy, id));
            }
        }

        public async Task<AppReasonModel> EditReason(AppReasonModel appReason)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync(string.Format("{0}Reason/Edit", _apiAddy), appReason))
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(String.Format("Error on reason edit. Error: {0}", ex.Message));
            }

            return appReason;
        }
        #endregion
    }
}
