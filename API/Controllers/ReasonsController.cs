using API.Data;
using API.Entities;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReasonsController : Controller
    {
        #region class variables
        private readonly ILogger<ReasonsController> _logger;
        private IReasonRepository _resonRepository;
        #endregion

        #region properties/public variables
        #endregion

        #region constructors
        public ReasonsController(ILogger<ReasonsController> logger, IReasonRepository resonRepository)
        {
            _logger = logger;
            _resonRepository = resonRepository;
    }
        #endregion

        #region endpoints
        [HttpGet]
        public async Task<IEnumerable<AppReasonModel>> GetReasons()
        {
            try
            {
                var appReasons = await _resonRepository.GetReasons();
                return appReasons;
            }
            catch (Exception ex)
            {
                var error = new AppReasonModel[] { new AppReasonModel() };
                error[0].ErrorMessage = string.Format("There was an erorr getting reasons. ErrorMessage: {0}", ex.Message);
                _logger.LogError(string.Format("There was an erorr getting reasons. ErrorMessage: {0}", ex.Message));
                return error;
            }
        }

        [HttpGet("{id}")]
        public async Task<AppReasonModel> GetReason(int id)
        {
            try
            {
                var appReason = await _resonRepository.GetReason(id);
                return appReason;
            }
            catch (Exception ex)
            {
                var error = new AppReasonModel();
                error.ErrorMessage = string.Format("There was an erorr getting reason ID:{0}. ErrorMessage: {1}", id, ex.Message);
                _logger.LogError(string.Format("There was an erorr getting reason ID:{0}. ErrorMessage: {1}", id, ex.Message));
                return error;
            }
        }

        [HttpPost]
        public async Task<AppReasonModel> Create([Bind("Id,ReasonTitle,ReasonDescription,SortOrder,DateTime,CreatedBy")] AppReasonModel appReason)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _resonRepository.Create(appReason);
                }
                catch (DbUpdateException dex)
                {
                    var error = new AppReasonModel();
                    error.ErrorMessage = string.Format("The entry way not added to the database, there was an erorr. ErrorMessage: {0}", dex.Message);
                    _logger.LogError(string.Format("The entry way not added to the database, there was an erorr. ErrorMessage: {0}", dex.Message));
                    return error;
                }
            }
            return appReason;
        }

        [HttpGet("{id}")]
        public async Task<AppReasonModel> Edit(int id)
        {
            try
            {
                var appReason = await _resonRepository.GetReason(id);
                if (appReason == null)
                {
                    var error = new AppReasonModel();
                    error.ErrorMessage = string.Format("ID: {0} not not found", id);
                    _logger.LogError(string.Format("ID: {0} not not found", id));
                    return error;
                }

                return appReason;
            }
            catch (Exception ex)
            {
                var error = new AppReasonModel();
                error.ErrorMessage = string.Format("ID: {0} not updated, there was an erorr. ErrorMessage: {1}", id, ex.Message);
                _logger.LogError(string.Format("ID: {0} not updated, there was an erorr. ErrorMessage: {1}", id, ex.Message));
                return error;
            }
        }

        [HttpPost]
        public async Task<AppReasonModel> Edit(int id, [Bind("Id,ReasonTitle,ReasonDescription,SortOrder,DateTime,CreatedBy")] AppReasonModel appReason)
        {
            if (id != appReason.Id)
            {
                appReason.ErrorMessage = string.Format("ID: {0} not found.", id);
                _logger.LogError(string.Format("ID: {0} not found.", id));
                return appReason;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _resonRepository.Edit(appReason);
                }
                catch (Exception ex)
                {
                    var error = new AppReasonModel();
                    error.ErrorMessage = string.Format("ID: {0} not updated, there was an erorr. ErrorMessage: {1}", id, ex.Message);
                    _logger.LogError(string.Format("ID: {0} not updated, there was an erorr. ErrorMessage: {1}", id, ex.Message));
                    return error;
                }

            }
            return appReason;
        }

        [HttpPost("{id}"), ActionName("Delete")]
        public async Task<int> DeleteReason(int id)
        {
            return await _resonRepository.DeleteReason(id);
        }

        #endregion

        #region helper functions    
        #endregion
    }
}
