using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UX.Repository;

namespace UX.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class JsonController : Controller
    {
        #region class variables
        private readonly ILogger<JsonController> _logger;
        private readonly IUserRepository _userRep;
        IReasonRepository _reasonRepository;
        #endregion

        #region constructors
        public JsonController(ILogger<JsonController> logger, IUserRepository userRep, IReasonRepository reasonRep)
        {
            _logger = logger;
            _userRep = userRep;
            _reasonRepository = reasonRep;
        }
        #endregion

        #region endpoints
        /// <summary>
        /// added this for the jQuersy example
        /// 
        /// passes the json data to the caller from the repository
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> GetAllUsers()
        {
            var users = await _userRep.GetAllUsersJson();

            return users;
        }

        /// <summary>
        /// added this for the jQuersy example
        /// 
        /// passes the json data to the caller from the repository
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> GetAllReasons()
        {
            var reasons = await _reasonRepository.GetAllReasonsJson();

            return reasons;
        }

        /// <summary>
        /// added this for the jQuersy example
        /// 
        /// passes the json data to the caller from the repository
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> GetListData()
        {
            var reasons = await _reasonRepository.GetAllReasons();
            var users = await _userRep.GetAllUsers();

            var allData = new { reasons = reasons, users = users };

            var retVal = JsonConvert.SerializeObject(allData);

            return retVal;
        }
        #endregion
    }
}
