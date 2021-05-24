using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UX.Models;
using UX.ViewModels;
using Microsoft.Extensions.Configuration;

namespace UX.Controllers
{
    public class ReasonsController : Controller
    {
        #region class variables
        private readonly ILogger<ReasonsController> _logger;
        private IConfiguration _config;
        private string _apiAddy;
        #endregion

        #region constructors
        public ReasonsController(ILogger<ReasonsController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;

            _apiAddy = _config["ApiUri"];
        }
        #endregion

        #region endpoints
        public async Task<IActionResult> Index()
        {
            var userReasonsViewModel = new UserReasonsViewModel();
            var reasons = new List<AppReasonModel>();
            var users = new List<AppUserModel>();
            using (var httpClient = new HttpClient())
            {
                using (var reasonsResponse = await httpClient.GetAsync(string.Format("{0}Reasons/GetReasons", _apiAddy)))
                {
                    string reasonsData = await reasonsResponse.Content.ReadAsStringAsync();
                    reasons = JsonConvert.DeserializeObject<List<AppReasonModel>>(reasonsData);
                }

                using (var usersResponse = await httpClient.GetAsync(string.Format("{0}Users/GetUsers", _apiAddy)))
                {
                    string usersData = await usersResponse.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<AppUserModel>>(usersData);
                }
            }

            foreach (var reason in reasons)
            {
                var reasonsWithUsers = new ReasonWithUser();
                reasonsWithUsers.appReasonModel = reason;
                reasonsWithUsers.appUserModel = users.Find(x=>x.Id == reason.CreatedBy);

                userReasonsViewModel.UserReasonsViewModels.Add(reasonsWithUsers);
            }

            return View(userReasonsViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion
    }
}
